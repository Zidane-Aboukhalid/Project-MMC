using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMCProject.Domain.Entities;
using static System.Collections.Specialized.BitVector32;

namespace MMCProject.Infrastructure.DBContext
{
    public class MMCDBContext : DbContext
    {
        public MMCDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<TargetAudience> TargetAudiences { get; set; }
        public DbSet<SessionTargetAudience> SessionTargetAudiences { get; set; }
    }
}
