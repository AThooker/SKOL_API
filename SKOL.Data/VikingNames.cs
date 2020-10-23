using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Data
{
    public class VikingNames
    {
        public List<string> Name { get; set; }
        public VikingNames() { }
        public VikingNames(string name)
        {
            Name = name;;
        }
    }
}
