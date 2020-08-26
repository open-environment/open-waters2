using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTempResultRepository : Repository<TWqxImportTempResult>, ITWqxImportTempResultRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITWqxRefCharacteristicRepository _refCharRepo;
        private readonly ITWqxRefDataRepository _refDataRepo;
        private readonly ITWqxRefAnalMethodRepository _refAnalMethodRepo;
        private readonly ITWqxRefLabRepository _refLabRepo;
        private readonly ITWqxRefSampPrepRepository _refSampPrepRepo;
        public TWqxImportTempResultRepository(ApplicationDbContext db,
            ITWqxRefCharacteristicRepository refCharRepo,
            ITWqxRefDataRepository refDataRepo,
            ITWqxRefAnalMethodRepository refAnalMethodRepo,
            ITWqxRefLabRepository refLabRepo,
            ITWqxRefSampPrepRepository refSampPrepRepo) : base(db)
        {
            _db = db;
            _refCharRepo = refCharRepo;
            _refDataRepo = refDataRepo;
            _refAnalMethodRepo = refAnalMethodRepo;
            _refLabRepo = refLabRepo;
            _refSampPrepRepo = refSampPrepRepo;
        }

        public int InsertOrUpdateWQX_IMPORT_TEMP_RESULT(int? tEMP_RESULT_IDX, int tEMP_SAMPLE_IDX, int? rESULT_IDX, string dATA_LOGGER_LINE, string rESULT_DETECT_CONDITION, string cHAR_NAME, string mETHOD_SPECIATION_NAME, string rESULT_SAMP_FRACTION, string rESULT_MSR, string rESULT_MSR_UNIT, string rESULT_MSR_QUAL, string rESULT_STATUS, string sTATISTIC_BASE_CODE, string rESULT_VALUE_TYPE, string wEIGHT_BASIS, string tIME_BASIS, string tEMP_BASIS, string pARTICAL_BASIS, string pRECISION_VALUE, string bIAS_VALUE, string cONFIDENCE_INTERVAL_VALUE, string uP_CONFIDENCE_LIMIT, string lOW_CONFIDENCE_LIMIT, string rESULT_COMMENT, string dEPTH_HEIGHT_MSR, string dEPTH_HEIGHT_MSR_UNIT, string dEPTHALTITUDEREFPOINT, string bIO_INTENT_NAME, string bIO_INDIVIDUAL_ID, string bIO_SUBJECT_TAXONOMY, string bIO_UNIDENTIFIED_SPECIES_ID, string bIO_SAMPLE_TISSUE_ANATOMY, string gRP_SUMM_COUNT_WEIGHT_MSR, string gRP_SUMM_COUNT_WEIGHT_MSR_UNIT, string tAX_DTL_CELL_FORM, string tAX_DTL_CELL_SHAPE, string tAX_DTL_HABIT, string tAX_DTL_VOLTINISM, string tAX_DTL_POLL_TOLERANCE, string tAX_DTL_POLL_TOLERANCE_SCALE, string tAX_DTL_TROPHIC_LEVEL, string tAX_DTL_FUNC_FEEDING_GROUP1, string tAX_DTL_FUNC_FEEDING_GROUP2, string tAX_DTL_FUNC_FEEDING_GROUP3, string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT, string fREQ_CLASS_UPPER, string fREQ_CLASS_LOWER, int? aNALYTIC_METHOD_IDX, string aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX, string aNALYTIC_METHOD_NAME, int? lAB_IDX, string lAB_NAME, DateTime? lAB_ANALYSIS_START_DT, DateTime? lAB_ANALYSIS_END_DT, string lAB_ANALYSIS_TIMEZONE, string rESULT_LAB_COMMENT_CODE, string mETHOD_DETECTION_LEVEL, string lAB_REPORTING_LEVEL, string pQL, string lOWER_QUANT_LIMIT, string uPPER_QUANT_LIMIT, string dETECTION_LIMIT_UNIT, int? lAB_SAMP_PREP_IDX, string lAB_SAMP_PREP_ID, string lAB_SAMP_PREP_CTX, DateTime? lAB_SAMP_PREP_START_DT, DateTime? lAB_SAMP_PREP_END_DT, string dILUTION_FACTOR, string sTATUS_CD, string sTATUS_DESC, bool BioIndicator, string orgID, bool autoImportRefDataInd)
        {
            Boolean insInd = false;
            try
            {
                TWqxImportTempResult a = new TWqxImportTempResult();

                if (tEMP_RESULT_IDX != null)
                    a = (from c in _db.TWqxImportTempResult
                         where c.TempResultIdx == tEMP_RESULT_IDX
                         select c).FirstOrDefault();

                if (tEMP_RESULT_IDX == null) //insert case
                    insInd = true;

                a.TempSampleIdx = tEMP_SAMPLE_IDX;
                if (rESULT_IDX != null) a.ResultIdx = rESULT_IDX;

                if (!string.IsNullOrEmpty(dATA_LOGGER_LINE))
                {
                    a.DataLoggerLine = dATA_LOGGER_LINE.Trim().SubStringPlus(0, 15);
                }

                if (rESULT_DETECT_CONDITION == "DNQ" || rESULT_MSR == "DNQ") { rESULT_DETECT_CONDITION = "Detected Not Quantified"; rESULT_MSR = "DNQ"; }
                if (rESULT_DETECT_CONDITION == "ND" || rESULT_MSR == "ND") { rESULT_DETECT_CONDITION = "Not Detected"; rESULT_MSR = "ND"; }
                if (rESULT_DETECT_CONDITION == "NR" || rESULT_MSR == "NR") { rESULT_DETECT_CONDITION = "Not Reported"; rESULT_MSR = "NR"; }
                if (rESULT_DETECT_CONDITION == "PAQL" || rESULT_MSR == "PAQL") { rESULT_DETECT_CONDITION = "Present Above Quantification Limit"; rESULT_MSR = "PAQL"; }
                if (rESULT_DETECT_CONDITION == "PBQL" || rESULT_MSR == "PBQL") { rESULT_DETECT_CONDITION = "Present Below Quantification Limit"; rESULT_MSR = "PBQL"; }

                if (!string.IsNullOrEmpty(rESULT_DETECT_CONDITION))
                {
                    a.ResultDetectCondition = rESULT_DETECT_CONDITION.Trim().SubStringPlus(0, 35);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultDetectionCondition", rESULT_DETECT_CONDITION.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Detection Condition not valid. "; }
                }

                if (!string.IsNullOrEmpty(cHAR_NAME))
                {
                    a.CharName = cHAR_NAME.Trim().SubStringPlus(0, 120);
                    if (_refCharRepo.GetT_WQX_REF_CHARACTERISTIC_ExistCheck(cHAR_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Characteristic Name not valid. "; }
                }

                if (!string.IsNullOrEmpty(mETHOD_SPECIATION_NAME))
                {
                    a.MethodSpeciationName = mETHOD_SPECIATION_NAME.Trim().SubStringPlus(0, 20);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MethodSpeciation", mETHOD_SPECIATION_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Method Speciation not valid. "; }
                }

                if (!string.IsNullOrEmpty(rESULT_SAMP_FRACTION))
                {
                    a.ResultSampFraction = rESULT_SAMP_FRACTION.Trim().SubStringPlus(0, 25);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultSampleFraction", rESULT_SAMP_FRACTION.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Sample Fraction not valid. "; }
                }
                else
                {
                    if (_refCharRepo.GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(cHAR_NAME.Trim()) == true) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Fraction must be reported."; }
                }

                if (!string.IsNullOrEmpty(rESULT_MSR))
                {
                    a.ResultMsr = rESULT_MSR.Trim().SubStringPlus(0, 60).Replace(",", "");
                }
                else
                {
                    if (string.IsNullOrEmpty(rESULT_DETECT_CONDITION)) { sTATUS_CD = "F"; sTATUS_DESC += "Either Result Measure or Result Detection Condition must be reported."; }
                }

                if (!string.IsNullOrEmpty(rESULT_MSR_UNIT))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", rESULT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Measurement Unit not valid. "; }
                    a.ResultMsrUnit = rESULT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(rESULT_MSR_QUAL))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultMeasureQualifier", rESULT_MSR_QUAL.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Measurement Qualifier not valid. "; }
                    a.ResultMsrQual = rESULT_MSR_QUAL.Trim().SubStringPlus(0, 5);
                }

                if (!string.IsNullOrEmpty(rESULT_STATUS))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultStatus", rESULT_STATUS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Status not valid. "; }
                    a.ResultStatus = rESULT_STATUS.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(sTATISTIC_BASE_CODE))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("StatisticalBase", sTATISTIC_BASE_CODE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Statistic Base Code not valid. "; }
                    a.StatisticBaseCode = sTATISTIC_BASE_CODE.Trim().SubStringPlus(0, 25);
                }

                if (!string.IsNullOrEmpty(rESULT_VALUE_TYPE))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultValueType", rESULT_VALUE_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Value Type not valid. "; }
                    a.ResultValueType = rESULT_VALUE_TYPE.Trim().SubStringPlus(0, 20);
                }

                if (!string.IsNullOrEmpty(wEIGHT_BASIS))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultWeightBasis", wEIGHT_BASIS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Weight Basis not valid. "; }
                    a.WeightBasis = wEIGHT_BASIS.Trim().SubStringPlus(0, 15);
                }

                if (!string.IsNullOrEmpty(tIME_BASIS))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultTimeBasis", tIME_BASIS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Time Basis not valid. "; }
                    a.TimeBasis = tIME_BASIS.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(tEMP_BASIS))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("ResultTemperatureBasis", tEMP_BASIS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Temp Basis not valid. "; }
                    a.TempBasis = tEMP_BASIS.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(pARTICAL_BASIS))
                    a.ParticlesizeBasis = pARTICAL_BASIS.Trim().SubStringPlus(0, 40);

                if (!string.IsNullOrEmpty(pRECISION_VALUE))
                    a.PrecisionValue = pRECISION_VALUE.Trim().SubStringPlus(0, 60);

                if (!string.IsNullOrEmpty(bIAS_VALUE))
                    a.BiasValue = bIAS_VALUE.Trim().SubStringPlus(0, 60);

                if (!string.IsNullOrEmpty(cONFIDENCE_INTERVAL_VALUE))
                    a.ConfidenceIntervalValue = cONFIDENCE_INTERVAL_VALUE.Trim().SubStringPlus(0, 15);

                if (!string.IsNullOrEmpty(uP_CONFIDENCE_LIMIT))
                    a.UpperConfidenceLimit = uP_CONFIDENCE_LIMIT.Trim().SubStringPlus(0, 15);

                if (!string.IsNullOrEmpty(lOW_CONFIDENCE_LIMIT))
                    a.LowerConfidenceLimit = lOW_CONFIDENCE_LIMIT.Trim().SubStringPlus(0, 15);

                if (!string.IsNullOrEmpty(rESULT_COMMENT))
                    a.ResultComment = rESULT_COMMENT.Trim().SubStringPlus(0, 4000);

                if (!string.IsNullOrEmpty(dEPTH_HEIGHT_MSR))
                    a.DepthHeightMsr = dEPTH_HEIGHT_MSR.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(dEPTH_HEIGHT_MSR_UNIT))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", dEPTH_HEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Depth Unit not valid. "; }
                    a.DepthHeightMsrUnit = dEPTH_HEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(dEPTHALTITUDEREFPOINT))
                    a.Depthaltituderefpoint = dEPTHALTITUDEREFPOINT.Trim().SubStringPlus(0, 125);


                if (BioIndicator == true)
                {

                    if (!string.IsNullOrEmpty(bIO_INTENT_NAME))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("BiologicalIntent", bIO_INTENT_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Biological Intent not valid. "; }
                        a.BioIntentName = bIO_INTENT_NAME.Trim().SubStringPlus(0, 35);

                        if (string.IsNullOrEmpty(bIO_SUBJECT_TAXONOMY)) { sTATUS_CD = "F"; sTATUS_DESC += "Taxonomy must be reported when intent is reported. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_INDIVIDUAL_ID))
                        a.BioIndividualId = bIO_INDIVIDUAL_ID.Trim().SubStringPlus(0, 4);

                    if (!string.IsNullOrEmpty(bIO_SUBJECT_TAXONOMY))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("Taxon", bIO_SUBJECT_TAXONOMY.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Subject Taxonomy not valid. "; }
                        a.BioSubjectTaxonomy = bIO_SUBJECT_TAXONOMY.Trim().SubStringPlus(0, 120);

                        if (string.IsNullOrEmpty(bIO_INTENT_NAME)) { sTATUS_CD = "F"; sTATUS_DESC += "Biological intent must be reported when taxonomy is reported. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_UNIDENTIFIED_SPECIES_ID))
                        a.BioUnidentifiedSpeciesId = bIO_UNIDENTIFIED_SPECIES_ID.Trim().SubStringPlus(0, 120);

                    if (!string.IsNullOrEmpty(bIO_SAMPLE_TISSUE_ANATOMY))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("SampleTissueAnatomy", bIO_SAMPLE_TISSUE_ANATOMY.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Tissue Anatomy not valid. "; }
                        a.BioSampleTissueAnatomy = bIO_SAMPLE_TISSUE_ANATOMY.Trim().SubStringPlus(0, 30);
                    }

                    if (!string.IsNullOrEmpty(gRP_SUMM_COUNT_WEIGHT_MSR))
                        a.GrpSummCountWeightMsr = gRP_SUMM_COUNT_WEIGHT_MSR.Trim().SubStringPlus(0, 12);

                    if (!string.IsNullOrEmpty(gRP_SUMM_COUNT_WEIGHT_MSR_UNIT))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", gRP_SUMM_COUNT_WEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Group Summary Unit not valid. "; }
                        a.GrpSummCountWeightMsrUnit = gRP_SUMM_COUNT_WEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_CELL_FORM))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("CellForm", tAX_DTL_CELL_FORM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Cell Form not valid. "; }
                        a.TaxDtlCellForm = tAX_DTL_CELL_FORM.Trim().SubStringPlus(0, 11);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_CELL_SHAPE))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("CellShape", tAX_DTL_CELL_SHAPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Cell Shape not valid. "; }
                        a.TaxDtlCellShape = tAX_DTL_CELL_SHAPE.Trim().SubStringPlus(0, 18);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_HABIT))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("Habit", tAX_DTL_HABIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Habit not valid. "; }
                        a.TaxDtlHabit = tAX_DTL_HABIT.Trim().SubStringPlus(0, 15);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_VOLTINISM))
                    {
                        if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("Voltinism", tAX_DTL_VOLTINISM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Voltinism not valid. "; }
                        a.TaxDtlVoltinism = tAX_DTL_VOLTINISM.Trim().SubStringPlus(0, 25);
                    }


                    if (!string.IsNullOrEmpty(tAX_DTL_POLL_TOLERANCE))
                        a.TaxDtlPollTolerance = tAX_DTL_POLL_TOLERANCE.Trim().SubStringPlus(0, 4);


                    if (!string.IsNullOrEmpty(tAX_DTL_POLL_TOLERANCE_SCALE))
                        a.TaxDtlPollToleranceScale = tAX_DTL_POLL_TOLERANCE_SCALE.Trim().SubStringPlus(0, 50);

                    if (!string.IsNullOrEmpty(tAX_DTL_TROPHIC_LEVEL))
                        a.TaxDtlTrophicLevel = tAX_DTL_TROPHIC_LEVEL.Trim().SubStringPlus(0, 4);

                    if (!string.IsNullOrEmpty(tAX_DTL_FUNC_FEEDING_GROUP1))
                        a.TaxDtlFuncFeedingGroup1 = tAX_DTL_FUNC_FEEDING_GROUP1.Trim().SubStringPlus(0, 6);

                    if (!string.IsNullOrEmpty(tAX_DTL_FUNC_FEEDING_GROUP2))
                        a.TaxDtlFuncFeedingGroup2 = tAX_DTL_FUNC_FEEDING_GROUP2.Trim().SubStringPlus(0, 6);

                    if (!string.IsNullOrEmpty(tAX_DTL_FUNC_FEEDING_GROUP3))
                        a.TaxDtlFuncFeedingGroup3 = tAX_DTL_FUNC_FEEDING_GROUP3.Trim().SubStringPlus(0, 6);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_CODE))
                        a.FreqClassCode = fREQ_CLASS_CODE.Trim().SubStringPlus(0, 50);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_UNIT))
                        a.FreqClassUnit = fREQ_CLASS_UNIT.Trim().SubStringPlus(0, 12);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_CODE))
                        a.FreqClassUpper = fREQ_CLASS_UPPER.Trim().SubStringPlus(0, 8);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_CODE))
                        a.FreqClassLower = fREQ_CLASS_LOWER.Trim().SubStringPlus(0, 8);

                }


                //analysis method
                //first populate the IDX if it is supplied
                if (aNALYTIC_METHOD_IDX != null)
                    a.AnalyticMethodIdx = aNALYTIC_METHOD_IDX;
                else
                {
                    //if ID is supplied but Context is not, set context to org id 
                    if (!string.IsNullOrEmpty(aNALYTIC_METHOD_ID) && string.IsNullOrEmpty(aNALYTIC_METHOD_CTX))
                        aNALYTIC_METHOD_CTX = orgID;

                    //if we now have values for the ID and context
                    if (!string.IsNullOrEmpty(aNALYTIC_METHOD_ID) && !string.IsNullOrEmpty(aNALYTIC_METHOD_CTX))
                    {
                        //see if matching collection method exists
                        TWqxRefAnalMethod am = _refDataRepo.GetT_WQX_REF_ANAL_METHODByIDandContext(aNALYTIC_METHOD_ID.Trim(), aNALYTIC_METHOD_CTX.Trim());
                        if (am != null)
                            a.AnalyticMethodIdx = am.AnalyticMethodIdx;
                        else  //no matching anal method lookup found                            
                        {
                            if (autoImportRefDataInd == true)
                            {
                                _refDataRepo.InsertOrUpdateT_WQX_REF_ANAL_METHOD(null, aNALYTIC_METHOD_ID.Trim(), aNALYTIC_METHOD_CTX.Trim(), aNALYTIC_METHOD_NAME.Trim(), "", true);
                            }
                            else
                            { sTATUS_CD = "F"; sTATUS_DESC += "No matching Analysis Method found - please add it at the Reference Data screen first. "; }
                        }

                        //****************************************
                        a.AnalyticMethodId = aNALYTIC_METHOD_ID.Trim().SubStringPlus(0, 20);
                        a.AnalyticMethodCtx = aNALYTIC_METHOD_CTX.Trim().SubStringPlus(0, 120);

                        if (!string.IsNullOrEmpty(aNALYTIC_METHOD_NAME))
                            a.AnalyticMethodName = aNALYTIC_METHOD_NAME.Trim().SubStringPlus(0, 120);
                    }
                    else
                    {
                        //if IDX, ID, and Context not supplied, lookup the method from the default Org Char reference list
                        TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, cHAR_NAME.Trim().SubStringPlus(0, 120));
                        if (rco != null)
                        {
                            a.AnalyticMethodIdx = rco.DefaultAnalMethodIdx;
                            if (rco.DefaultAnalMethodIdx != null)
                            {
                                TWqxRefAnalMethod anal = _refAnalMethodRepo.GetT_WQX_REF_ANAL_METHODByIDX(rco.DefaultAnalMethodIdx.ConvertOrDefault<int>());
                                if (anal != null)
                                {
                                    a.AnalyticMethodId = anal.AnalyticMethodId;
                                    a.AnalyticMethodName = anal.AnalyticMethodName;
                                    a.AnalyticMethodCtx = anal.AnalyticMethodCtx;
                                }
                            }
                        }

                    }
                }

                //********** LABORATORY **********
                if (lAB_IDX != null)
                    a.LabIdx = lAB_IDX;
                else
                {
                    if (!string.IsNullOrEmpty(lAB_NAME))
                    {
                        a.LabName = lAB_NAME;

                        //see if matching lab name exists for this org
                        TWqxRefLab lab = _refLabRepo.GetT_WQX_REF_LAB_ByIDandContext(lAB_NAME, orgID);
                        if (lab == null)
                        {
                            if (autoImportRefDataInd == true)
                            {
                                _refDataRepo.InsertOrUpdateT_WQX_REF_LAB(null, lAB_NAME.Trim(), null, null, orgID, true);
                            }
                            else { sTATUS_CD = "F"; sTATUS_DESC += "No matching Lab Name found - please add it at the Reference Data screen first. "; }
                        }
                        else
                            a.LabIdx = lab.LabIdx;
                    }
                }


                if (lAB_ANALYSIS_START_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_ANALYSIS_START_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_ANALYSIS_START_DT = null;

                    a.LabAnalysisStartDt = lAB_ANALYSIS_START_DT;
                }
                if (lAB_ANALYSIS_END_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_ANALYSIS_END_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_ANALYSIS_END_DT = null;

                    a.LabAnalysisEndDt = lAB_ANALYSIS_END_DT;
                }


                if (!string.IsNullOrEmpty(lAB_ANALYSIS_TIMEZONE))
                {
                    a.LabAnalysisTimezone = lAB_ANALYSIS_TIMEZONE.Trim().SubStringPlus(0, 4);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("TimeZone", lAB_ANALYSIS_TIMEZONE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "TimeZone not valid. "; }
                }
                else
                {
                    //put in Timezone if missing
                    if (lAB_ANALYSIS_START_DT != null || lAB_ANALYSIS_END_DT != null)
                        a.LabAnalysisTimezone = Utils.GetWQXTimeZoneByDate(a.LabAnalysisTimezone.ConvertOrDefault<DateTime>(), orgID);
                }

                if (!string.IsNullOrEmpty(rESULT_LAB_COMMENT_CODE))
                    a.ResultLabCommentCode = rESULT_LAB_COMMENT_CODE.Trim().SubStringPlus(0, 3);

                if (!string.IsNullOrEmpty(mETHOD_DETECTION_LEVEL))
                    a.MethodDetectionLevel = mETHOD_DETECTION_LEVEL.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(lAB_REPORTING_LEVEL))
                    a.LabReportingLevel = lAB_REPORTING_LEVEL.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(pQL))
                    a.Pql = pQL.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(lOWER_QUANT_LIMIT))
                    a.LowerQuantLimit = lOWER_QUANT_LIMIT.Trim().SubStringPlus(0, 12);

                //if result is PBQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (rESULT_DETECT_CONDITION == "Present Below Quantification Limit" && string.IsNullOrEmpty(mETHOD_DETECTION_LEVEL) && string.IsNullOrEmpty(lAB_REPORTING_LEVEL) && string.IsNullOrEmpty(pQL) && string.IsNullOrEmpty(lOWER_QUANT_LIMIT))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, cHAR_NAME);
                    if (rco != null)
                        a.LowerQuantLimit = rco.DefaultLowerQuantLimit;

                    //if still null, then error
                    if (a.LowerQuantLimit == null)
                    { sTATUS_CD = "F"; sTATUS_DESC += "No Lower Quantification limit reported or default value specified. "; }
                }

                if (!string.IsNullOrEmpty(uPPER_QUANT_LIMIT))
                    a.UpperQuantLimit = uPPER_QUANT_LIMIT.Trim().SubStringPlus(0, 12);

                //if result is PAQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (rESULT_DETECT_CONDITION == "Present Above Quantification Limit" && string.IsNullOrEmpty(mETHOD_DETECTION_LEVEL) && string.IsNullOrEmpty(lAB_REPORTING_LEVEL) && string.IsNullOrEmpty(pQL) && string.IsNullOrEmpty(uPPER_QUANT_LIMIT))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, cHAR_NAME);
                    if (rco != null)
                        a.UpperQuantLimit = rco.DefaultUpperQuantLimit;

                    //if still null, then error
                    if (a.UpperQuantLimit == null)
                    { sTATUS_CD = "F"; sTATUS_DESC += "No Upper Quantification limit reported. "; }
                }

                if (!string.IsNullOrEmpty(dETECTION_LIMIT_UNIT))
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", dETECTION_LIMIT_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Detection Level Unit not valid. "; }
                    a.DetectionLimitUnit = dETECTION_LIMIT_UNIT.Trim().SubStringPlus(0, 12);
                }


                //********** LAB SAMPLE PREP
                if (lAB_SAMP_PREP_IDX != null)
                    a.LabSampPrepIdx = lAB_SAMP_PREP_IDX;
                else
                {
                    if (!string.IsNullOrEmpty(lAB_SAMP_PREP_ID))
                    {
                        //set context to org id if none is provided 
                        if (string.IsNullOrEmpty(lAB_SAMP_PREP_CTX))
                            lAB_SAMP_PREP_CTX = orgID;

                        a.LabSampPrepId = lAB_SAMP_PREP_ID.Trim().SubStringPlus(0, 20);
                        a.LabSampPrepCtx = lAB_SAMP_PREP_CTX.Trim().SubStringPlus(0, 120);

                        //see if matching lab prep method exists for this org
                        TWqxRefSampPrep ppp = _refSampPrepRepo.GetT_WQX_REF_SAMP_PREP_ByIDandContext(lAB_SAMP_PREP_ID, lAB_SAMP_PREP_CTX);
                        if (ppp == null) //no match found
                        {
                            if (autoImportRefDataInd == true)
                            {
                                _refDataRepo.InsertOrUpdateT_WQX_REF_SAMP_PREP(null, lAB_SAMP_PREP_ID.Trim(), lAB_SAMP_PREP_CTX.Trim(), lAB_SAMP_PREP_ID.Trim(), "", true);
                            }
                            else
                            { sTATUS_CD = "F"; sTATUS_DESC += "No matching Lab Sample Prep ID found - please add it at the Reference Data screen first. "; }
                        }
                        else  //match found
                            a.LabSampPrepIdx = ppp.SampPrepIdx;

                    }
                }

                if (lAB_SAMP_PREP_START_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_SAMP_PREP_START_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_SAMP_PREP_START_DT = null;

                    a.LabSampPrepStartDt = lAB_SAMP_PREP_START_DT;
                }

                if (lAB_SAMP_PREP_END_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_SAMP_PREP_END_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_SAMP_PREP_END_DT = null;

                    a.LabSampPrepEndDt = lAB_SAMP_PREP_END_DT;
                }

                if (!string.IsNullOrEmpty(dILUTION_FACTOR))
                    a.DilutionFactor = dILUTION_FACTOR.Trim().SubStringPlus(0, 12);


                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                    _db.TWqxImportTempResult.Add(a);

                _db.SaveChanges();

                return a.TempResultIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertWQX_IMPORT_TEMP_RESULT_New(int tempSampleIdx, Dictionary<string, string> colVals, string orgID, string configFilePath)
        {
            try
            {
                TWqxImportTempResult a = new TWqxImportTempResult();

                a.TempSampleIdx = tempSampleIdx;
                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                //get import config rules
                List<ConfigInfoType> _allRules = Utils.GetAllColumnInfo("S", configFilePath);

                //******************* PRE VALIDATION *************************************
                //special rule: set values of ND, etc
                string _rdc = Utils.GetValueOrDefault(colVals, "ResultDetectCondition");
                string _res = Utils.GetValueOrDefault(colVals, "ResultMsr");
                if (_rdc == "DNQ" || _res == "DNQ") { colVals["ResultDetectCondition"] = "Detected Not Quantified"; colVals["ResultMsr"] = "DNQ"; }
                if (_rdc == "ND" || _res == "ND") { colVals["ResultDetectCondition"] = "Not Detected"; colVals["ResultMsr"] = "ND"; }
                if (_rdc == "NR" || _res == "NR") { colVals["ResultDetectCondition"] = "Not Reported"; colVals["ResultMsr"] = "NR"; }
                if (_rdc == "PAQL" || _res == "PAQL") { colVals["ResultDetectCondition"] = "Present Above Quantification Limit"; colVals["ResultMsr"] = "PAQL"; }
                if (_rdc == "PBQL" || _res == "PBQL") { colVals["ResultDetectCondition"] = "Present Below Quantification Limit"; colVals["ResultMsr"] = "PBQL"; }
                // ******************* END PRE VALIDATION *********************************


                //******************* DEFAULT VALIDATION *************************************
                List<string> rFields = new List<string>(new string[] { "DataLoggerLine","ResultDetectCondition","CharName", "MethodSpeciationName",
                        "ResultSampFraction", "ResultMsr","ResultMsrUnit","ResultMsrQual","ResultStatus","StaticBaseCode","ResultValueType","WeightBasis",
                        "TimeBasis","TempBasis","ParticlesizeBasis","PrecisionValue","BiasValue","ConfidenceIntervalValue","UpperConfidenceLimit","LowerConfidenceLimit",
                            "ResultComment","DepthHeightMsr","DepthHeightMsrUnit","DepthLatitudeRefPoint","BioIntentName","BioIndividualId","BioSubjectTaxonomy",
                            "BioUnidentifiedSpeciesId","BioSampleTissueAnatomy","GrpSummCountWeightMsr","GrpSummCountWeightMsrUnit","TaxDtlCellForm",
                            "TaxDtlCellShape","TaxDtlHabit","TaxDtlVoltinism","TaxDtlPollTolerance","TaxDtlPollToleranceScale","TaxDtlTrophicLevel",
                            "TaxDtlFuncFeedingGroup1","TaxDtlFuncFeedingGroup2","TaxDtlFuncFeedingGroup3","FreqClassCode","FreqClassUnit","FreqClassUpper",
                            "FreqCassLower","AnalyticMethodIdx","AnalyticMethodId","AnalyticMethodCtx","LabName","LabAnalysisStartDt","LabAnalysisEndDt",
                            "ResultLabCommentCode","MethodDetectionLevel","LabReportingLevel","Pql","LowerQuantLimit","UpperQuantLimit","DetectionLimitUnit",
                            "LabSampPrepIdx","LabSampPrepId","LabSampPrepCtx","LabSampPrepStartDt","LabSampPrepEndDt","DilutionFactor" });

                foreach (KeyValuePair<string, string> entry in colVals)
                    if (rFields.Contains(entry.Key))
                        WQX_IMPORT_TEMP_RESULT_GenVal(ref a, _allRules, colVals, entry.Key);
                //******************* END DEFAULT VALIDATION *************************************


                //******************* POST CUSTOM VALIDATION *************************************
                if (!string.IsNullOrEmpty(a.CharName))
                    if (_refCharRepo.GetT_WQX_REF_CHARACTERISTIC_ExistCheck(a.CharName) == false) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Characteristic Name not valid. "; }

                //Sample Fraction handling
                if (string.IsNullOrEmpty(a.ResultSampFraction) && !string.IsNullOrEmpty(a.CharName))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultSampFraction = (string.IsNullOrEmpty(rco.DefaultSampFraction) ? null : rco.DefaultSampFraction);
                }
                if (_refCharRepo.GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(a.CharName) == true && string.IsNullOrEmpty(a.ResultSampFraction)) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Sample Fraction must be reported."; }


                //Result Status handling
                if (string.IsNullOrEmpty(a.ResultStatus) && !string.IsNullOrEmpty(a.CharName))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultStatus = (string.IsNullOrEmpty(rco.DefaultResultStatus) ? null : rco.DefaultResultStatus);
                }


                //Result Value Type handling
                if (string.IsNullOrEmpty(a.ResultValueType) && !string.IsNullOrEmpty(a.CharName))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultValueType = (string.IsNullOrEmpty(rco.DefaultResultValueType) ? null : rco.DefaultResultValueType);
                }


                if (!string.IsNullOrEmpty(a.ResultMsr))
                    a.ResultMsr = a.ResultMsr.Replace(",", "");
                else
                    if (string.IsNullOrEmpty(a.ResultDetectCondition))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Either Result Measure or Result Detection Condition must be reported."; }

                //if result is reported, but no unit is reported, grab unit from REF_CHAR_ORG default
                if (!string.IsNullOrEmpty(a.ResultMsr) && string.IsNullOrEmpty(a.ResultMsrUnit))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultMsrUnit = rco.DefaultUnit;
                }

                //if result is ND, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (a.ResultDetectCondition == "Not Detected" && string.IsNullOrEmpty(a.MethodDetectionLevel) && string.IsNullOrEmpty(a.LabReportingLevel) && string.IsNullOrEmpty(a.Pql) && string.IsNullOrEmpty(a.UpperQuantLimit))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.DetectionLimitUnit = (string.IsNullOrEmpty(rco.DefaultDetectLimit) ? null : rco.DefaultDetectLimit);

                    //if still null, then error
                    if (a.DetectionLimitUnit == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No Upper Quantification limit or default value reported. "; }
                }


                //if result is PBQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from REF_CHAR_ORG default
                if (a.ResultDetectCondition == "Present Below Quantification Limit" && string.IsNullOrEmpty(a.MethodDetectionLevel) && string.IsNullOrEmpty(a.LabReportingLevel) && string.IsNullOrEmpty(a.Pql) && string.IsNullOrEmpty(a.LowerQuantLimit))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.LowerQuantLimit = (string.IsNullOrEmpty(rco.DefaultLowerQuantLimit) ? null : rco.DefaultLowerQuantLimit);

                    //if still null, then error
                    if (a.LowerQuantLimit == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No Lower Quantification limit or default value specified. "; }
                }

                //if result is PAQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (a.ResultDetectCondition == "Present Above Quantification Limit" && string.IsNullOrEmpty(a.MethodDetectionLevel) && string.IsNullOrEmpty(a.LabReportingLevel) && string.IsNullOrEmpty(a.Pql) && string.IsNullOrEmpty(a.UpperQuantLimit))
                {
                    TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.UpperQuantLimit = (string.IsNullOrEmpty(rco.DefaultUpperQuantLimit) ? null : rco.DefaultUpperQuantLimit); ;

                    //if still null, then error
                    if (a.UpperQuantLimit == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No Upper Quantification limit or default value reported. "; }
                }



                if (string.IsNullOrEmpty(a.BioIntentName) != string.IsNullOrEmpty(a.BioSubjectTaxonomy))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Taxonomy must be reported when bio intent is reported. "; }


                //analysis method
                if (a.AnalyticMethodIdx == null)
                {
                    //if ID is supplied but Context is not, set context to org id 
                    if (!string.IsNullOrEmpty(a.AnalyticMethodId) && string.IsNullOrEmpty(a.AnalyticMethodCtx))
                        a.AnalyticMethodCtx = orgID;

                    //if we now have values for the ID and context
                    if (!string.IsNullOrEmpty(a.AnalyticMethodId) && !string.IsNullOrEmpty(a.AnalyticMethodCtx))
                    {
                        //see if matching collection method exists
                        TWqxRefAnalMethod am = _refDataRepo.GetT_WQX_REF_ANAL_METHODByIDandContext(a.AnalyticMethodId, a.AnalyticMethodCtx);
                        if (am != null)
                            a.AnalyticMethodIdx = am.AnalyticMethodIdx;
                        else  //no matching anal method lookup found                            
                        { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Analysis Method found - please add it at the Reference Data screen first. "; }
                    }
                    else
                    {
                        //if IDX, ID, and Context not supplied, lookup the method from the default Org Char reference list
                        TWqxRefCharOrg rco = _refDataRepo.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                        if (rco != null)
                        {
                            a.AnalyticMethodIdx = rco.DefaultAnalMethodIdx;
                            if (rco.DefaultAnalMethodIdx != null)
                            {
                                TWqxRefAnalMethod anal = _refAnalMethodRepo.GetT_WQX_REF_ANAL_METHODByIDX(rco.DefaultAnalMethodIdx.ConvertOrDefault<int>());
                                if (anal != null)
                                {
                                    a.AnalyticMethodId = anal.AnalyticMethodId;
                                    a.AnalyticMethodName = anal.AnalyticMethodName;
                                    a.AnalyticMethodCtx = anal.AnalyticMethodCtx;
                                }
                            }
                        }
                    }
                }



                if (!string.IsNullOrEmpty(a.LabName))
                {
                    TWqxRefLab lab = _refLabRepo.GetT_WQX_REF_LAB_ByIDandContext(a.LabName, orgID);
                    if (lab != null)
                        a.LabIdx = lab.LabIdx;
                    else
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Lab Name found - please add it at the Reference Data screen first. "; }
                }


                //put in Timezone if missing
                if (a.LabAnalysisStartDt != null || a.LabAnalysisEndDt != null)
                    a.LabAnalysisTimezone = Utils.GetWQXTimeZoneByDate(a.LabAnalysisStartDt.ConvertOrDefault<DateTime>(), orgID);


                //********** LAB SAMPLE PREP*************************
                if (a.LabSampPrepIdx == null && !string.IsNullOrEmpty(a.LabSampPrepId))
                {
                    //set context to org id if none is provided 
                    if (string.IsNullOrEmpty(a.LabSampPrepCtx))
                        a.LabSampPrepCtx = orgID;

                    //see if matching lab prep method exists for this org
                    TWqxRefSampPrep ppp = _refSampPrepRepo.GetT_WQX_REF_SAMP_PREP_ByIDandContext(a.LabSampPrepId, a.LabSampPrepCtx);
                    if (ppp != null)
                        a.LabSampPrepIdx = ppp.SampPrepIdx;
                    else
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Lab Sample Prep ID found - please add it at the Reference Data screen first. "; }
                }


                a.ImportStatusDesc = a.ImportStatusDesc.SubStringPlus(0, 200);
                _db.TWqxImportTempResult.Add(a);
                _db.SaveChanges();

                return a.TempResultIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxImportTempResult wqxImportTempResult)
        {
            throw new NotImplementedException();
        }

        public void WQX_IMPORT_TEMP_RESULT_GenVal(ref TWqxImportTempResult a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            var _rules = t.Find(item => item._name == f);   //import validation rules for this field
            if (_rules == null)
                return;

            string _value = Utils.GetValueOrDefault(colVals, f); //supplied value for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //if this field has another field which gets added to it (used for Date + Time fields)
                if (!string.IsNullOrEmpty(_rules._addfield))
                    _value = _value + " " + Utils.GetValueOrDefault(colVals, _rules._addfield);

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
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value);
                else if (_rules._datatype == "int")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
                else if (_rules._datatype == "datetime" && _rules._req == "Y")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime>());
                else if (_rules._datatype == "datetime" && _rules._req == "N")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime?>());
            }
            catch { }
        }
    }
}
