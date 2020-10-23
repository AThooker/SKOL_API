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
        public VikingDetail GetVikingByPlayer(int id)
        {
            var query = ctx.Players.Where(p => p.PlayerID == id)
                .Select(q => new VikingDetail
                {
                    VikingID = q.PlayerID,
                    Name = Random
                })
        }
    }
}
