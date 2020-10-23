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
        ApplicationDbContext _ctx = new ApplicationDbContext();
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
            var player = new Player()
            {
                UserID = _userId,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                Colors = model.Colors
            };
            _ctx.Players.Add(player);
            Random rnd = new Random();
            var viking = new Viking()
            {
                Name = if (Name > 9) {
                (Name)rnd.Next(9, Enum.GetNames(typeof(Name)).Length);
                    },
                Job = (Job)rnd.Next(0, Enum.GetNames(typeof(Job)).Length),
                Kingdom = (Kingdom)_ctx.Kingdoms.Where(p => p.Colors == model.Colors)
            };
            return _ctx.SaveChanges() == 1;
        }
    }
}
