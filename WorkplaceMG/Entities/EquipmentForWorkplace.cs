using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkplaceMG.Entities
{
    public class EquipmentForWorkplace
    {
        [Key]
        public int Id { get; set; }
        public int IdWorkplace { get; set; }
        [ForeignKey("IdWorkplace")]
        public virtual Workplace Workplace { get; set; }
        public int IdEquipment { get; set; }
        [ForeignKey("IdEquipment")]
        public virtual Equipment Equipment { get; set; }
    }
}
