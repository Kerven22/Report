using Microsoft.EntityFrameworkCore;
using Report.Models;

namespace Report.Database
{
    public class ReportDbContext:DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
