using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;

namespace Open_Water2.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class TWQXOrganizationController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TWQXOrganizationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("api/org/getall")]
        //public JsonResult GetAll([FromServices]IUnitOfWork unitOfWork)
        public JsonResult GetAll()
        {
            //_unitOfWork = unitOfWork;
            return Json(_unitOfWork.wqxOrganizationRepository.GetAll());
        }

        [HttpPost]
        [Route("api/org/getUserOrgsByUserIDX")]
        public JsonResult GetWQX_USER_ORGS_ByUserIDX([FromQuery]int UserIDX, bool excludePendingInd)
        {
            return Json(_unitOfWork.wqxOrganizationRepository.GetWQX_USER_ORGS_ByUserIDX(UserIDX, excludePendingInd));
        }

        [HttpGet]
        [Route("api/org/getnothing")]
        public JsonResult GetNothing()
        {
            return Json("{'returnValue':'nothing'}");
        }
    }
}