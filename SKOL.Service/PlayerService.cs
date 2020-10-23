using SKOL.Data;
using SKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Service
{
    public class PlayerService
    {
        ApplicationDbContext ctx = new ApplicationDbContext();
        //private read-only so it can't be altered somewhere else
        private readonly Guid _userId;
        //Constructor for service setting the global ID passed in equal to our field set above
        public PlayerService(Guid userId)
        {
            _userId = userId;
        }
        //Create
        public bool CreatePlayer(PlayerCreate model)
        {
            var entity = new Player()
            {
                UserID = _userId,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                Colors = model.Colors
            };
            ctx.Players.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
