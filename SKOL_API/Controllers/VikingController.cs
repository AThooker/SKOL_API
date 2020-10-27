using Microsoft.AspNet.Identity;
using SKOL.Models;
using SKOL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SKOL_API.Controllers
{
    public class VikingController : ApiController
    {
        //Read
        [HttpGet]
        public IHttpActionResult GetVikings()
        {
            var service = CreateVikingService();
            var vikings = service.GetVikings();
            return Ok(vikings);
        }
        [HttpDelete]
        public IHttpActionResult DeleteViking(int id)
        {
            var service = CreateVikingService();
            if(!service.DeleteViking(id))
            {
                return InternalServerError();
            }
            return Ok("Viking Deleted");
        }
        //Create Service
        private VikingService CreateVikingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VikingService(userId);
            return service;
        }

    }
}
