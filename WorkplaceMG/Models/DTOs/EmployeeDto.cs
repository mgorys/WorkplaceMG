using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkplaceMG.Models.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
