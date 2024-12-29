using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileDAL;
using MobileDAL.Models;
using System;
using System.Collections.Generic;

namespace MobilesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MobilesController : Controller
    {
        MobileRepository repository;

        public MobilesController()
        {
            repository = new MobileRepository();
        }


        [HttpGet]
        public JsonResult GetAllMobiles()
        {
            List<Mobile> mobiles = new List<Mobile>();
            try
            {
                mobiles = repository.GetAll();
            }
            catch (Exception ex)
            {
                mobiles = null;
            }
            return Json(mobiles);
        }

        [HttpGet]
        public JsonResult GetMobilebyid(int id) { 
          Mobile mobile = null;
            try
            {
                mobile = repository.GetMobilebyId(id);
            }
            catch (Exception ex)
            {
                mobile = null;
            }
            return Json(mobile);

        }


        [HttpPost]
        public JsonResult DeleteMobile(string name)
        {
            bool status = false;
            try
            {
                status = repository.DeleteMobile(name);
            }
            catch (Exception ex) {
                status = false;
            }

            return Json(status);
        }

        [HttpPost]

        public JsonResult AddMobile(Mobile mobile) {
            bool status = false;
            try
            {
                status = repository.AddMobile(mobile);
            }
            catch (Exception ex)
            {
                status = false;
            }

            return Json(status);



        }
        [HttpPut]
        public JsonResult UpdateMobile(Mobile mobile)
        {
            bool status = false;
            try
            {
                status = repository.UpdateMobile(mobile);
            }
            catch (Exception ex)
            {
                status = false;
            }

            return Json(status);

        }
    }
}
