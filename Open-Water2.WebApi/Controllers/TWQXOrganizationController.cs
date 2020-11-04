using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;


namespace Open_Water2.WebApi.Controllers
{
    [Authorize(Policy = "ApiReader")]
    [ApiController]
    public class TWQXOrganizationController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TWQXOrganizationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("api/org/getall")]
        //public JsonResult GetAll([FromServices]IUnitOfWork unitOfWork)
        public JsonResult GetAll()
        {
            //_unitOfWork = unitOfWork;
            return Json(_unitOfWork.wqxOrganizationRepository.GetAll());
        }

        [HttpGet("api/org/getUserOrgsByUserIDX")]
        public IActionResult GetWQX_USER_ORGS_ByUserIDX([FromQuery]int userIDX, bool excludePendingInd)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetWQX_USER_ORGS_ByUserIDX(userIDX, excludePendingInd);
            return Ok(result);
        }
        [HttpGet("api/org/getWQXOrganization")]
        public IActionResult GetWQX_ORGANIZATION()
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetWQX_ORGANIZATION();
            return Ok(result);
        }
        [HttpGet("api/org/getVWQXAllOrgs")]
        public IActionResult GetV_WQX_ALL_ORGS()
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetV_WQX_ALL_ORGS();
            return Ok(result);
        }
        [HttpGet("api/org/GetWQXOrganizationById")]
        public IActionResult GetWQX_ORGANIZATION_ByID(string OrgID)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetWQX_ORGANIZATION_ByID(OrgID);
            return Ok(result);
        }
        [HttpGet("api/org/GetTEPAOrgByOrgId")]
        public IActionResult GetT_EPA_ORGS_ByOrgID(string OrgID)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetT_EPA_ORGS_ByOrgID(OrgID);
            return Ok(result);
        }
        [HttpPost("api/org/InsertOrUpdateTWQXOrganization")]
        public IActionResult InsertOrUpdateT_WQX_ORGANIZATION(string oRG_ID, string oRG_NAME, string oRG_DESC, string tRIBAL_CODE, string eLECTRONIC_ADDRESS,
            string eLECTRONICADDRESSTYPE, string tELEPHONE_NUM, string tELEPHONE_NUM_TYPE, string TELEPHONE_EXT, string cDX_SUBMITTER_ID,
            string cDX_SUBMITTER_PWD, bool? cDX_SUBMIT_IND, string dEFAULT_TIMEZONE, string cREATE_USER = "system", string mAIL_ADDRESS = null,
            string mAIL_ADD_CITY = null, string mAIL_ADD_STATE = null, string mAIL_ADD_ZIP = null)
        {
            if (cDX_SUBMITTER_ID == null)
            {
                cDX_SUBMITTER_ID = "";
                cDX_SUBMITTER_PWD = "--------";
            }
            var result = _unitOfWork.wqxOrganizationRepository.InsertOrUpdateT_WQX_ORGANIZATION(oRG_ID, oRG_NAME, oRG_DESC, tRIBAL_CODE, eLECTRONIC_ADDRESS,
            eLECTRONICADDRESSTYPE, tELEPHONE_NUM, tELEPHONE_NUM_TYPE, TELEPHONE_EXT, cDX_SUBMITTER_ID,
            cDX_SUBMITTER_PWD, cDX_SUBMIT_IND, dEFAULT_TIMEZONE, cREATE_USER, mAIL_ADDRESS,
            mAIL_ADD_CITY, mAIL_ADD_STATE, mAIL_ADD_ZIP);
            return Ok(result);
        }
        [HttpGet("api/org/GetWQXUserOrgsAdminsByOrg")]
        public IActionResult GetWQX_USER_ORGS_AdminsByOrg(string OrgID)
        {
            var result = _unitOfWork.UserOrgsRepository.GetWQX_USER_ORGS_AdminsByOrg(OrgID);
            return Ok(result);
        }
        [HttpPost("api/org/InsertTWQXUserOrgs")]
        public IActionResult InsertT_WQX_USER_ORGS([FromQuery]string oRG_ID, int uSER_IDX, string rOLE_CD, string cREATE_USER = "system")
        {
            var result = _unitOfWork.UserOrgsRepository.InsertT_WQX_USER_ORGS(oRG_ID, uSER_IDX, rOLE_CD, cREATE_USER);
            return Ok(result);
        }
        [HttpPost("api/org/deleteTWqxUserOrgs")]
        public IActionResult DeleteT_WQX_USER_ORGS([FromQuery] string orgId, int userIdx)
        {
            var result = _unitOfWork.wqxOrganizationRepository.DeleteT_WQX_USER_ORGS(orgId, userIdx);
            return Ok(result);
        }
        [HttpGet("api/org/GetAdminTaskData")]
        public IActionResult GetAdminTaskData([FromQuery]int userIdx, string OrgID)
        {
            TOeUsers _user = _unitOfWork.oeUsersRepostory.GetT_OE_USERSByIDX(userIdx);
            if(_user == null)
            {
                return Ok(null);
            }
            bool isAdmin = _unitOfWork.oeUserRolesRepository.IsUserInRole(_user.UserId, "Admin", _user);
            var result = UtilityHelper.GetAdminTaskData(_user.UserId, OrgID, _unitOfWork, _user);
            return Ok(result);
        }


        [HttpGet("api/org/getMyAccountByUserIdx")]
        public IActionResult GetMyAccountByUserIdx([FromQuery] int userIdx)
        {
            MyAccountModel myAccountModel = new MyAccountModel();
            var result = _unitOfWork.oeUsersRepostory.GetT_OE_USERSByIDX(userIdx);
            if (result != null) myAccountModel.user = result;
            var result2 = _unitOfWork.oeUserRolesRepository.GetT_OE_ROLESInUser(userIdx);
            if (result2 != null)
            {
                foreach(TOeRoles role in result2)
                {
                    myAccountModel.roles.Add(role.RoleName);
                }
            }
            var result3 = _unitOfWork.wqxOrganizationRepository.GetWQX_USER_ORGS_ByUserIDX(userIdx, true);
            if (result3 != null)
            {
                foreach(TWqxOrganization org in result3)
                {
                    myAccountModel.organizations.Add(org.OrgFormalName);
                }
            }
            return Ok(myAccountModel);
        }

        [HttpPost("api/org/updateMyAccountUser")]
        public IActionResult UpdateMyAccountUser([FromQuery] int userIdx, string firstName, string lastName, string email, string phone, string userName)
        {
            var result = _unitOfWork.oeUsersRepostory.UpdateT_OE_USERS(userIdx, null, null, firstName, lastName, email, null, null, null, null, phone, null, userName);
            return Ok(result);
        }

        [HttpPost("api/org/ApproveRejectTWqxUserOrgs")]
        public IActionResult ApproveRejectT_WQX_USER_ORGS([FromQuery] string orgID, int userIDX, string ApproveRejectCode)
        {
            var result = _unitOfWork.wqxOrganizationRepository.ApproveRejectT_WQX_USER_ORGS(orgID, userIDX, ApproveRejectCode);
            return Ok(result);
        }
        [HttpGet("api/org/getTWqxRefData")]
        public IActionResult GetT_WQX_REF_DATA([FromQuery] string table, Boolean actInd, Boolean usedInd)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetT_WQX_REF_DATA(table, actInd, usedInd);
            return Ok(result);
        }
        [HttpGet("api/org/getTOeUsersInOrganization")]
        public IActionResult GetT_OE_USERSInOrganization([FromQuery] string orgID)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetT_OE_USERSInOrganization(orgID);
            return Ok(result);
        }
        [HttpGet("api/org/getTOeUsersNotInOrganization")]
        public IActionResult GetT_OE_USERSNotInOrganization([FromQuery] string orgID)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetT_OE_USERSNotInOrganization(orgID);
            return Ok(result);
        }
        [HttpGet("api/org/connectTest")]
        public async Task<IActionResult> ConnectTest([FromQuery] string orgID, string typ)
        {
            var result = await _unitOfWork.wqxOrganizationRepository.ConnectTestAsync(orgID, typ);
            return Ok(result);
        }
        [HttpGet("api/org/GetWqxImportTranslatebyOrg")]
        public IActionResult GetWQX_IMPORT_TRANSLATE_byOrg([FromQuery] string orgID)
        {
            var result = _unitOfWork.wqxOrganizationRepository.GetWQX_IMPORT_TRANSLATE_byOrg(orgID);
            return Ok(result);
        }
        [HttpGet("api/org/canUserEditOrg")]
        public IActionResult CanUserEditOrg([FromQuery] int UserIDX, string OrgID)
        {
            var result = _unitOfWork.wqxOrganizationRepository.CanUserEditOrg(UserIDX, OrgID);
            return Ok(result);
        }
        [HttpGet("api/org/getTEPAOrgsLastUpdateDate")]
        public IActionResult getTEPAOrgsLastUpdateDate()
        {
            var result = _unitOfWork.tEpaOrgsRepository.GetT_EPA_ORGS_LastUpdateDate();
            return Ok(result);
        }
    }
}