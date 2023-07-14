using CQRSandMediatR.Model;
using CQRSandMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSandMediatR.Data
{
    public class DbContextData : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextData(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        // Delete o initial e snapshot the database, after delete as tables in the SQL Server
        // Open console manage package is digit
        // Commands generate database is : Add-Migration Initial -context DbContextData, update-database -context DbContextData
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<DetailModel> Details { get; set; }
    }
}
