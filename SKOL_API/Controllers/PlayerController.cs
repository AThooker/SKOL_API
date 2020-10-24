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
    public class PlayerController : ApiController
    {
        //Create
        [HttpPost]
        public IHttpActionResult CreatePlayer(PlayerCreate model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePlayerService();
            if(!service.CreatePlayer(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //Read
        [HttpGet]
        public IHttpActionResult GetPlayers()
        {
            var service = CreatePlayerService();
            var players = service.GetPlayers();
            return Ok(players);
        }
        private PlayerService CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(userId);
            return service;
        }
    }
}
