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
                Gender = model.Gender.ToLower(),
                DateOfBirth = model.DateOfBirth,
                Colors = model.Colors
            };
            _ctx.Players.Add(player);
            var service = new VikingService(_userId);
            var newVik = service.CreateViking(model);
            return _ctx.SaveChanges() == 1;
        }

        //Read
        public IEnumerable<PlayerListItem> GetPlayers()
        {
            var query = _ctx.Players.Where(p => p.UserID == _userId)
                .Select(p => new PlayerListItem
                {
                    Name = p.Name,
                    Gender = p.Gender,
                    DateOfBirth = p.DateOfBirth,
                    Colors = p.Colors,
                });
            return query.ToArray();
        }
    }
}
