using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public virtual DbSet<tbUser> Users { get; set; }
        public virtual DbSet<tbBook> Books { get; set; }
        public virtual DbSet<tbCategory> Categories { get; set; }
    }
}
