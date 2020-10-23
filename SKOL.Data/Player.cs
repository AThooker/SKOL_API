using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Data
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Colors Colors { get; set; }
    }
}
