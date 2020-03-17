using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;

namespace Open_Water2.WebApi.Controllers
{
    
    public class TWQXOrganizationController : Controller
    {
        IUnitOfWork _unitOfWork;
        [HttpGet]
        [Route("api/org/getall")]
        public JsonResult GetAll([FromServices]IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            return Json(_unitOfWork.wqxOrganizationRepository.GetAll());
        }
    }
}