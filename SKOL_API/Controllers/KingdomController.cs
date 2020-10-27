using Microsoft.AspNet.Identity;
using SKOL.Data;
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
    public class KingdomController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateKingdom(KingdomCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateKingdomService();
            if(!service.CreateKingdom(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetKingdoms()
        {
            var service = CreateKingdomService();
            var kingdoms = service.GetKingdoms();
            return Ok(kingdoms);
        }
        private KingdomService CreateKingdomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new KingdomService(userId);
            return service;
            
        }
    }
}
