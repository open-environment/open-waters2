using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Open_Water2.WebApi.Controllers
{
 
    [ApiController]
    public class TWQXAdminController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public TWQXAdminController(IUnitOfWork unitOfWork,
            IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        // GET api/admin/getAppSettings
        [Route("api/admin/getAppSettings")]
        [HttpGet]
        public IActionResult getAppSettings()
        {
            var result = _unitOfWork.oeAppSettingsRepository.GetAll();
            return Ok(result);
        }
        // PUT api/admin/updateAppSetting
        [Route("api/admin/updateAppSetting")]
        [HttpPut]
        public IActionResult updateAppSetting([FromBody] TOeAppSettings appSettings)
        {
            try
            {
                _unitOfWork.oeAppSettingsRepository.Update(appSettings);
                return Ok("Data Saved");
            }
            catch (Exception)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpGet]
        [Route("api/admin/downloadFile")]
        public async Task<IActionResult> DownloadFile([FromQuery] string fileName)
        {
            var appDocs = Path.Combine(_env.WebRootPath, "App_Docs");
            var filePath = Path.Combine(appDocs, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(filePath), fileName);
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
