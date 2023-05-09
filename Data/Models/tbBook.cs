using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("tbBook")]
    public class tbBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Category { get; set; } = "N/A";
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? PublishDate { get; set; }
        public decimal? Price { get; set; } = 0;
        public DateTime? UploadedDate { get; set; } = DateTime.Now;
        public string? BookUpload { get; set; }

        public string? Thumbnail { get; set; }
        [NotMapped]
        public string? ThumbnailUrl
        {
            get
            {
                if(this.Thumbnail != null)
                {
                    return string.Format("../Thumbnails/{0}", Thumbnail);
                }
                else
                {
                    return "../Thumbnails/Thumbnail.jpg";
                }
            }
        }

        [NotMapped]
        public string? BookUploadUrl
        {
            get
            {
                if(this.BookUpload != null)
                {
                    return string.Format("../BookUpload/{0}", BookUpload);
                }
                else
                {
                    return "../BookUpload/BulkyBook.pdf";
                }
            }
        }
    }
}
