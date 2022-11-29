using System.ComponentModel.DataAnnotations.Schema;
using WorkplaceMG.Entities;

namespace WorkplaceMG.Models.DTOs
{
	public class EquipmentForWorkplaceDto
	{
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Table { get; set; }
        public string Type { get; set; }
   
    }
}
