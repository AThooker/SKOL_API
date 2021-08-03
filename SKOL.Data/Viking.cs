using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Data
{
    public enum Job { Blacksmith, Farmer, King, Raider, ShipBuilder, Slave}
    public enum Name { Herleif, Ragnar, Gunnar, Magnus, Aric, Ivar, Thor, Bjorn, Ulf, Arkyn, Astrid, Sigrid, Hilde, Ama, Rune, Gisli, Runa, Revna, Astra, Freya}
    public class Viking
    {
        [Key]
        public int VikingID { get; set; }
        [Required]
        public Name Name { get; set; }
        [Required]
        public Job Job { get; set; }
        [ForeignKey("Kingdom")]
        public int KingdomID { get; set; }
        public virtual Kingdom Kingdom { get; set; }
        [ForeignKey(nameof(PlayerID))]
        public virtual Player Player { get; set; }
        public int? PlayerID { get; set; }
    }
}
