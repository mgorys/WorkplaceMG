using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkplaceMG.Models.DTOs
{
	public class EquipmentDto
	{
        public int Id { get; set; }
        public string Type { get; set; }
        [DisplayName("Avaiable in stock")]
        public int StockCount { get; set; }
    }
}
