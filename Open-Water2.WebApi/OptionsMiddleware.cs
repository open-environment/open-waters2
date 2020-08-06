using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi
{
    public class OptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        public OptionsMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }
        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        private Task BeginInvoke(HttpContext context)
        {
            string msg = DateTime.Now.ToLongTimeString() + " : " + context.Request.Path + ":" + context.Request.Method + Environment.NewLine;
            Helpers.HelperUtils.WriteLog(msg, _env);

            msg = "All Request headers" + Environment.NewLine;
            foreach (var header in context.Request.Headers)
            {
                msg += header.Key + ":" + header.Value + Environment.NewLine;
            }
            Helpers.HelperUtils.WriteLog(msg, _env);

            if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
                context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }
            if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                msg = "Access-Control-Allow-Origin header not found";
                Helpers.HelperUtils.WriteLog(msg, _env);

                Microsoft.Extensions.Primitives.StringValues val;
                if (string.IsNullOrEmpty((string)context.Request.Headers["Origin"]))
                {
                   val  = new[] { "*" };
                }
                else { 
                   val = new[] { (string)context.Request.Headers["Origin"] };
                }
                context.Response.Headers.Add("Access-Control-Allow-Origin", val);
                msg = "Access-Control-Allow-Origin header added";
                Helpers.HelperUtils.WriteLog(msg, _env);
            }
                
            if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Headers"))
                context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Credentials"))
                context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            msg = "All headers" + Environment.NewLine;
            foreach(var header in context.Response.Headers)
            {
                msg += header.Key + ":" + header.Value + Environment.NewLine;
            }
            Helpers.HelperUtils.WriteLog(msg, _env);
            return _next.Invoke(context);
        }
    }

    public static class OptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OptionsMiddleware>();
        }
    }
}

