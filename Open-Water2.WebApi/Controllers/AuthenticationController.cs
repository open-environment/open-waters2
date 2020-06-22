using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.sun.tools.doclets.formats.html.markup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Open_Water2.WebApi.Services;

namespace Open_Water2.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("auth/login")]
        //public IActionResult login([FromQuery]LoginAuthParams loginAuthParams)
        public IActionResult login([FromBody]LoginAuthParams loginAuthParams)
        {
            var user = _userService.Authenticate(loginAuthParams.email, loginAuthParams.password);
            if(user == null)
            {
                return new JsonResult(JsonConvert.SerializeObject(new { error = "Invalid username or password." }));
            }
            this.HttpContext.Response.StatusCode = 200;

            return Ok(new { data = new { token = user.token, session = user.Session } });
            
        }

        [HttpPost]
        [Route("auth/sign-up")]
        public JsonResult Register([FromQuery]string email, string password, string fullname, string confirmPassword)
        {
            this.HttpContext.Response.StatusCode = 200;
            return new JsonResult(JsonConvert.SerializeObject(new { token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1ODQ5Nzk4NzcsImV4cCI6MTYxNjUxNTg3NywiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.kTv1wYt6KaRRARDMZeDZg4MxTSca5LVwXBqRcHWYAbg" }));
        }

        [HttpPost]
        [Route("auth/request-pass")]
        public StatusCodeResult RequestPassword([FromQuery]string email)
        {
            //this.HttpContext.Response.StatusCode = 200;
            return new StatusCodeResult(200);
        }
        [HttpPost]
        [Route("auth/reset-pass")]
        public StatusCodeResult ResetPassword([FromQuery]string email)
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
        public class LoginAuthParams
        {
            public string email { get; set; }
            public string password { get; set; }
            public string username { get; set; }
        }
    }
}