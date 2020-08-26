using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempMonlocRepository : IRepository<TWqxImportTempMonloc>
    {
        
        public List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(int UserIdx);
        public List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(string UserID);
        public int DeleteT_WQX_IMPORT_TEMP_MONLOC(string userId);
        public int InsertWQX_IMPORT_TEMP_MONLOC_New(string userID, string oRG_ID, Dictionary<string, string> colVals, string configFilePath);
        public void WQX_IMPORT_TEMP_MONLOC_GenVal(ref TWqxImportTempMonloc a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f);
        public TWqxImportTempMonloc GetWQX_IMPORT_TEMP_MONLOC_ByID(int TempMonLocID);
        public int ProcessImportTempMonloc(Boolean wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx);
        public int CancelProcessImportTempMonloc(Boolean wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx);
        void Update(TWqxImportTempMonloc wqxImportTempMonloc);
    }
}
