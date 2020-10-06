using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;

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

    }
}
