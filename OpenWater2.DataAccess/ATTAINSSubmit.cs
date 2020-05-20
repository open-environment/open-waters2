using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Services.Protocols;
//using OpenEnvironment.net.epacdxnode.test;
using System.Threading;
using System.IO;
using Ionic.Zip;
using System.Xml.Linq;
using OpenWater2.DataAccess.Data;
using OpenWater2.Models.Model;

namespace OpwnWater2.DataAccess
{

    public class ATTAINSSubmit
    {
        private static ApplicationDbContext _db;
        /// <summary>
        /// will be called by windows service to loop through all unsubmitted ATTAIN reports
        /// </summary>
        public static void ATTAINS_Master(ApplicationDbContext db)
        {
            _db = db;
        }

        public static void ATTAINS_byReport(int ReportIDX)
        {
            //get OrgID for the report 

            TAttainsReport r = db_Attains.GetT_ATTAINS_REPORT_byID(ReportIDX);
            if (r != null)
            {
                //get CDX username, password, and CDX destination URL
                CDXCredentials cred = WQXSubmit.GetCDXSubmitCredentials2(r.OrgId);

                //*******AUTHENTICATE*********************************************************************************************************
                string token = WQXSubmit.AuthHelper(cred.userID, cred.credential, "Password", "default", cred.NodeURL);

                //*******SUBMIT***************************************************************************************************************
                string requestXml = db_Attains.SP_GenATTAINSXML(ReportIDX);   //get XML from DB stored procedure
                byte[] bytes = Utils.StrToByteArray(requestXml);
                if (bytes == null) return;

                NetworkNode2.StatusResponseType subStatus = WQXSubmit.SubmitHelper(cred.NodeURL, token, "ATTAINS", "default", bytes, "submit.xml", NetworkNode2.DocumentFormatType.XML, "1");
                if (subStatus != null)
                {
                    //*******GET STATUS********************************************************************************************************
                    string status = "";
                    int i = 0;
                    do
                    {
                        i += 1;
                        Thread.Sleep(10000);
                        NetworkNode2.StatusResponseType gsResp = WQXSubmit.GetStatusHelper(cred.NodeURL, token, subStatus.transactionId);
                        if (gsResp != null)
                        {
                            status = gsResp.status.ToString();
                            //exit if waiting too long
                            if (i > 30)
                            {
                                //UpdateRecordStatus(typeText, RecordIDX, "N");
                                //db_Ref.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, "Timed out while getting status from EPA", subStatus.transactionId, "Failed", orgID);
                                return;
                            }
                        }
                    } while (status != "Failed" && status != "Completed");


                }

            }
        }
    }

}