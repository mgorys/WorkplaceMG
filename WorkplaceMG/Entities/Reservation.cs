using System.ComponentModel.DataAnnotations.Schema;

namespace WorkplaceMG.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public virtual Employee Employee { get; set; }
        public int IdWorkplace { get; set; }
        [ForeignKey("IdWorkplace")]
        public virtual Workplace Workplace { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }

    }
}
