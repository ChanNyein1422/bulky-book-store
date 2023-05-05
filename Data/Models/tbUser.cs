using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tbUser")]
    public class tbUser
    {
        [Key]
        public int Id { get; set; }
      
        public string? Name { get; set; }
      //  [Required]
        public string? Email { get; set; }
      //  [Required]
        public string? Password { get; set; }
        //  [Required]
        public string? UserRole { get; set; } = "User";
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public string? ConfirmPassword { get; set; }
        [NotMapped]
        public string? ReturnMessage { get; set; } 
    }
}
