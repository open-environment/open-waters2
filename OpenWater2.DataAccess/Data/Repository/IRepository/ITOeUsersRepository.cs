using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITOeUsersRepository : IRepository<TOeUsers>
    {
        IEnumerable<SelectListItem> GetTOeUsersForDropDown();
        void Update(TOeUsers oeUsers);
        public TOeUsers GetT_OE_USERSByID(string id);
        public TOeUsers GetT_OE_USERSByIDX(int userIdx);
        List<TOeUsers> GetUserByRole(int RoleID);
        public int UpdateT_OE_USERS(int idx, string newPWD_HASH, string newPWD_SALT, string newFNAME, string newLNAME, string newEMAIL, bool? newACT_IND, bool? newINIT_PWD_FLG, DateTime? newEFF_DATE, DateTime? newLAST_LOGIN_DT, string newPHONE, string newPHONE_EXT, string newMODIFY_USR);
        public TOeUsers GetT_VCCB_USERByEmail(string email);
    }
}
