using System.ComponentModel.DataAnnotations;

namespace WorkplaceMG.Entities
{
    public class Workplace
    {
        [Key]
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
    }
}
