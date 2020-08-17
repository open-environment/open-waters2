using com.sun.org.apache.xml.@internal.serializer.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Open_Water2.WebApi.Entities;
using Open_Water2.WebApi.Helpers;
using OpenWater2.DataAccess.Data;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using OpenWater2.Models.Model;

namespace Open_Water2.WebApi.Services
{
    public class UserService : IUserService
    {
        //private List<User> _users = new List<User>
        //{
        //    new User
        //    {
        //         Id=1,
        //         FirstName="test",
        //         LastName="user",
        //         UserName="kshitij@appletechconsultants.com",
        //         Password="pwd"
        //    }
        //};

        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logger;
        public UserService(IOptions<AppSettings> appSettings, 
            [FromServices]IUnitOfWork unitOfWork,
            IWebHostEnvironment env,
            ILoggerFactory logFactory)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _env = env;
            _logger = logFactory.CreateLogger<UserService>();
        }
        public User Authenticate(string username, string password)
        {
            _logger.LogInformation("Authenticate in OpenWater2 called..");
            User data = new User();
            try
            {
                var client = new RestClient(_appSettings.SvcPortalJWTLoginEndPoint);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", "idsrv.session=7d27a8fcb1930276f0168362f045c486; .AspNetCore.Identity.Application=CfDJ8DeWshj2q_hGqLRov8c3PLudsLh9VeYmhHsejzdQe5QA2hWJO6irenXnvITPdOhl4ubVRE64xocztcvqpLP3WEzJcm_e8j3KcVofZa0TSt6AqOqnibX8RIXWMrprKMmN0q1sRelR4DzYR_slcEWYR-1XshlB4TPGn62Cd6VKejyYCz-yeDSAT0rikAkvJoHWXklKySyyrwUKfEq274ws3xa2EQZku3kXSxfDJkxXoTHABSEYeJzP_jtmk0UQgHm13UK3LNjjB-s9Wj52NmHogIahiusBkECJBndkGsKBPq4ineXwFo8cbZdNgU46w05qJns-OwnDDqcecK8av900MFneOp_q9jtiOMtkuI47aH1C9FB_u5o49xKI5siXw-5de8VfchwoVgKt0WCpopOcKY5r17S1HmDHUl3d-405F96TrwRKlqHPbzentH1MU91kgjfPwW-pRptxR3U2IsTQKW0ggOx5TaRyn99XeW_u2hZQE7trSSI3cdJLZ1XZBbrf_2fQH9QAai1ah7TOvJ3-7GNFibEz-iWnXW6jaNpdgLzwME7QVUiIWBydJl5p35swTKpD2Rb4UElfljT5-Qh7OV4JVrRk3EFM5d9-iBLBNB81BVnLB5x7GV6LqyF_T1feoeCd1ll2I_zsrYzdQawe2qgAe3bMNTOad85alvFdj4h93R6BWFouREe7VPQKXy586sNveiWk4oqYtA1cYZhaXaHmiqhrvtIvCcrlBvhMQZyLh7riwWDPSCXUyMO9MN1w8_Nlf2VnbOesxQr86Qi0LzexrQNuLviA6GgZJwOcI-eXGq1-lm8X284yGEyc1NqvFi00LdIRyF41yKZ3OH171Q37ydy40RxhYVZX44xNrjifz71iQKuIAiMRHM3-xYeZBmi08atOPgTYtrTRWmEoKkt7byn-8kEAqvr8zMenUF8GmB3KldsBVaBitqTUy62_v3GUVc4aR2oeGlBxonhpe1YL9NI0gYKP2-iDZSzm888n0LOSrQulwf8NXQVSVsLNlPPYX8-LahlFye4LQ2vZdn0");
                request.AddParameter("application/json", "{\r\n    \"email\": \"" + username + "\",\r\n    \"password\": \"" + HelperUtils.Encrypt(password) + "\",\r\n    \"rememberMe\": false\r\n}", ParameterType.RequestBody);
                _logger.LogInformation("Calling rest client...");
                IRestResponse response = client.Execute(request);
                _logger.LogInformation("Rest client called...");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _logger.LogInformation("Response return OK...");
                    _logger.LogInformation("1...");
                    var dbUser = JsonConvert.DeserializeObject<JWTLoginModel>(response.Content);
                    //var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);
                    /*var dbUser = _unitOfWork.oeUsersRepostory.GetFirstOrDefault(x => x.Email == username);
                    if (dbUser == null)
                        return null;
                    bool isValid = new CustomMembership(_unitOfWork).ValidateUser(username, password);
                    if (isValid == false)
                        return null;*/
                    TOeUsers user = _unitOfWork.oeUsersRepostory.GetT_VCCB_USERByEmail(username);
                    data = new User()
                    {
                        FirstName = dbUser.firstName,
                        UserName = username,
                        Password = password,
                        LastName = dbUser.lastName,
                        Id = user.UserIdx,
                        UserIdx = user.UserIdx,
                    };
                    
                    _logger.LogInformation("2...");
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    bool isAddSessionVars = true;
                    bool isAddOrgId = true;
                    
                    _logger.LogInformation("3...");
                    //SessionVars sessionVars = OpewnWater2.DataAccess.Utils.GetPostLoginUserByUserIdx(dbUser.openWaterUserIdx, _unitOfWork, _env, _logger);
                    SessionVars sessionVars = OpewnWater2.DataAccess.Utils.GetPostLoginUserByUserIdx(user.UserIdx, _unitOfWork, _env, _logger);
                    //SessionVars sessionVars = OpewnWater2.DataAccess.Utils.GetPostLoginUser(dbUser.UserId, _unitOfWork);
                    if (sessionVars == null) isAddSessionVars = false;
                    var orgDisplayType = dbUser.orgUsers.Where(ou => ou.ORG_ID == sessionVars.OrgID).FirstOrDefault();
                    if (orgDisplayType == null) isAddOrgId = false;
                    var tokenDescriptor = new SecurityTokenDescriptor();
                    System.Security.Claims.ClaimsIdentity Subject = new System.Security.Claims.ClaimsIdentity();
                    
                    _logger.LogInformation("4...");
                    Claim[] claims = new Claim[27];
                    claims[0] = new Claim("userIdx", user.UserIdx.ToString());
                    claims[1] = new Claim("name", dbUser.firstName);
                    claims[2] = new Claim("picture", @"https://ui-avatars.com/api/?size=32");
                    if (isAddSessionVars == true)
                    {
                        _logger.LogInformation("5...");
                        claims.Append(new Claim("UserIDX", user.UserIdx.ToString()));
                        if (isAddOrgId == true)
                        {
                            _logger.LogInformation("6...");
                            claims[3] = new Claim("OrgID", sessionVars.OrgID);
                        }
                        else
                        {
                            _logger.LogInformation("7...");
                            claims[3] = new Claim("OrgID", "-1");
                        }
                        _logger.LogInformation("8...");
                        claims[4] = new Claim("MLOC_HUC_EIGHT", sessionVars.MLOC_HUC_EIGHT.ToString());
                        claims[5] = new Claim("MLOC_HUC_TWELVE", sessionVars.MLOC_HUC_TWELVE.ToString());
                        claims[6] = new Claim("MLOC_TRIBAL_LAND", sessionVars.MLOC_TRIBAL_LAND.ToString());
                        claims[7] = new Claim("MLOC_SOURCE_MAP_SCALE", sessionVars.MLOC_SOURCE_MAP_SCALE.ToString());
                        claims[8] = new Claim("MLOC_HORIZ_COLL_METHOD", sessionVars.MLOC_HORIZ_COLL_METHOD.ToString());
                        claims[9] = new Claim("MLOC_HORIZ_REF_DATUM", sessionVars.MLOC_HORIZ_REF_DATUM.ToString());
                        claims[10] = new Claim("MLOC_VERT_MEASURE", sessionVars.MLOC_VERT_MEASURE.ToString());
                        claims[11] = new Claim("MLOC_COUNTRY_CODE", sessionVars.MLOC_COUNTRY_CODE.ToString());
                        claims[12] = new Claim("MLOC_STATE_CODE", sessionVars.MLOC_STATE_CODE.ToString());
                        claims[13] = new Claim("MLOC_COUNTY_CODE", sessionVars.MLOC_COUNTY_CODE.ToString());
                        claims[14] = new Claim("MLOC_WELL_DATA", sessionVars.MLOC_WELL_DATA.ToString());
                        claims[15] = new Claim("MLOC_WELL_TYPE", sessionVars.MLOC_WELL_TYPE.ToString());
                        claims[16] = new Claim("MLOC_AQUIFER_NAME", sessionVars.MLOC_AQUIFER_NAME.ToString());
                        claims[17] = new Claim("MLOC_FORMATION_TYPE", sessionVars.MLOC_FORMATION_TYPE.ToString());
                        claims[18] = new Claim("MLOC_WELLHOLE_DEPTH", sessionVars.MLOC_WELLHOLE_DEPTH.ToString());
                        claims[19] = new Claim("PROJ_SAMP_DESIGN_TYPE_CD", sessionVars.PROJ_SAMP_DESIGN_TYPE_CD.ToString());
                        claims[20] = new Claim("PROJ_QAPP_APPROVAL", sessionVars.PROJ_QAPP_APPROVAL.ToString());
                        claims[21] = new Claim("SAMP_ACT_END_DT", sessionVars.SAMP_ACT_END_DT.ToString());
                        claims[22] = new Claim("SAMP_COLL_METHOD", sessionVars.SAMP_COLL_METHOD.ToString());
                        claims[23] = new Claim("SAMP_COLL_EQUIP", sessionVars.SAMP_COLL_EQUIP.ToString());
                        claims[24] = new Claim("SAMP_PREP", sessionVars.SAMP_PREP.ToString());
                        claims[25] = new Claim("SAMP_DEPTH", sessionVars.SAMP_DEPTH.ToString());
                        claims[26] = new Claim("sessionVars", JsonConvert.SerializeObject(sessionVars));
                    }
                    _logger.LogInformation("9...");
                    Subject.AddClaims(claims);
                    tokenDescriptor.Subject = Subject;
                    tokenDescriptor.Expires = DateTime.UtcNow.AddDays(7);
                    tokenDescriptor.Issuer = "Issuer";
                    tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
                    _logger.LogInformation("10...");
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    _logger.LogInformation("11...");
                    data.token = tokenHandler.WriteToken(token);                   
                    _logger.LogInformation("returning data with token..." + data.token);
                    //data.Session = OpewnWater2.DataAccess.Utils.GetPostLoginUser(dbUser.UserId, _unitOfWork);
                    return data.WithoutPassword();
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.StackTrace.ToString());
                throw ex;
            }
            _logger.LogInformation("Returning null...");
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
