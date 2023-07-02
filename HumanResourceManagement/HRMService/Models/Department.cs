using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMService.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        [Column("depID")]
        public int DepId { get; set; }

        [Column("depName")]
        public string DepartmentName { get; set; }
    }
}
