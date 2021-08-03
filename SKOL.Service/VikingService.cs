using SKOL.Data;
using SKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Service
{
    public class VikingService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public VikingService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateViking(PlayerCreate model)
        {
            Random rnd = new Random();
            if (model.Gender == "f")
            {
                var maiden = new Viking()
                {
                    Name = (Name)rnd.Next(9, Enum.GetNames(typeof(Name)).Length),
                    Job = (Job)rnd.Next(0, Enum.GetNames(typeof(Job)).Length),
                    Kingdom = _ctx.Kingdoms.Single(p => p.Colors == model.Colors)
                };
                _ctx.Vikings.Add(maiden);
            };
            if (model.Gender == "m")
            {
                var lad = new Viking()
                {
                    Name = (Name)rnd.Next(0, Enum.GetNames(typeof(Name)).Length - 9),
                    Job = (Job)rnd.Next(0, Enum.GetNames(typeof(Job)).Length),
                    Kingdom = _ctx.Kingdoms.Single(k => k.Colors == model.Colors),
                };
                _ctx.Vikings.Add(lad);
            };
                return _ctx.SaveChanges() == 1;
        }
        public IEnumerable<VikingDetail> GetVikings()
        {
            //Get all vikings for that user (not player) - each player will only have one viking, but each user can have several vikings/players
            var query = _ctx.Vikings.Select(
                p => new VikingDetail
                {
                    VikingID = p.VikingID,
                    Name = p.Name.ToString(),
                    Job = p.Job.ToString(),
                    KingdomName = p.Kingdom.Name,
                });
            return query.ToArray();

          //Access the database and get vikings if they have the correct user Id
        }
        public bool DeleteViking(int id)
        {
            var viking = _ctx.Vikings.Single(p => p.VikingID == id);
            _ctx.Vikings.Remove(viking);
            return _ctx.SaveChanges() == 1;
        }
    }
}
