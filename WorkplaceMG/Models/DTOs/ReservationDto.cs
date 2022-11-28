using System.ComponentModel.DataAnnotations.Schema;
using WorkplaceMG.Entities;

namespace WorkplaceMG.Models.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdWorkplace { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public string Message { get; set; } = null;
    }
}
