using SKOL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Models
{
    public class KingdomCreate
    {
        public string Name { get; set; }
        public string King { get; set; }
        public Colors Colors { get; set; }
    }
}
