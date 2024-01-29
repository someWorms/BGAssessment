using ANPR.Infrastructure.Globals;
using ANPR.Persistence.Database.Interfaces;
using ANPR.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ANPR.Persistence.Database
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<PlateModel> Plates { get; set; }
        public DbSet<ProcessedFileModel> ProcessedFiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.DbConnection);
        }
    }
}
