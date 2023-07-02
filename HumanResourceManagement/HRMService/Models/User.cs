using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRMService.Models
{
   
        public class User
        {

            public int userId { get; set; }


            public string firstName { get; set; }


            public string lastName { get; set; }


            [EmailAddress]

            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]

            public string Password { get; set; }

            [Required]

            public string Designation { get; set; }
        }

        public class UserLoginModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


        }

        [Table("users")]
        public class UserRegisterModel
        {
            [Key]
            [Column("userID")]
            public int userId { get; set; }


            [Column("firstName")]
            [Required]
            public string firstName { get; set; }


            [Column("lastName")]
            [Required]
            public string lastName { get; set; }


            [EmailAddress]
            [Required]
            [Column("email")]
            public string Email { get; set; }


            [DataType(DataType.Password)]
            [Required]
            [Column("password")]
            public string Password { get; set; }


            [Column("designation")]
            [Required]
            public string Designation { get; set; }
        }
    }
