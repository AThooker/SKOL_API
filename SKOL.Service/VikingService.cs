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
        ApplicationDbContext _ctx = new ApplicationDbContext();
        public bool CreateViking(VikingCreate model)
        {
            Player player = (Player)_ctx.Players.Where(p => p.Name == model.Name);
            Random rnd = new Random();
            var entity = new Viking
                {
                    Name = (Name)rnd.Next(0, Enum.GetNames(typeof(Name)).Length),
                    Job = (Job)rnd.Next(0, Enum.GetNames(typeof(Job)).Length),
                    Kingdom = (Kingdom)_ctx.Kingdoms.Where(p => p.Colors == model.Colors)
                };
            _ctx.Vikings.Add(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
