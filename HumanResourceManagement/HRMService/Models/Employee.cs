using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMService.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("empID")]
        public int EmployeeId { get; set; }

        [Column("firstName")]
        [Required]
        public string FirstName { get; set; }

        [Column("lastName")]
        [Required]
        public string LastName { get; set; }

        [Column("DOB")]
        [Required]
        public DateOnly DOB { get; set; }

        [EmailAddress]
        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("contact-no")]
        [Required]
        public string ContactNo { get; set; }

        [Column("address")]
        [Required]
        public string Address { get; set; }

        [Column("departmentname")]
        [Required]
        public string DepartmentName { get; set; }

        [Column("role")]
        [Required]
        public string Role { get; set; }


    }
}
