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
        public string Id { get; set; }
        public int UserId { get; set; }
        public string OrderCode { get; set; }
        public decimal? TotalAmount { get; set; } = 0;
        public int? TotalBooks { get; set; } = 0;
        public DateTime? OrderedTime { get; set; } = DateTime.Now;

    }
}
