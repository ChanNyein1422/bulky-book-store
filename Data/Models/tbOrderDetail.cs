using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tbOrderDetail")]
    public class tbOrderDetail
    {
        [Key]
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? OrderCode { get; set; }
        public int UserId { get; set; }
        public decimal? Price { get; set; }
    }
}
