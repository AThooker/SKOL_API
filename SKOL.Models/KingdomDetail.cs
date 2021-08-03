using SKOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Models
{
    public class KingdomDetail
    {
        public int KingdomID { get; set; }
        public string Name { get; set; }
        public string King { get; set; }
        public Colors Colors { get; set; }
        public List<VikingDetail> Vikings { get; set; }
    }
}
