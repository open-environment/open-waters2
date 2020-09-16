using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OpwnWater2.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTempSampleRepository : Repository<TWqxImportTempSample>, ITWqxImportTempSampleRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITWqxRefDataRepository _refDataRepo;
        private readonly ITWqxMonLocRepository _monlocRepo;
        private readonly ITWqxRefSampColMethodRepository _refSampColMethodRepo;
        private readonly ITWqxRefSampPrepRepository _refSampPrepRepo;
        private readonly ITWqxProjectRepository _projRepo;
        private readonly ITOeUsersRepository _userRepo;
        private readonly ITWqxOrganizationRepository _orgRepo;
        private readonly ITOeAppSettingsRepository _appSettingsRepo;
        private readonly ITWqxRefDefaultTimeZoneRepository _timeZoneRepo;
        public TWqxImportTempSampleRepository(ApplicationDbContext db,
            ITWqxRefDataRepository refDataRepo,
            ITWqxMonLocRepository monlocRepo,
            ITWqxRefSampColMethodRepository refSampColMethodRepo,
            ITWqxRefSampPrepRepository refSampPrepRepo,
            ITWqxProjectRepository projRepo,
            ITOeUsersRepository userRepo,
            ITWqxOrganizationRepository orgRepo,
            ITOeAppSettingsRepository appSettingsRepo,
            ITWqxRefDefaultTimeZoneRepository timeZoneRepo) : base(db)
        {
            _db = db;
            _refDataRepo = refDataRepo;
            _monlocRepo = monlocRepo;
            _refSampColMethodRepo = refSampColMethodRepo;
            _refSampPrepRepo = refSampPrepRepo;
            _projRepo = projRepo;
            _userRepo = userRepo;
            _orgRepo = orgRepo;
            _appSettingsRepo = appSettingsRepo;
            _timeZoneRepo = timeZoneRepo;
        }

        public int DeleteT_WQX_IMPORT_TEMP_SAMPLE(string userId)
        {
            try
            {
                _db.TWqxImportTempSample.RemoveRange(
                    _db.TWqxImportTempSample.Where(s => s.UserId == userId));
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
       
        public int CancelProcessImportTempSample(int userIdx)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if (user == null)
                {
                    return actResult;
                }
                DeleteT_WQX_IMPORT_TEMP_SAMPLE(user.UserId);
            }
            catch (Exception ex)
            {
                throw;
            }
            return actResult;
        }
        public List<Models.Model.ImportSampleResultDisplay> GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempSample
                        join b in _db.TWqxImportTempResult on a.TempSampleIdx equals b.TempSampleIdx into tjoin
                        from b in tjoin.DefaultIfEmpty()
                        where a.UserId == UserID
                        orderby a.ActivityIdx
                        select new Models.Model.ImportSampleResultDisplay
                        {
                            TempSampleIdx = a.TempSampleIdx,
                            OrgId = a.OrgId,
                            ProjectId = a.ProjectId,
                            MonlocId = a.MonlocId,
                            ActivityId = a.ActivityId,
                            ActType = a.ActType,
                            ActMedia = a.ActMedia,
                            ActSubmedia = a.ActSubmedia,
                            ActStartDt = a.ActStartDt,
                            ActEndDt = a.ActEndDt,
                            ActTimeZone = a.ActTimeZone,
                            RelativeDepthName = a.RelativeDepthName,
                            ActDepthheightMsr = a.ActDepthheightMsr,
                            ActDepthheightMsrUnit = a.ActDepthheightMsrUnit,
                            TopDepthheightMsr = a.TopDepthheightMsr,
                            TopDepthheightMsrUnit = a.TopDepthheightMsrUnit,
                            BotDepthheightMsr = a.BotDepthheightMsr,
                            BotDepthheightMsrUnit = a.BotDepthheightMsrUnit,
                            DepthRefPoint = a.DepthRefPoint,
                            ActComment = a.ActComment,
                            BioAssemblageSampled = a.BioAssemblageSampled,
                            BioDurationMsr = a.BioDurationMsr,
                            BioDurationMsrUnit = a.BioDurationMsrUnit,
                            BioSampComponent = a.BioSampComponent,
                            BioSampComponentSeq = a.BioSampComponentSeq,
                            SampCollMethodId = a.SampCollMethodId,
                            SampCollMethodCtx = a.SampCollMethodCtx,
                            SampCollEquip = a.SampCollEquip,
                            SampCollEquipComment = a.SampCollEquipComment,
                            SampPrepId = a.SampPrepId,
                            SampPrepCtx = a.SampPrepCtx,
                            TempResultIdx = b.TempResultIdx,
                            DataLoggerLine = b.DataLoggerLine,
                            ResultDetectCondition = b.ResultDetectCondition,
                            CharName = b.CharName,
                            MethodSpeciationName = b.MethodSpeciationName,
                            ResultSampFraction = b.ResultSampFraction,
                            ResultMsr = b.ResultMsr,
                            ResultMsrUnit = b.ResultMsrUnit,
                            ResultMsrQual = b.ResultMsrQual,
                            ResultStatus = b.ResultStatus,
                            StatisticBaseCode = b.StatisticBaseCode,
                            ResultValueType = b.ResultValueType,
                            WeightBasis = b.WeightBasis,
                            TimeBasis = b.TimeBasis,
                            TempBasis = b.TempBasis,
                            ParticlesizeBasis = b.ParticlesizeBasis,
                            PrecisionValue = b.PrecisionValue,
                            BiasValue = b.BiasValue,
                            ResultComment = b.ResultComment,

                            BioIntentName = b.BioIntentName,
                            BioIndividualId = b.BioIndividualId,
                            BioSubjectTaxonomy = b.BioSubjectTaxonomy,
                            BioUnidentifiedSpeciesId = b.BioUnidentifiedSpeciesId,
                            BioSampleTissueAnatomy = b.BioSampleTissueAnatomy,
                            GrpSummCountWeightMsr = b.GrpSummCountWeightMsr,
                            GrpSummCountWeightMsrUnit = b.GrpSummCountWeightMsrUnit,
                            FreqClassCode = b.FreqClassCode,
                            FreqClassUnit = b.FreqClassUnit,
                            AnalyticMethodId = b.AnalyticMethodId,
                            AnalyticMethodCtx = b.AnalyticMethodCtx,
                            LabName = b.LabName,
                            LabAnalysisStartDt = b.LabAnalysisStartDt,
                            LabAnalysisEndDt = b.LabAnalysisEndDt,
                            ResultLabCommentCode = b.ResultLabCommentCode,
                            MethodDetectionLevel = b.MethodDetectionLevel,
                            LabReportingLevel = b.LabReportingLevel,
                            Pql = b.Pql,
                            LowerQuantLimit = b.LowerQuantLimit,
                            UpperQuantLimit = b.UpperQuantLimit,
                            DetectionLimitUnit = b.DetectionLimitUnit,
                            LabSampPrepStartDt = b.LabSampPrepStartDt,
                            DilutionFactor = b.DilutionFactor,
                            ImportStatusCd = (a.ImportStatusCd == "F" || b.ImportStatusCd == null) ? a.ImportStatusCd : b.ImportStatusCd,
                            ImportStatusDesc = (a.ImportStatusDesc ?? " ") + " " + (b.ImportStatusDesc ?? "")
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.Model.ImportSampleResultDisplay> GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(int UserIdx)
        {
            List<Models.Model.ImportSampleResultDisplay> actResult = null;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == UserIdx).FirstOrDefault();
                if (user != null)
                {
                    return GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(user.UserId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        public int InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE(int? tEMP_SAMPLE_IDX, 
            string uSER_ID, string oRG_ID, int? pROJECT_IDX, string pROJECT_ID, 
            int? mONLOC_IDX, string mONLOC_ID, int? aCTIVITY_IDX, 
            string aCTIVITY_ID, string aCT_TYPE, string aCT_MEDIA, 
            string aCT_SUBMEDIA, DateTime? aCT_START_DT, DateTime? aCT_END_DT, 
            string aCT_TIME_ZONE, string rELATIVE_DEPTH_NAME, 
            string aCT_DEPTHHEIGHT_MSR, string aCT_DEPTHHEIGHT_MSR_UNIT, 
            string tOP_DEPTHHEIGHT_MSR, string tOP_DEPTHHEIGHT_MSR_UNIT, 
            string bOT_DEPTHHEIGHT_MSR, string bOT_DEPTHHEIGHT_MSR_UNIT, 
            string dEPTH_REF_POINT, string aCT_COMMENT, 
            string bIO_ASSEMBLAGE_SAMPLED, string bIO_DURATION_MSR, 
            string bIO_DURATION_MSR_UNIT, string bIO_SAMP_COMPONENT, 
            int? bIO_SAMP_COMPONENT_SEQ, string bIO_REACH_LEN_MSR, 
            string bIO_REACH_LEN_MSR_UNIT, string bIO_REACH_WID_MSR, 
            string bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT, 
            string bIO_NET_TYPE, string bIO_NET_AREA_MSR, 
            string bIO_NET_AREA_MSR_UNIT, string bIO_NET_MESHSIZE_MSR, 
            string bIO_MESHSIZE_MSR_UNIT, string bIO_BOAT_SPEED_MSR, 
            string bIO_BOAT_SPEED_MSR_UNIT, string bIO_CURR_SPEED_MSR, 
            string bIO_CURR_SPEED_MSR_UNIT, string bIO_TOXICITY_TEST_TYPE, 
            int? sAMP_COLL_METHOD_IDX, string sAMP_COLL_METHOD_ID, 
            string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, 
            string sAMP_COLL_EQUIP, string sAMP_COLL_EQUIP_COMMENT, 
            int? sAMP_PREP_IDX, string sAMP_PREP_ID, string sAMP_PREP_CTX, 
            string sAMP_PREP_NAME, string sAMP_PREP_CONT_TYPE, 
            string sAMP_PREP_CONT_COLOR, string sAMP_PREP_CHEM_PRESERV, 
            string sAMP_PREP_THERM_PRESERV, string sAMP_PREP_STORAGE_DESC, 
            string sTATUS_CD, string sTATUS_DESC, bool BioIndicator, 
            bool autoImportRefDataInd)
        {
            Boolean insInd = false;

            //******************* GET STARTING RECORD *************************************************
            TWqxImportTempSample a;
            if (tEMP_SAMPLE_IDX != null)  //grab from IDX if given
                a = (from c in _db.TWqxImportTempSample
                     where c.TempSampleIdx == tEMP_SAMPLE_IDX
                     select c).FirstOrDefault();
            else  //check if existing activity ID exists in the import
            {
                a = (from c in _db.TWqxImportTempSample
                     where c.ActivityId == aCTIVITY_ID
                     && c.OrgId == oRG_ID
                     select c).FirstOrDefault();
            }

            //if can't find a match based on supplied IDX or ID, then create a new record
            if (a == null)
            {
                insInd = true;
                a = new TWqxImportTempSample();
            }
            //********************** END GET STARTING RECORD ************************************************


            if (!string.IsNullOrEmpty(uSER_ID)) a.UserId = uSER_ID;
            if (!string.IsNullOrEmpty(oRG_ID)) a.OrgId = oRG_ID;

            //PROJECT HANDLING
            if (pROJECT_IDX == null && pROJECT_ID == null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID must be provided. "; }
            if (pROJECT_IDX != null) a.ProjectIdx = pROJECT_IDX;

            if (pROJECT_ID != null)
            {
                a.ProjectId = pROJECT_ID.Trim().SubStringPlus(0, 35);

                TWqxProject ptemp = _projRepo.GetWQX_PROJECT_ByIDString(pROJECT_ID, oRG_ID);
                if (ptemp == null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID does not exist. Create project first."; }
                else { a.ProjectIdx = ptemp.ProjectIdx; }
            }

            //MONITORING LOCATION HANDLING
            if (mONLOC_IDX == null && mONLOC_ID == null) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID must be provided. "; }
            if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;

            if (mONLOC_ID != null)
            {
                a.MonlocId = mONLOC_ID.Trim().SubStringPlus(0, 35);

                TWqxMonloc mm = _monlocRepo.GetWQX_MONLOC_ByIDString(oRG_ID, mONLOC_ID);
                if (mm == null) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID does not exist. Import MonLocs first."; }
                else { a.MonlocIdx = mm.MonlocIdx; }
            }


            //ACTIVITY ID HANDLING
            if (aCTIVITY_IDX == null && aCTIVITY_ID == null) { sTATUS_CD = "F"; sTATUS_DESC += "Activity ID must be provided. "; }
            if (aCTIVITY_IDX != null) a.ActivityIdx = aCTIVITY_IDX;
            if (!string.IsNullOrEmpty(aCTIVITY_ID)) a.ActivityId = aCTIVITY_ID.Trim().SubStringPlus(0, 35);


            //ACTIVITY TYPE HANDLING
            if (!string.IsNullOrEmpty(aCT_TYPE))
            {
                a.ActType = aCT_TYPE.SubStringPlus(0, 70) ?? "";
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ActivityType", aCT_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Activity Type not valid. "; }
            }
            else
            { a.ActType = ""; sTATUS_CD = "F"; sTATUS_DESC += "Activity Type is required."; }

            if (!string.IsNullOrEmpty(aCT_MEDIA))
            {
                a.ActMedia = aCT_MEDIA.SubStringPlus(0, 20) ?? "";
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ActivityMedia", aCT_MEDIA.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Activity Media not valid. "; }
            }
            else
            { a.ActMedia = ""; sTATUS_CD = "F"; sTATUS_DESC += "Activity Media is required."; }

            if (!string.IsNullOrEmpty(aCT_SUBMEDIA))
            {
                a.ActSubmedia = aCT_SUBMEDIA.SubStringPlus(0, 45);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ActivityMediaSubdivision", aCT_SUBMEDIA.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Activity Media Subdivision not valid. "; }
            }


            if (aCT_START_DT == null)
            {
                sTATUS_CD = "F"; sTATUS_DESC += "Activity Start Date must be provided. ";
            }
            else
            {
                //fix improperly formatted datetime
                if (aCT_START_DT.ConvertOrDefault<DateTime>().Year < 1900)
                { sTATUS_CD = "F"; sTATUS_DESC += "Activity Start Date is formatted incorrectly. "; }
                else
                    a.ActStartDt = aCT_START_DT;
            }

            if (aCT_END_DT != null)
            {
                //fix improperly formatted datetime
                if (aCT_END_DT.ConvertOrDefault<DateTime>().Year < 1900)
                    aCT_END_DT = null;

                a.ActEndDt = aCT_END_DT;
            }

            if (!string.IsNullOrEmpty(aCT_TIME_ZONE))
            {
                a.ActTimeZone = aCT_TIME_ZONE.Trim().SubStringPlus(0, 4);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("TimeZone", aCT_TIME_ZONE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "TimeZone not valid. "; }
            }
            else
            {
                //put in Timezone if missing
                a.ActTimeZone = UtilityHelper.GetWQXTimeZoneByDate(
                    a.ActStartDt.ConvertOrDefault<DateTime>(), oRG_ID,
                    _orgRepo, _appSettingsRepo, _timeZoneRepo);
            }


            if (!string.IsNullOrEmpty(rELATIVE_DEPTH_NAME))
            {
                a.RelativeDepthName = rELATIVE_DEPTH_NAME.Trim().SubStringPlus(0, 15);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ActivityRelativeDepth", rELATIVE_DEPTH_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Relative Depth Name not valid. "; }
            }

            if (!string.IsNullOrEmpty(aCT_DEPTHHEIGHT_MSR))
            {
                a.ActDepthheightMsr = aCT_DEPTHHEIGHT_MSR.Trim().SubStringPlus(0, 12);
            }

            if (!string.IsNullOrEmpty(aCT_DEPTHHEIGHT_MSR_UNIT))
            {
                a.ActDepthheightMsrUnit = aCT_DEPTHHEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", aCT_DEPTHHEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Depth Measure Unit not valid. "; }
            }

            if (!string.IsNullOrEmpty(tOP_DEPTHHEIGHT_MSR))
            {
                a.TopDepthheightMsr = tOP_DEPTHHEIGHT_MSR.Trim().SubStringPlus(0, 12);
            }

            if (!string.IsNullOrEmpty(tOP_DEPTHHEIGHT_MSR_UNIT))
            {
                a.TopDepthheightMsrUnit = tOP_DEPTHHEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", tOP_DEPTHHEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Top Depth Measure Unit not valid. "; }
            }

            if (!string.IsNullOrEmpty(bOT_DEPTHHEIGHT_MSR))
            {
                a.BotDepthheightMsr = bOT_DEPTHHEIGHT_MSR.Trim().SubStringPlus(0, 12);
            }

            if (!string.IsNullOrEmpty(bOT_DEPTHHEIGHT_MSR_UNIT))
            {
                a.BotDepthheightMsrUnit = bOT_DEPTHHEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bOT_DEPTHHEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bottom Depth Measure Unit not valid. "; }
            }

            if (!string.IsNullOrEmpty(dEPTH_REF_POINT))
            {
                a.DepthRefPoint = dEPTH_REF_POINT.Trim().SubStringPlus(0, 125);
            }

            if (!string.IsNullOrEmpty(aCT_COMMENT))
            {
                a.ActComment = aCT_COMMENT.Trim().SubStringPlus(0, 4000);
            }

            //BIOLOGICAL MONITORING 
            if (BioIndicator == true)
            {
                if (!string.IsNullOrEmpty(bIO_ASSEMBLAGE_SAMPLED))
                {
                    a.BioAssemblageSampled = bIO_ASSEMBLAGE_SAMPLED.Trim().SubStringPlus(0, 50);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("Assemblage", bIO_ASSEMBLAGE_SAMPLED.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Assemblage not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_DURATION_MSR))
                {
                    a.BioDurationMsr = bIO_DURATION_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_DURATION_MSR_UNIT))
                {
                    a.BioDurationMsrUnit = bIO_DURATION_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_DURATION_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Collection Duration Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_SAMP_COMPONENT))
                {
                    a.BioSampComponent = bIO_SAMP_COMPONENT.Trim().SubStringPlus(0, 15);
                }

                if (bIO_SAMP_COMPONENT_SEQ != null) a.BioSampComponentSeq = bIO_SAMP_COMPONENT_SEQ;

                if (!string.IsNullOrEmpty(bIO_REACH_LEN_MSR))
                {
                    a.BioReachLenMsr = bIO_REACH_LEN_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_REACH_LEN_MSR_UNIT))
                {
                    a.BioReachLenMsrUnit = bIO_REACH_LEN_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_REACH_LEN_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Reach Length Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_REACH_WID_MSR))
                {
                    a.BioReachWidMsr = bIO_REACH_WID_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_REACH_WID_MSR_UNIT))
                {
                    a.BioReachWidMsrUnit = bIO_REACH_WID_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_REACH_WID_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Reach Width Unit not valid. "; }
                }

                if (bIO_PASS_COUNT != null) a.BioPassCount = bIO_PASS_COUNT;

                if (!string.IsNullOrEmpty(bIO_NET_TYPE))
                {
                    a.BioNetType = bIO_NET_TYPE.Trim().SubStringPlus(0, 30);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("NetType", bIO_NET_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Net Type not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_NET_AREA_MSR))
                {
                    a.BioNetAreaMsr = bIO_NET_AREA_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_NET_AREA_MSR_UNIT))
                {
                    a.BioNetAreaMsrUnit = bIO_NET_AREA_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_NET_AREA_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Net Area Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_NET_MESHSIZE_MSR))
                {
                    a.BioNetMeshsizeMsr = bIO_NET_MESHSIZE_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_MESHSIZE_MSR_UNIT))
                {
                    a.BioMeshsizeMsrUnit = bIO_MESHSIZE_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_MESHSIZE_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Net Mesh Size Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_BOAT_SPEED_MSR))
                {
                    a.BioBoatSpeedMsr = bIO_BOAT_SPEED_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_BOAT_SPEED_MSR_UNIT))
                {
                    a.BioBoatSpeedMsrUnit = bIO_BOAT_SPEED_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_BOAT_SPEED_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Boat Speed Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_CURR_SPEED_MSR))
                {
                    a.BioCurrSpeedMsr = bIO_CURR_SPEED_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bIO_CURR_SPEED_MSR_UNIT))
                {
                    a.BioCurrSpeedMsrUnit = bIO_CURR_SPEED_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_CURR_SPEED_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Current Speed Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bIO_TOXICITY_TEST_TYPE))
                {
                    a.BioToxicityTestType = bIO_TOXICITY_TEST_TYPE.Trim().SubStringPlus(0, 7);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ToxicityTestType", bIO_TOXICITY_TEST_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Toxicity Test Type not valid. "; }
                }
            }

            if (sAMP_COLL_METHOD_IDX != null)
            {
                a.SampCollMethodIdx = sAMP_COLL_METHOD_IDX;

                //if IDX is populated but ID/Name/Ctx aren't then grab them
                TWqxRefSampColMethod scm = _refSampColMethodRepo.GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(a.SampCollMethodIdx);
                if (scm != null)
                {
                    a.SampCollMethodId = scm.SampCollMethodId;
                    a.SampCollMethodName = scm.SampCollMethodName;
                    a.SampCollMethodCtx = scm.SampCollMethodCtx;
                }
            }
            else
            {
                //set context to org id if none is provided 
                if (!string.IsNullOrEmpty(sAMP_COLL_METHOD_ID) && string.IsNullOrEmpty(sAMP_COLL_METHOD_CTX))
                    sAMP_COLL_METHOD_CTX = oRG_ID;

                if (!string.IsNullOrEmpty(sAMP_COLL_METHOD_ID) && !string.IsNullOrEmpty(sAMP_COLL_METHOD_CTX))
                {
                    //lookup matching collection method IDX
                    TWqxRefSampColMethod scm = _refSampColMethodRepo.GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(sAMP_COLL_METHOD_ID.Trim(), sAMP_COLL_METHOD_CTX.Trim());
                    if (scm != null)
                        a.SampCollMethodIdx = scm.SampCollMethodIdx;
                    else  //no matching sample collection method lookup found
                    {
                        if (autoImportRefDataInd == true)
                        {
                            _refSampColMethodRepo.InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(null, sAMP_COLL_METHOD_ID.Trim(), sAMP_COLL_METHOD_CTX.Trim(), sAMP_COLL_METHOD_NAME.Trim(), "", true);
                        }
                        else
                        {
                            sTATUS_CD = "F"; sTATUS_DESC += "No matching Sample Collection Method found - please add it at the Reference Data screen first. ";
                        }
                    }
                    //****************************************

                    a.SampCollMethodId = sAMP_COLL_METHOD_ID.Trim().SubStringPlus(0, 20);
                    a.SampCollMethodCtx = sAMP_COLL_METHOD_CTX.Trim().SubStringPlus(0, 120);

                    if (!string.IsNullOrEmpty(sAMP_COLL_METHOD_NAME))
                    {
                        a.SampCollMethodName = sAMP_COLL_METHOD_NAME.Trim().SubStringPlus(0, 120);
                    }
                }
            }

            if (a.SampCollMethodIdx == null && a.ActType.ToUpper().Contains("SAMPLE"))
            { sTATUS_CD = "F"; sTATUS_DESC += "Sample Collection Method is required when Activity Type contains the term -Sample-. "; }


            if (!string.IsNullOrEmpty(sAMP_COLL_EQUIP))
            {
                a.SampCollEquip = sAMP_COLL_EQUIP.Trim().SubStringPlus(0, 40);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("SampleCollectionEquipment", sAMP_COLL_EQUIP.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Collection Equipment not valid. "; }
            }
            else
            {
                //special validation requiring sampling collection equipment if activity type contains "Sample"
                if (a.ActType.ToUpper().Contains("SAMPLE"))
                { sTATUS_CD = "F"; sTATUS_DESC += "Sample Collection Equipment is required when Activity Type contains the term -Sample-. "; }
            }


            if (!string.IsNullOrEmpty(sAMP_COLL_EQUIP_COMMENT))
            {
                a.SampCollEquipComment = sAMP_COLL_EQUIP_COMMENT.Trim().SubStringPlus(0, 4000);
            }


            if (sAMP_PREP_IDX != null)
                a.SampPrepIdx = sAMP_PREP_IDX;
            else
            {
                //set context to org id if none is provided 
                if (!string.IsNullOrEmpty(sAMP_PREP_ID) && string.IsNullOrEmpty(sAMP_PREP_CTX))
                    sAMP_PREP_CTX = oRG_ID;

                if (!string.IsNullOrEmpty(sAMP_PREP_ID) && !string.IsNullOrEmpty(sAMP_PREP_CTX))
                {
                    //see if matching prep method exists
                    TWqxRefSampPrep sp = _refSampPrepRepo.GetT_WQX_REF_SAMP_PREP_ByIDandContext(sAMP_PREP_ID.Trim(), sAMP_PREP_CTX.Trim());
                    if (sp != null)
                        a.SampPrepIdx = sp.SampPrepIdx;
                    //****************************************

                    a.SampPrepId = sAMP_PREP_ID.Trim().SubStringPlus(0, 20);
                    a.SampPrepCtx = sAMP_PREP_CTX.Trim().SubStringPlus(0, 120);

                    if (!string.IsNullOrEmpty(sAMP_PREP_NAME))
                    {
                        a.SampPrepName = sAMP_PREP_NAME.Trim().SubStringPlus(0, 120);
                    }
                }
            }


            if (!string.IsNullOrEmpty(sAMP_PREP_CONT_TYPE))
            {
                a.SampPrepContType = sAMP_PREP_CONT_TYPE.Trim().SubStringPlus(0, 35);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("SampleContainerType", sAMP_PREP_CONT_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Container Type not valid. "; }
            }


            if (!string.IsNullOrEmpty(sAMP_PREP_CONT_COLOR))
            {
                a.SampPrepContColor = sAMP_PREP_CONT_COLOR.Trim().SubStringPlus(0, 15);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("SampleContainerColor", sAMP_PREP_CONT_COLOR.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Container Color not valid. "; }
            }


            if (!string.IsNullOrEmpty(sAMP_PREP_CHEM_PRESERV))
            {
                a.SampPrepChemPreserv = sAMP_PREP_CHEM_PRESERV.Trim().SubStringPlus(0, 250);
            }

            if (!string.IsNullOrEmpty(sAMP_PREP_THERM_PRESERV))
            {
                a.SampPrepThermPreserv = sAMP_PREP_THERM_PRESERV.Trim().SubStringPlus(0, 25);
                if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ThermalPreservativeUsed", sAMP_PREP_THERM_PRESERV.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Thermal Preservative Used not valid. "; }
            }

            if (!string.IsNullOrEmpty(sAMP_PREP_STORAGE_DESC))
            {
                a.SampPrepStorageDesc = sAMP_PREP_STORAGE_DESC.Trim().SubStringPlus(0, 250);
            }


            if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
            if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

            if (insInd) //insert case
                _db.TWqxImportTempSample.Add(a);

            _db.SaveChanges();

            return a.TempSampleIdx;
        }

        public int InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE_Status(int tempSampleIdx, string statusCd, string statusDesc)
        {
            try
            {
                
                    TWqxImportTempSample a =
                        (from c in _db.TWqxImportTempSample
                         where c.TempSampleIdx == tempSampleIdx
                         select c).FirstOrDefault();

                    a.ImportStatusCd = statusCd;
                    a.ImportStatusDesc = (a.ImportStatusDesc + " " + statusDesc).SubStringPlus(0, 100);

                    _db.SaveChanges();

                    return tempSampleIdx;
                
            }
            catch (Exception ex)
            {
                statusCd = "F";
                statusDesc += "Unspecified error";
                return 0;
            }
        }

        public int InsertUpdateWQX_IMPORT_TEMP_SAMPLE_New(string userId, string orgId, int? projectIdx, string projectId, Dictionary<string, string> colVals, string configFilePath)
        {
            try
            {
                bool insInd = false;

                //******************* GET STARTING RECORD *************************************************
                string _a = UtilityHelper.GetValueOrDefault(colVals, "ACTIVITY_ID");
                TWqxImportTempSample a = (from c in _db.TWqxImportTempSample
                                          where c.ActivityId == _a
                                              && c.OrgId == orgId
                                              select c).FirstOrDefault();

                //if can't find a match based on supplied ID, then create a new record
                if (a == null)
                {
                    insInd = true;
                    a = new TWqxImportTempSample();
                }
                //********************** END GET STARTING RECORD ************************************************


                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                if (!string.IsNullOrEmpty(userId)) a.UserId = userId; else return 0;
                if (!string.IsNullOrEmpty(orgId)) a.OrgId = orgId; else return 0;
                if (projectIdx != null) a.ProjectIdx = projectIdx; else return 0;
                if (!string.IsNullOrEmpty(projectId)) a.ProjectId = projectId; else return 0;

                //get import config rules
                List<ConfigInfoType> _allRules = UtilityHelper.GetAllColumnInfo("S", configFilePath);


                //validate mandatory fields
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "MonlocId");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ActivityId");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ActType");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ActMedia");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ActStartDt");

                //loop through all optional fields
                List<string> rFields = new List<string>(new string[] { "ActSubmedia","ActEndDt","ActTimeZone","RelativeDepthName","ActDepthheightMsr",
                        "ActDepthheightMsrUnit","TopDepthheightMsr","TopDepthheightMsrUnit","BotDepthheightMsr","BotDepthheightMsrUnit","DepthRefPoint",
                        "ActComment","BioAssemblageSampled","BioDurationMsr","BioDurationMsrUnit","BioSampComponent", "BioSampComponentSeq","BioReachLenMsr",
                        "BioReachLenMsrUnit","BioReachWidMsr","BioReachWidMsrUnit","BioPassCount","BioNetType","BioNetAreaMsr","BioNetAreaMsrUnit",
                        "BioNetMeshsizeMsr","BioMeshsizeMsrUnit","BioBoatSpeedMsr","BioBoatSpeedMsrUnit","BioCurrSpeedMsr","BioCurrSpeedMsrUnit",
                        "BioToxicityTestType","SampCollMethodIdx","SampCollMethodId","SampCollMethodCtx","SampCollEquip","SampCollEquipComment",
                        "SampPrepIdx","SampPrepId","SampPrepCtx","SampPrepContType","SampPrepContColor","SampPrepChemPreserv","SampPrepThermPreserv","SampPrepStorageDesc"
                    });

                foreach (KeyValuePair<string, string> entry in colVals)
                    if (rFields.Contains(entry.Key))
                        WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, entry.Key);


                //********************** CUSTOM POST VALIDATION ********************************************
                //SET MONLOC_IDX based on supplied MONLOC_ID
                if (!string.IsNullOrEmpty(a.MonlocId))
                {
                    TWqxMonloc mm = _monlocRepo.GetWQX_MONLOC_ByIDString(orgId, a.MonlocId);
                    if (mm == null) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Invalid Monitoring Location ID."; }
                    else { a.MonlocIdx = mm.MonlocIdx; }
                }

                //SET ACTIVITY TIMEZONE IF NOT SUPPLIED
                if (string.IsNullOrEmpty(a.ActTimeZone))
                    a.ActTimeZone = UtilityHelper.GetWQXTimeZoneByDate(
                        a.ActStartDt.ConvertOrDefault<DateTime>(), orgId,
                        _orgRepo, _appSettingsRepo, _timeZoneRepo);

                //special sampling collection method handling
                if (a.SampCollMethodIdx != null)
                {
                    //if IDX is populated, grab ID/Name/Ctx 
                    TWqxRefSampColMethod scm = _refSampColMethodRepo.GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(a.SampCollMethodIdx);
                    if (scm != null)
                    {
                        a.SampCollMethodId = scm.SampCollMethodId;
                        a.SampCollMethodName = scm.SampCollMethodName;
                        a.SampCollMethodCtx = scm.SampCollMethodCtx;
                    }
                }
                else
                {
                    //set context to org id if none is provided 
                    if (!string.IsNullOrEmpty(a.SampCollMethodId) && string.IsNullOrEmpty(a.SampCollMethodCtx))
                        a.SampCollMethodCtx = orgId;

                    if (!string.IsNullOrEmpty(a.SampCollMethodId))
                    {
                        TWqxRefSampColMethod scm = _refSampColMethodRepo.GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(a.SampCollMethodId, a.SampCollMethodCtx);
                        if (scm != null)
                            a.SampCollMethodIdx = scm.SampCollMethodIdx;
                        else  //no matching sample collection method lookup found
                        { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Sample Collection Method found - please add it at the Reference Data screen first. "; }
                    }
                }


                //special validation requiring sampling collection method if activity type contains "Sample"
                if (a.SampCollMethodIdx == null && a.ActType.ToUpper().Contains("SAMPLE"))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Sample Collection Method is required when Activity Type contains the term -Sample-. "; }

                //special validation requiring sampling collection equipment if activity type contains "Sample"
                if (string.IsNullOrEmpty(a.SampCollEquip) && a.ActType.ToUpper().Contains("SAMPLE"))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Sample Collection Equipment is required when Activity Type contains the term -Sample-. "; }


                //sampling prep method handling
                if (a.SampPrepIdx == null)
                {
                    if (string.IsNullOrEmpty(a.SampPrepCtx) && !string.IsNullOrEmpty(a.SampPrepId))
                        a.SampPrepCtx = orgId;

                    if (!string.IsNullOrEmpty(a.SampPrepId) && !string.IsNullOrEmpty(a.SampPrepCtx))
                    {
                        //see if matching prep method exists
                        TWqxRefSampPrep sp = _refSampPrepRepo.GetT_WQX_REF_SAMP_PREP_ByIDandContext(a.SampPrepId, a.SampPrepCtx);
                        if (sp != null)
                            a.SampPrepIdx = sp.SampPrepIdx;
                        else  //no matching sample prep method lookup found
                        { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Sample Prep Method found - please add it at the Reference Data screen first. "; }
                    }
                }
                //********************** CUSTOM POST VALIDATION ********************************************


                a.ImportStatusDesc = a.ImportStatusDesc.SubStringPlus(0, 200);

                if (insInd) //insert case
                    _db.TWqxImportTempSample.Add(a);

                _db.SaveChanges();

                return a.TempSampleIdx;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int SP_ImportActivityFromTemp(int userIdx, string WQXInd, string activityReplacedInd)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if(user == null)
                {
                    return actResult;
                }
                return SP_ImportActivityFromTemp(user.UserId, WQXInd, activityReplacedInd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }
        public int SP_ImportActivityFromTemp(string userID, string WQXInd, string activityReplacedInd)
        {
            int actResult = 0;
            try
            {
                //return _db.ImportActivityFromTemp(userID, WQXInd, activityReplacedInd);
                actResult = _db.Database.ExecuteSqlCommand("ImportActivityFromTemp @p0, @p1, @p2", parameters: new[] { userID, WQXInd, activityReplacedInd });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        public void Update(TWqxImportTempSample wqxImportTempSample)
        {
            throw new NotImplementedException();
        }

        public void WQX_IMPORT_TEMP_SAMPLE_GenVal(ref TWqxImportTempSample a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            var _rules = t.Find(item => item._name == f);   //import validation rules for this field
            if (_rules == null)
                return;

            string _value = UtilityHelper.GetValueOrDefault(colVals, f); //supplied value for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //if this field has another field which gets added to it (used for Date + Time fields)
                if (!string.IsNullOrEmpty(_rules._addfield))
                    _value = _value + " " + UtilityHelper.GetValueOrDefault(colVals, _rules._addfield);

                //strings: field length validation and substring 
                if (_rules._datatype == "" && _rules._length != null)
                {
                    if (_value.Length > _rules._length)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ");

                        _value = _value.SubStringPlus(0, (int)_rules._length);
                    }
                }

                //integers: check type
                if (_rules._datatype == "int")
                {
                    int n;
                    if (int.TryParse(_value, out n) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ");
                    }
                }

                //datetime: check type
                if (_rules._datatype == "datetime")
                {
                    if (_value.ConvertOrDefault<DateTime>().Year < 1900)
                    {
                        if (_rules._req == "Y")
                            _value = new DateTime(1900, 1, 1).ToString();

                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not properly formatted. ");
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ");
                    }
                }
            }
            else
            {
                //required check
                if (_rules._req == "Y")
                {
                    if (_rules._datatype == "")
                        _value = "-";
                    else if (_rules._datatype == "datetime")
                        _value = new DateTime(1900, 1, 1).ToString();
                    a.ImportStatusCd = "F";
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ");
                }
            }

            //finally set the value before returning
            try
            {
                if (_rules._datatype == "")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value);
                else if (_rules._datatype == "int")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
                else if (_rules._datatype == "datetime" && _rules._req == "Y")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime>());
                else if (_rules._datatype == "datetime" && _rules._req == "N")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime?>());
            }
            catch { }
        }
    }
}
