using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.sun.tools.doclets.formats.html.markup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Open_Water2.WebApi.Services;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using RestSharp;
using Microsoft.Extensions.Options;
using Open_Water2.WebApi.Helpers;
using Open_Water2.WebApi.Entities;
using Microsoft.AspNetCore.Http;

namespace Open_Water2.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logger;
        IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IUserService userService,
            IWebHostEnvironment env,
            ILoggerFactory logFactory,
            IUnitOfWork unitOfWork,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _env = env;
            _logger = logFactory.CreateLogger<AuthenticationController>();
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("auth/login")]
        public IActionResult login([FromBody] LoginAuthParams loginAuthParams)
        {
            _logger.LogInformation("Login action in OpenWater2 called..");
            
            _logger.LogInformation("clling Authenticate Method..");
            var user = _userService.Authenticate(loginAuthParams.email, loginAuthParams.password);
            if (user == null)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogInformation("User is null..returning error message...");
                return StatusCode(StatusCodes.Status500InternalServerError,new { error = "Invalid username or password." });
            }
            this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            _logger.LogInformation("Returning Ok response..");
            return Ok(new { data = new { token = user.token, session = user.Session } });
        }

        [HttpPost]
        [Route("auth/sign-up")]
        public JsonResult Register([FromQuery] string email, string password, string fullname, string confirmPassword)
        {
            this.HttpContext.Response.StatusCode = 200;
            return new JsonResult(JsonConvert.SerializeObject(new { token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1ODQ5Nzk4NzcsImV4cCI6MTYxNjUxNTg3NywiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.kTv1wYt6KaRRARDMZeDZg4MxTSca5LVwXBqRcHWYAbg" }));
        }

        [HttpPost]
        [Route("auth/request-pass")]
        public StatusCodeResult RequestPassword([FromQuery] string email)
        {
            //this.HttpContext.Response.StatusCode = 200;
            return new StatusCodeResult(200);
        }
        [HttpPost]
        [Route("auth/reset-pass")]
        public StatusCodeResult ResetPassword([FromQuery] string email)
        {
            //this.HttpContext.Response.StatusCode = 200;
            return new StatusCodeResult(200);
        }
        [HttpPost]
        [Route("auth/sign-out")]
        public StatusCodeResult LogOut()
        {
            //this.HttpContext.Response.StatusCode = 200;
            return new StatusCodeResult(204);
        }

        [AllowAnonymous]
        [HttpGet("api/auth/CheckUserAuthentication")]
        public IActionResult CheckUserAuthentication([FromQuery] string payload)
        {
            _logger.LogInformation("CheckUserAuthentication action called..");
            ExtLoginUser actResult = null;
            string pl = System.Web.HttpUtility.UrlDecode(payload);
            _logger.LogInformation("Decoded payload: " + pl);
            byte[] decodedBytes = Convert.FromBase64String(pl);
            string plStr = System.Text.Encoding.Unicode.GetString(decodedBytes);
            _logger.LogInformation("Payload converted from Base64: " + plStr);
            var plParts = plStr.Split("###");
            var userName = plParts[0];
            var encryptedPassword = plParts[1];
            var userid = plParts[2];
            var decreptedPassword = Helpers.HelperUtils.Decrypt(encryptedPassword);
            _logger.LogInformation(String.Format("Payload splitted: [username: {0}] [decreptedPassword:{1}] [userid:{2}] ", userName, decreptedPassword, userid));
            //check if user exist
            TOeUsers user = _unitOfWork.oeUsersRepostory.GetT_VCCB_USERByEmail(userName);
            if (user != null)
            {
                _logger.LogInformation("User with given username found...");
                actResult = new ExtLoginUser
                {
                    userexist = true,
                    username = userName,
                    password = decreptedPassword,
                    useridx = user.UserIdx,
                };
            }
            else
            {
                _logger.LogInformation("User with given username does not exist...");
                actResult = new ExtLoginUser
                {
                    userexist = false,
                    userid = userid,
                };
            }
            _logger.LogInformation("Returning Result...");
            return Ok(actResult);
        }
        [AllowAnonymous]
        [HttpGet("api/auth/CreateAndGetNewUserData")]
        public IActionResult CreateAndGetNewUserData([FromQuery] string userid)
        {
            _logger.LogInformation("CreateAndGetNewUserData action called..");
            ExtLoginUser actResult = new ExtLoginUser();
            actResult.errMsg = "";
            JWTLoginModel jWTLoginModel = new JWTLoginModel();
            var client = new RestClient(_appSettings.SvcPortalGetNewUserData);
            _logger.LogInformation("Endpoint for Rest call from AppSettings:" + _appSettings.SvcPortalGetNewUserData);
            client.Timeout = -1;
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "idsrv.session=7d27a8fcb1930276f0168362f045c486; .AspNetCore.Identity.Application=CfDJ8DeWshj2q_hGqLRov8c3PLudsLh9VeYmhHsejzdQe5QA2hWJO6irenXnvITPdOhl4ubVRE64xocztcvqpLP3WEzJcm_e8j3KcVofZa0TSt6AqOqnibX8RIXWMrprKMmN0q1sRelR4DzYR_slcEWYR-1XshlB4TPGn62Cd6VKejyYCz-yeDSAT0rikAkvJoHWXklKySyyrwUKfEq274ws3xa2EQZku3kXSxfDJkxXoTHABSEYeJzP_jtmk0UQgHm13UK3LNjjB-s9Wj52NmHogIahiusBkECJBndkGsKBPq4ineXwFo8cbZdNgU46w05qJns-OwnDDqcecK8av900MFneOp_q9jtiOMtkuI47aH1C9FB_u5o49xKI5siXw-5de8VfchwoVgKt0WCpopOcKY5r17S1HmDHUl3d-405F96TrwRKlqHPbzentH1MU91kgjfPwW-pRptxR3U2IsTQKW0ggOx5TaRyn99XeW_u2hZQE7trSSI3cdJLZ1XZBbrf_2fQH9QAai1ah7TOvJ3-7GNFibEz-iWnXW6jaNpdgLzwME7QVUiIWBydJl5p35swTKpD2Rb4UElfljT5-Qh7OV4JVrRk3EFM5d9-iBLBNB81BVnLB5x7GV6LqyF_T1feoeCd1ll2I_zsrYzdQawe2qgAe3bMNTOad85alvFdj4h93R6BWFouREe7VPQKXy586sNveiWk4oqYtA1cYZhaXaHmiqhrvtIvCcrlBvhMQZyLh7riwWDPSCXUyMO9MN1w8_Nlf2VnbOesxQr86Qi0LzexrQNuLviA6GgZJwOcI-eXGq1-lm8X284yGEyc1NqvFi00LdIRyF41yKZ3OH171Q37ydy40RxhYVZX44xNrjifz71iQKuIAiMRHM3-xYeZBmi08atOPgTYtrTRWmEoKkt7byn-8kEAqvr8zMenUF8GmB3KldsBVaBitqTUy62_v3GUVc4aR2oeGlBxonhpe1YL9NI0gYKP2-iDZSzm888n0LOSrQulwf8NXQVSVsLNlPPYX8-LahlFye4LQ2vZdn0");
            request.AddParameter("userid", userid, ParameterType.QueryString);
            _logger.LogInformation("Calling rest client...");
            IRestResponse response = client.Execute(request);
            _logger.LogInformation("Rest client called...");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation("Rest client returned with success...");
                jWTLoginModel = JsonConvert.DeserializeObject<JWTLoginModel>(response.Content);
                _logger.LogInformation("Returned conent converted to object...");
                string role = "user";
                if (jWTLoginModel.orgUsers[0].STATUS_IND == "1") role = "admin";
                _logger.LogInformation("Decide role of user:" + role);
                MembershipCreateStatus status;
                CustomMembership c = new CustomMembership(_unitOfWork);
                _logger.LogInformation("Creating new user...");
                User u = c.ExtCreateUser(Helpers.HelperUtils.RandomString(24), "", jWTLoginModel.email, jWTLoginModel.firstName, jWTLoginModel.lastName, role, null, null, true, null, out status);
                if (status == MembershipCreateStatus.Success)
                {
                    _logger.LogInformation("New user created...");
                    _logger.LogInformation("Sync organizations...");
                    foreach (var orgUser in jWTLoginModel.orgUsers)
                    {
                        TWqxOrganization o = _unitOfWork.wqxOrganizationRepository.GetWQX_ORGANIZATION_ByID(orgUser.ORG_ID);
                        if (o == null)
                        {
                            int isOrgAdded = _unitOfWork.wqxOrganizationRepository.InsertOrUpdateT_WQX_ORGANIZATION(orgUser.ORG_ID, orgUser.ORG_NAME);
                            if (isOrgAdded == 1)
                            {
                                _logger.LogInformation("New organization added..." + orgUser.ORG_NAME);

                                //Add User-Org relation
                                //Get all organizations for the user
                                List<TWqxOrganization> orgs = _unitOfWork.UserOrgsRepository.GetWQX_USER_ORGS_ByUserIDX(u.UserIdx == null ? 0 : (int)u.UserIdx, false);
                                //Check if current organization is in the list
                                var org = orgs.Where(o => o.OrgId == orgUser.ORG_ID).FirstOrDefault();
                                if (org == null)
                                {
                                    //If not, add new organization relation
                                    _unitOfWork.UserOrgsRepository.InsertT_WQX_USER_ORGS(orgUser.ORG_ID, u.UserIdx == null ? 0 : (int)u.UserIdx, "U");
                                    _logger.LogInformation("User-Organization relation is added...");
                                }
                            }
                        }
                    }
                    if (jWTLoginModel.orgUsers.Count > 0)
                    {
                        _logger.LogInformation("Set default organization...");
                        var DefaultOrgId = jWTLoginModel.orgUsers[0].ORG_ID;
                        var _user = _unitOfWork.oeUsersRepostory.GetT_OE_USERSByIDX(u.UserIdx == null ? 0 : (int)u.UserIdx);
                        if (u != null)
                        {
                            _user.DefaultOrgId = DefaultOrgId;
                            _unitOfWork.oeUsersRepostory.Update(_user);
                        }
                    }
                    // Setup data to return
                    actResult.userexist = true;
                    actResult.useridx = u.UserIdx == null ? 0 : (int)u.UserIdx;
                    actResult.username = jWTLoginModel.email;
                    actResult.password = jWTLoginModel.password;
                }
                _logger.LogInformation("Returning ok result...");
                return Ok(actResult);
            }
            _logger.LogInformation("Something went wrong...User sync failed...");
            actResult.errMsg = "User sync failed...";
            return Ok(actResult);
        }
        public class LoginAuthParams
        {
            public string email { get; set; }
            public string password { get; set; }
            public string username { get; set; }
        }
        public class ExtLoginUser
        {
            public bool userexist { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public int useridx { get; set; }
            public string userid { get; set; }
            public string errMsg { get; set; }
        }
    }
}