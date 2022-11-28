using System.ComponentModel.DataAnnotations;

namespace WorkplaceMG.Entities
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int? StockCount { get; set; }
    }
}
