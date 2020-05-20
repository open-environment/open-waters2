using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Open_Water2.WebApi.Entities;
using Open_Water2.WebApi.Helpers;
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

        public UserService(IOptions<AppSettings> appSettings, [FromServices]IUnitOfWork unitOfWork)
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

            User user = new User()
            {
                FirstName = dbUser.Fname,
                UserName = username,
                Password = password,
                LastName = dbUser.Lname,
                Id = dbUser.UserIdx
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, dbUser.UserIdx.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "Issuer",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user.WithoutPassword();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
