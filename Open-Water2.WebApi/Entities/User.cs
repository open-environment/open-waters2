using OpenWater2.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi.Entities
{
    public class User
    {
        public User()
        {
            if (Session == null) Session = new SessionVars();
        }
        public User(string firstName, 
            string lastName, 
            string userName, 
            string password, 
            string token,
            int? userIdx)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            this.token = token;
            UserIdx = userIdx;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string token { get; set; }
        public int? UserIdx { get; set; }
        public SessionVars Session { get; set; }
    }
}
