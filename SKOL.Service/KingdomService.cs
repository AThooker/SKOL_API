using SKOL.Data;
using SKOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Service
{
    public class KingdomService
    {
        ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public KingdomService(Guid userId)
        {
            _userId = userId;
        }
        //Create
        public bool CreateKingdom(KingdomCreate model)
        {
            var kingdom = new Kingdom
            {
                Name = model.Name,
                King = model.King,
                Colors = model.Colors
            };
            _ctx.Kingdoms.Add(kingdom);
            return _ctx.SaveChanges() == 1;
        }
        //Read
        public IEnumerable<KingdomDetail> GetKingdoms()
        {
            var query = _ctx.Kingdoms.Select(
                p => new KingdomDetail
                {
                    KingdomID = p.KingdomID,
                    Name = p.Name,
                    King = p.King,
                    Colors = p.Colors,
                    Vikings = p.Vikings.ToList()

                });
            return query.ToArray();
        }
    }
}
