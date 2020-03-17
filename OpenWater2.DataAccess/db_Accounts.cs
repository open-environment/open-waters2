using Microsoft.AspNetCore.Http;
using OpenWater2.DataAccess.Data;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpwnWater2.DataAccess
{
    public class db_Accounts
    {
        private static ApplicationDbContext _db;

        public db_Accounts(ApplicationDbContext db)
        {
            _db = db;
        }
        //*****************USERS **********************************
        public static int CreateT_OE_USERS(global::System.String uSER_ID, global::System.String pWD_HASH, global::System.String pWD_SALT, global::System.String fNAME, global::System.String lNAME, global::System.String eMAIL, global::System.Boolean aCT_IND, global::System.Boolean iNITAL_PWD_FLAG, global::System.DateTime? lASTLOGIN_DT, global::System.String pHONE, global::System.String pHONE_EXT, global::System.String cREATE_USER)
        {
            try
            {
                TOeUsers u = new TOeUsers();
                u.UserId = uSER_ID;
                u.PwdHash = pWD_HASH;
                u.PwdSalt = pWD_SALT;
                u.Fname = fNAME;
                u.Lname = lNAME;
                u.Email = eMAIL;
                u.ActInd = aCT_IND;
                u.InitalPwdFlag = iNITAL_PWD_FLAG;
                u.EffectiveDt = System.DateTime.Now;
                u.LastloginDt = lASTLOGIN_DT;
                u.Phone = pHONE;
                u.PhoneExt = pHONE_EXT;
                u.CreateDt = System.DateTime.Now;
                u.CreateUserid = cREATE_USER;

                _db.TOeUsers.Add(u);
                _db.SaveChanges();
                return u.UserIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TOeUsers> GetT_OE_USERS()
        {
            try
            {
                return _db.TOeUsers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TOeUsers GetT_OE_USERSByIDX(int idx)
        {
            try
            {
                return _db.TOeUsers.FirstOrDefault(usr => usr.UserIdx == idx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TOeUsers GetT_OE_USERSByID(string id)
        {
            try
            {
                return _db.TOeUsers.FirstOrDefault(usr => usr.UserId.ToUpper() == id.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TOeUsers GetT_VCCB_USERByEmail(string email)
        {
            try
            {
                return _db.TOeUsers.FirstOrDefault(usr => usr.Email.ToUpper() == email.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateT_OE_USERS(int idx, string newPWD_HASH, string newPWD_SALT, string newFNAME, string newLNAME, string newEMAIL, bool? newACT_IND, bool? newINIT_PWD_FLG, DateTime? newEFF_DATE, DateTime? newLAST_LOGIN_DT, string newPHONE, string newPHONE_EXT, string newMODIFY_USR)
        {
            try
            {
                TOeUsers row = new TOeUsers();
                row = (from c in _db.TOeUsers where c.UserIdx == idx select c).First();

                if (newPWD_HASH != null)
                    row.PwdHash = newPWD_HASH;

                if (newPWD_SALT != null)
                    row.PwdSalt = newPWD_SALT;

                if (newFNAME != null)
                    row.Fname = newFNAME;

                if (newLNAME != null)
                    row.Lname = newLNAME;

                if (newEMAIL != null)
                    row.Email = newEMAIL;

                if (newACT_IND != null)
                    row.ActInd = (bool)newACT_IND;

                if (newINIT_PWD_FLG != null)
                    row.InitalPwdFlag = (bool)newINIT_PWD_FLG;

                if (newEFF_DATE != null)
                    row.EffectiveDt = (DateTime)newEFF_DATE;

                if (newLAST_LOGIN_DT != null)
                    row.LastloginDt = (DateTime)newLAST_LOGIN_DT;

                if (newPHONE != null)
                    row.Phone = newPHONE;

                if (newPHONE_EXT != null)
                    row.PhoneExt = newPHONE_EXT;

                if (newMODIFY_USR != null)
                    row.ModifyUserid = newMODIFY_USR;

                row.ModifyDt = System.DateTime.Now;
                _db.TOeUsers.Update(row);
                _db.SaveChanges();
                return row.UserIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_OE_USERS(int idx)
        {
            try
            {
                TOeUsers row = new TOeUsers();
                row = (from c in _db.TOeUsers where c.UserIdx == idx select c).First();
                _db.TOeUsers.Remove(row);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int UpdateT_OE_USERSDefaultOrg(int idx, string dEFAULT_ORG_ID)
        {
            try
            {
                TOeUsers row = new TOeUsers();
                row = (from c in _db.TOeUsers where c.UserIdx == idx select c).First();
                if (dEFAULT_ORG_ID != null) row.DefaultOrgId = dEFAULT_ORG_ID;
                _db.TOeUsers.Update(row);
                _db.SaveChanges();
                return row.UserIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void SetOrgSessionID(string UserID, string url)
        {
            TOeUsers u = GetT_OE_USERSByID(UserID);
            if (u != null)
            {
                if (u.DefaultOrgId == null)
                {
                    List<TWqxOrganization> os = db_WQX.GetWQX_USER_ORGS_ByUserIDX(u.UserIdx, false);
                    //if user only belongs to 1 org, update the default org id
                    if (os.Count == 1)
                    {
                        UpdateT_OE_USERSDefaultOrg(u.UserIdx, os[0].OrgId);
                        HttpContext.Current.Session["OrgID"] = os[0].OrgId;
                    }
                    else if (os.Count > 1)
                        HttpContext.Current.Response.Redirect("~/App_Pages/Secure/SetOrg.aspx?ReturnUrl=" + url);
                    else if (os.Count == 0)
                        HttpContext.Current.Response.Redirect("~/App_Pages/Secure/WQXOrgNew.aspx");

                }
                else
                    HttpContext.Current.Session["OrgID"] = u.DefaultOrgId;

            }
        }

        //*****************ROLES **********************************
        public static int CreateT_OE_ROLES(global::System.String rOLE_NAME, global::System.String rOLE_DESC, global::System.String cREATE_USER = "system")
        {
            try
            {
                TOeRoles r = new TOeRoles();
                r.RoleName = rOLE_NAME;
                r.RoleDesc = rOLE_DESC;
                r.CreateDt = System.DateTime.Now;
                r.CreateUserid = cREATE_USER;

                _db.TOeRoles.Add(r);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static TOeRoles GetT_VCCB_ROLEByName(string rolename)
        {
            try
            {
                return _db.TOeRoles.FirstOrDefault(role => role.RoleName.ToUpper() == rolename.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TOeRoles GetT_VCCB_ROLEByIDX(int idx)
        {
            try
            {
                return _db.TOeRoles.FirstOrDefault(role => role.RoleIdx == idx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateT_VCCB_ROLE(int idx, string newROLE_NAME, string newROLE_DESC, string newMODIFY_USR)
        {
            try
            {
                TOeRoles row = new TOeRoles();
                row = (from c in _db.TOeRoles where c.RoleIdx == idx select c).First();

                if (newROLE_NAME != null)
                    row.RoleName = newROLE_NAME;

                if (newROLE_DESC != null)
                    row.RoleDesc = newROLE_DESC;

                if (newMODIFY_USR != null)
                    row.ModifyUserid = newMODIFY_USR;

                row.ModifyDt = System.DateTime.Now;
                _db.TOeRoles.Update(row);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_VCCB_ROLE(int idx)
        {
            try
            {
                TOeRoles row = new TOeRoles();
                row = (from c in _db.TOeRoles where c.RoleIdx == idx select c).First();
                _db.TOeRoles.Remove(row);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //*****************ROLE / USER RELATIONSHIP **********************************
        public static List<TOeUsers> GetT_OE_USERSInRole(int roleID)
        {
            try
            {
                var users = from itemA in _db.TOeUsers
                            join itemB in _db.TOeUserRoles on itemA.UserIdx equals itemB.UserIdx
                            where itemB.RoleIdx == roleID
                            orderby itemA.UserId
                            select itemA;

                return users.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TOeUsers> GetT_OE_USERSNotInRole(int roleID)
        {
            try
            {
                //first get all users 
                var allUsers = (from itemA in _db.TOeUsers select itemA);

                //next get all users in role
                var UsersInRole = (from itemA in _db.TOeUsers
                                   join itemB in _db.TOeUserRoles on itemA.UserIdx equals itemB.UserIdx
                                   where itemB.RoleIdx == roleID
                                   select itemA);

                //then get exclusions
                var usersNotInRole = allUsers.Except(UsersInRole);

                return usersNotInRole.OrderBy(a => a.UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TOeRoles> GetT_OE_ROLESInUser(int userIDX)
        {
            try
            {
                var roles = from itemA in _db.TOeRoles
                            join itemB in _db.TOeUserRoles on itemA.RoleIdx equals itemB.RoleIdx
                            where itemB.UserIdx == userIDX
                            select itemA;

                return roles.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CreateT_VCCB_USER_ROLE(global::System.Int32 rOLE_IDX, global::System.Int32 uSER_IDX, global::System.String cREATE_USER = "system")
        {
            try
            {

                TOeUserRoles ur = new TOeUserRoles();
                ur.RoleIdx = rOLE_IDX;
                ur.UserIdx = uSER_IDX;
                ur.CreateDt = System.DateTime.Now;
                ur.CreateUserid = cREATE_USER;
                _db.TOeUserRoles.Add(ur);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_VCCB_USER_ROLE(int UserIDX, int RoleIDX)
        {
            try
            {

                TOeUserRoles row = new TOeUserRoles();
                row = (from c in _db.TOeUserRoles
                       where c.RoleIdx == RoleIDX && c.UserIdx == UserIDX
                       select c).FirstOrDefault();
                _db.TOeUserRoles.Remove(row);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }







    }
}