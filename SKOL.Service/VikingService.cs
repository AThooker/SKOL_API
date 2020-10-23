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
        ApplicationDbContext ctx = new ApplicationDbContext();
        public bool CreateViking(VikingCreate model)
        {
            Random rnd = new Random();
            var entity =  new Viking
                {
                    Name = (Name)rnd.Next(0, Enum.GetNames(typeof(Name)).Length),
                    Job = (Job)rnd.Next(0, Enum.GetNames(typeof(Job)).Length),
                    Kingdom = (Kingdom)ctx.Kingdoms.Where(p => p.Colors == model.Colors)
                };
            ctx.Vikings.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
