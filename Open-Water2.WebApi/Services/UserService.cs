using com.sun.org.apache.xml.@internal.serializer.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Open_Water2.WebApi.Entities;
using Open_Water2.WebApi.Helpers;
using OpenWater2.DataAccess.Data;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        public UserService(IOptions<AppSettings> appSettings, 
            [FromServices]IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }
        public User Authenticate(string username, string password)
        {
            //var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            var dbUser = _unitOfWork.oeUsersRepostory.GetFirstOrDefault(x => x.Email == username);
            if (dbUser == null)
                return null;
            bool isValid = new CustomMembership(_unitOfWork).ValidateUser(username, password);
            if (isValid == false)
                return null;

            User data = new User()
            {
                FirstName = dbUser.Fname,
                UserName = username,
                Password = password,
                LastName = dbUser.Lname,
                Id = dbUser.UserIdx
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SessionVars sessionVars = OpewnWater2.DataAccess.Utils.GetPostLoginUser(dbUser.UserId, _unitOfWork);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("userIdx", dbUser.UserIdx.ToString()),
                    new Claim("name", dbUser.Fname),
                    new Claim("picture", @"https://ui-avatars.com/api/?size=32"),
                    new Claim("UserIDX",sessionVars.UserIDX),
                    new Claim("OrgID",sessionVars.OrgID),
                    new Claim("MLOC_HUC_EIGHT",sessionVars.MLOC_HUC_EIGHT.ToString()),
                    new Claim("MLOC_HUC_TWELVE",sessionVars.MLOC_HUC_TWELVE.ToString()),
                    new Claim("MLOC_TRIBAL_LAND",sessionVars.MLOC_TRIBAL_LAND.ToString()),
                    new Claim("MLOC_SOURCE_MAP_SCALE",sessionVars.MLOC_SOURCE_MAP_SCALE.ToString()),
                    new Claim("MLOC_HORIZ_COLL_METHOD",sessionVars.MLOC_HORIZ_COLL_METHOD.ToString()),
                    new Claim("MLOC_HORIZ_REF_DATUM",sessionVars.MLOC_HORIZ_REF_DATUM.ToString()),
                    new Claim("MLOC_VERT_MEASURE",sessionVars.MLOC_VERT_MEASURE.ToString()),
                    new Claim("MLOC_COUNTRY_CODE",sessionVars.MLOC_COUNTRY_CODE.ToString()),
                    new Claim("MLOC_STATE_CODE",sessionVars.MLOC_STATE_CODE.ToString()),
                    new Claim("MLOC_COUNTY_CODE",sessionVars.MLOC_COUNTY_CODE.ToString()),
                    new Claim("MLOC_WELL_DATA",sessionVars.MLOC_WELL_DATA.ToString()),
                    new Claim("MLOC_WELL_TYPE",sessionVars.MLOC_WELL_TYPE.ToString()),
                    new Claim("MLOC_AQUIFER_NAME",sessionVars.MLOC_AQUIFER_NAME.ToString()),
                    new Claim("MLOC_FORMATION_TYPE",sessionVars.MLOC_FORMATION_TYPE.ToString()),
                    new Claim("MLOC_WELLHOLE_DEPTH",sessionVars.MLOC_WELLHOLE_DEPTH.ToString()),
                    new Claim("PROJ_SAMP_DESIGN_TYPE_CD",sessionVars.PROJ_SAMP_DESIGN_TYPE_CD.ToString()),
                    new Claim("PROJ_QAPP_APPROVAL",sessionVars.PROJ_QAPP_APPROVAL.ToString()),
                    new Claim("SAMP_ACT_END_DT",sessionVars.SAMP_ACT_END_DT.ToString()),
                    new Claim("SAMP_COLL_METHOD",sessionVars.SAMP_COLL_METHOD.ToString()),
                    new Claim("SAMP_COLL_EQUIP",sessionVars.SAMP_COLL_EQUIP.ToString()),
                    new Claim("SAMP_PREP",sessionVars.SAMP_PREP.ToString()),
                    new Claim("SAMP_DEPTH",sessionVars.SAMP_DEPTH.ToString()),
    }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "Issuer",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            data.token = tokenHandler.WriteToken(token);
            //data.Session = OpewnWater2.DataAccess.Utils.GetPostLoginUser(dbUser.UserId, _unitOfWork);
            return data.WithoutPassword();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
