using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class WqxImportRepository : Repository<WqxImportModel>, IWqxImportRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITWqxImportTempMonlocRepository _tempMonlocRepo;
        private readonly ITWqxImportTempSampleRepository _tempSampleRepo;
        private readonly ITWqxImportTempActivityMetricRepository _tempActivityMetreicRepo;
        private readonly ITWqxImportTempBioIndexRepository _tempBioIndexRepo;
        private readonly ITWqxImportTemplateDtlRepository _tempDtlRepo;
        private readonly ITWqxMonLocRepository _monlocRepo;
        private readonly ITWqxImportTranslateRepository _importTransRepo;
        private readonly ITWqxImportTempResultRepository _tempResultRepo;
        private readonly ITOeUsersRepository _userRepo;
        private readonly ITWqxProjectRepository _projectRepo;
        public WqxImportRepository(ApplicationDbContext db,
            ITWqxImportTempMonlocRepository importTempMonlocRepo,
            ITWqxImportTempSampleRepository tempSampleRepo,
            ITWqxImportTempActivityMetricRepository tempActivityMetreicRepo,
            ITWqxImportTempBioIndexRepository tempBioIndexRepo,
            ITWqxImportTemplateDtlRepository tempDtlRepo,
            ITWqxMonLocRepository monlocRepo,
            ITWqxImportTranslateRepository importTransRepo,
            ITWqxImportTempResultRepository tempResultRepo,
            ITOeUsersRepository userRepo,
            ITWqxProjectRepository projectRepo) : base(db)
        {
            _db = db;
            _tempMonlocRepo = importTempMonlocRepo;
            _tempSampleRepo = tempSampleRepo;
            _tempActivityMetreicRepo = tempActivityMetreicRepo;
            _tempBioIndexRepo = tempBioIndexRepo;
            _tempDtlRepo = tempDtlRepo;
            _monlocRepo = monlocRepo;
            _importTransRepo = importTransRepo;
            _tempResultRepo = tempResultRepo;
            _userRepo = userRepo;
            _projectRepo = projectRepo;
        }
        public string ProcessImport(int userIdx, string orgId, 
            string importType, string importData, string templatInd, 
            int projectId, string projectName, 
            int templateId, string template, string configFilePath)
        {
            string actResult = "";
            try
            {
                TOeUsers user = _userRepo.GetT_OE_USERSByIDX(userIdx);
                if(user == null)
                {
                    actResult = "Unable to proceed with import."; return actResult;
                }
                string userName = user.UserId;
                if(projectId > 0 && string.IsNullOrEmpty(projectName))
                {
                    TWqxProject p = _projectRepo.GetWQX_PROJECT_ByID(projectId);
                    if(p != null)
                    {
                        projectName = p.ProjectName;
                    }
                }
                //******************************** VALIDATION *****************************************
                if (string.IsNullOrEmpty(orgId))
                {
                    actResult = "Please select or create an organization first."; return actResult;
                }
                if (importType == "")
                {
                    actResult = "Please select a data import type."; return actResult;
                }
                if ((importType == "S" || importType == "I") && projectName == "")
                {
                    actResult = "Please select a project into which this data will be imported."; return actResult;
                }
                if (importData.Length == 0)
                {
                    actResult = "You must copy and paste data from a spreadsheet into the large textbox."; return actResult;
                }
                if (importType == "S" && templatInd == "")
                {
                    actResult = "Please indicate whether you will use a custom import template."; return actResult;
                }
                if (importType == "S" && templatInd == "Y" && template == "")
                {
                    actResult = "Please select an import template."; return actResult;
                }
                //********************************* END VALIDATION *************************************

                //delete previous temp data stored for the user
                if (!DeleteTempImportData(importType, userName))
                {
                    actResult = "Unable to proceed with import."; return actResult;
                }

                //define org and project
                string OrgID = orgId;
                int? ProjectID = projectId;
                string ProjectName = projectName;

                //**********************temporary separate handling of cross tab**************
                if (template != "" && importType == "S")
                {
                   actResult = ImportSampleCT(OrgID, templateId, ProjectID, ProjectName,
                        importData.Split(new char[] { '\n', '\r' }, 
                        StringSplitOptions.RemoveEmptyEntries), userName);
                    return actResult;
                }
                //********************** end separate handling of cross tab *******************


                //set dictionaries used to store stuff in memory
                //Dictionary<string, Tuple<string, string>> charsPool = GetCharacteristicsPool();  //list of all possible column headers that are characteristics in Open Waters
                Dictionary<string, int> colMapping = new Dictionary<string, int>();  //identifies the column number for each field to be imported
                List<string> translateFields = _importTransRepo.GetWQX_IMPORT_TRANSLATE_byColName(OrgID);  //list of fields that have translations defined

                //initialize variables
                bool headInd = true;

                //loop through each row
                foreach (string row in importData.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //split row's columns into string array
                    string[] cols = row.Split(new char[] { '\t' }, StringSplitOptions.None);

                    if (cols.Length > 0) //skip blank rows
                    {
                        if (headInd)
                        {
                            //**********************************************************
                            //HEADER ROW - LOGIC TO DETERMINE WHAT IS IN EACH COLUMN
                            //**********************************************************
                            colMapping = UtilityHelper.GetColumnMapping(importType, cols, configFilePath);

                            headInd = false;
                        }
                        else
                        {
                            //**********************************************************
                            //NOT HEADER ROW - READING IN VALUES
                            //**********************************************************
                            var colList = cols.Select((value, index) => new { value, index });
                            var colDataIndexed = (from f in colMapping
                                                  join c in colList on f.Value equals c.index
                                                  select new
                                                  {
                                                      _Name = f.Key,
                                                      _Val = c.value
                                                  }).ToList();

                            Dictionary<string, string> fieldValuesDict = new Dictionary<string, string>();  //identifies the column number for each field to be imported

                            //loop through all values and insert to list
                            foreach (var c in colDataIndexed)
                                fieldValuesDict.Add(c._Name, translateFields.Contains(c._Name) ? _importTransRepo.GetWQX_IMPORT_TRANSLATE_byColNameAndValue(OrgID, c._Name, c._Val) : c._Val);

                            //IMPORT DATA
                            if (importType == "M")
                                _tempMonlocRepo.InsertWQX_IMPORT_TEMP_MONLOC_New(userName, OrgID, fieldValuesDict, configFilePath);
                            else if (importType == "I")
                            {
                                _tempActivityMetreicRepo.InsertWQX_IMPORT_TEMP_ACTIVITY_METRIC(userName, orgId, fieldValuesDict, configFilePath);
                            }
                            else if (importType == "S")
                            {
                                int _s = _tempSampleRepo.InsertUpdateWQX_IMPORT_TEMP_SAMPLE_New(userName, orgId, ProjectID, ProjectName, fieldValuesDict, configFilePath);
                                if (_s > 0)
                                {
                                    int _r = _tempResultRepo.InsertWQX_IMPORT_TEMP_RESULT_New(_s, fieldValuesDict, OrgID, configFilePath);
                                    if (_r == 0)
                                        _tempSampleRepo.InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE_Status(_s, "F", "Unable to validate result [" + UtilityHelper.GetValueOrDefault(fieldValuesDict, "CHAR_NAME") + "]. Contact admin.");
                                }
                            }
                        }
                    }
                } //end each row

                if (!headInd)
                {
                    string urlz = "Sample";
                    if (importType == "M") urlz = "MonLoc";
                    if (importType == "I") urlz = "Metric";
                    actResult = "Process " + urlz;
                    return actResult;
                }
                else
                    actResult = "No valid data found. You must include column headers.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        private string ImportSampleCT(string OrgID, int TemplateID, int? ProjectID, string ProjectIDName, string[] rows, string userName)
        {
            string actResult = "";

            //GET the column configuration for all SAMPLE and RESULT-LEVEL FIELDS (only need to do this data retrieval once per import)
            TWqxImportTemplateDtl MonLocCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "MONLOC_ID");
            TWqxImportTemplateDtl ActivityIDCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACTIVITY_ID");
            TWqxImportTemplateDtl ActivityTypeCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_TYPE");
            TWqxImportTemplateDtl ActivityMediaCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_MEDIA");
            TWqxImportTemplateDtl ActivitySubMediaCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_SUBMEDIA");
            TWqxImportTemplateDtl ActivityStartDateCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_START_DATE");
            TWqxImportTemplateDtl ActivityStartTimeCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_START_TIME");
            TWqxImportTemplateDtl ActivityEndDateCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_END_DATE");
            TWqxImportTemplateDtl ActivityEndTimeCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_TIME_TIME");
            TWqxImportTemplateDtl ActivityCommentsCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_COMMENTS");
            TWqxImportTemplateDtl SampleMethodCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "SAMP_COLL_METHOD_IDX");
            TWqxImportTemplateDtl SampleEquipmentCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "SAMP_COLL_EQUIP");
            TWqxImportTemplateDtl ActivityDepthCol = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(TemplateID, "ACT_DEPTHHEIGHT_MSR");

            //***********************************
            //loop through each sample
            //***********************************
            foreach (string row in rows)
            {
                //declare variables to store values for the current row
                string valMsg = "";
                string MonLocIDVal = null, ActivityTypeVal = null, ActivityMediaVal = null, ActivitySubMediaVal = null, ActivityIDVal = null;
                string ActivityDepthVal = null, ActivityDepthUnitVal = null;
                int? MonLocIDXVal = null;
                DateTime? ActivityStartDateVal = null, ActivityEndDateVal = null;

                char[] delimiters = new char[] { '\t' };   //tab delimiter
                string[] parts = row.Split(delimiters, StringSplitOptions.None); //columns split into parts  //2/24/2016 change from RemoveEmptyEntries to None
                if (parts.Length > 0)
                {
                    //start of field-by-field validation

                    //monitoring location
                    if (MonLocCol == null)
                    { actResult = "Your import logic does not define a monitoring location column - import cannot be performed"; return actResult; }
                    else
                    {
                        MonLocIDVal = GetFieldValue(MonLocCol, parts);
                        TWqxMonloc mloc = _monlocRepo.GetWQX_MONLOC_ByIDString(OrgID, MonLocIDVal);
                        if (mloc == null)
                            valMsg = "Monitoring Location not found.;";
                        else
                            MonLocIDXVal = mloc.MonlocIdx;
                    }

                    ActivityTypeVal = GetFieldValue(ActivityTypeCol, parts);
                    ActivityMediaVal = GetFieldValue(ActivityMediaCol, parts);
                    ActivitySubMediaVal = GetFieldValue(ActivitySubMediaCol, parts);
                    ActivityDepthVal = GetFieldValue(ActivityDepthCol, parts);
                    if (ActivityDepthVal != null)
                        if (ActivityDepthVal.Length > 0)
                            ActivityDepthUnitVal = ActivityDepthCol.CharDefaultUnit;

                    //activity start date 
                    if (ActivityStartDateCol == null)
                    { actResult = "Your import logic does not define an activity start date column - import cannot be performed"; return actResult; }
                    else
                    {
                        string sActivityStartDateVal = GetFieldValue(ActivityStartDateCol, parts);
                        string sActivityStartTimeVal = GetFieldValue(ActivityStartTimeCol, parts);
                        ActivityStartDateVal = (sActivityStartDateVal + " " + sActivityStartTimeVal ?? "").ConvertOrDefault<DateTime?>();
                        if (ActivityStartDateVal == null) { valMsg = "Activity Start Date cannot be converted to DateTime"; }
                    }

                    //activity end date 
                    if (ActivityEndDateCol == null)
                        ActivityEndDateVal = ActivityStartDateVal;
                    else
                    {
                        string sActivityEndDateVal = GetFieldValue(ActivityEndDateCol, parts);
                        string sActivityEndTimeVal = GetFieldValue(ActivityEndTimeCol, parts);
                        ActivityEndDateVal = (sActivityEndDateVal + " " + sActivityEndTimeVal ?? "").ConvertOrDefault<DateTime?>();
                        if (ActivityEndDateCol.ColNum > 0 && ActivityStartDateVal == null) { valMsg = "Activity Start Date cannot be converted to DateTime"; }
                    }


                    //activity id (done after sample date and monloc)
                    if (ActivityStartDateVal != null)
                    {
                        if (ActivityIDCol == null)
                            ActivityIDVal = (MonLocIDVal ?? "").SubStringPlus(0, 21) + "_" + ActivityStartDateVal.Value.ToString("yyyyMMdd_HHmm");
                        else if (ActivityIDCol.CharName == "#M_D_T")
                            ActivityIDVal = (MonLocIDVal ?? "").SubStringPlus(0, 21) + "_" + ActivityStartDateVal.Value.ToString("yyyyMMdd_HHmm");
                        else if (ActivityIDCol.CharName == "#M_D_TS")
                            ActivityIDVal = (MonLocIDVal ?? "").SubStringPlus(0, 19) + "_" + ActivityStartDateVal.Value.ToString("yyyyMMdd_HHmmss");
                        else
                            ActivityIDVal = GetFieldValue(ActivityIDCol, parts);
                    }


                    int TempImportSampID = _tempSampleRepo.InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE(null, userName, OrgID, ProjectID, ProjectIDName, MonLocIDXVal, MonLocIDVal, null, ActivityIDVal,
                        ActivityTypeVal, ActivityMediaVal, ActivitySubMediaVal, ActivityStartDateVal, ActivityStartDateVal, null, null, ActivityDepthVal, ActivityDepthUnitVal, null, null, null, null, null,
                        GetFieldValue(ActivityCommentsCol, parts),
                        null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, GetFieldValue(SampleMethodCol, parts).ConvertOrDefault<int?>(),
                        null, null, null, GetFieldValue(SampleEquipmentCol, parts), null, null, null, null, null, null, null, null, null, null,
                        (valMsg.Length > 0 ? "F" : "P"), valMsg, false, false);


                    //now loop through any potential characteristics
                    List<TWqxImportTemplateDtl> chars = _tempDtlRepo.GetWQX_IMPORT_TEMPLATE_DTL_CharsByTemplateID(TemplateID);
                    foreach (TWqxImportTemplateDtl character in chars)
                    {
                        string resultVal = GetFieldValue(character, parts);

                        if (!string.IsNullOrEmpty(resultVal))
                        {
                            int TempImportResultID = _tempResultRepo.InsertOrUpdateWQX_IMPORT_TEMP_RESULT(null, TempImportSampID, null, null, null, character.CharName, null,
                            (string.IsNullOrEmpty(character.CharDefaultSampFraction) ? null : character.CharDefaultSampFraction), resultVal,
                            character.CharDefaultUnit, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            "P", "", false, OrgID, false);
                        }
                    }
                }
            }
            return actResult;
        }

        private bool DeleteTempImportData(string importType, string username)
        {
            if (importType == "M")
                return (_tempMonlocRepo.DeleteT_WQX_IMPORT_TEMP_MONLOC(username) != 0);
            else if (importType == "S")
                return (_tempSampleRepo.DeleteT_WQX_IMPORT_TEMP_SAMPLE(username) != 0);
            else if (importType == "I")
            {
                _tempActivityMetreicRepo.DeleteT_WQX_IMPORT_TEMP_ACTIVITY_METRIC(username);
                _tempBioIndexRepo.DeleteT_WQX_IMPORT_TEMP_BIO_INDEX(username);
                return true;
            }
            else
                return false;
        }
        private static string GetFieldValue(TWqxImportTemplateDtl FieldType, string[] parts)
        {
            try
            {
                return (FieldType == null ? null : (FieldType.ColNum == 0 ? FieldType.CharName : parts[FieldType.ColNum - 1]));
            }
            catch
            {
                return null;
            }
        }
    }
}
