using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tbOrder")]
    public class tbOrder
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? OrderDetails { get; set; }
        public DateTime? OrderedTime { get; set; }

    }
}
