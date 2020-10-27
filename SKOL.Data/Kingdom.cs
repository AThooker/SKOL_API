using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Data
{
    public enum Colors { }
    public class Kingdom
    {
        [Key]
        public int KingdomID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string King { get; set; }
        [Required]
        public Colors Colors { get; set; }
        public virtual ICollection<Viking> Vikings { get; set; }
    }
}
