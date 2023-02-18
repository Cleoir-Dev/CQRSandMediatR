using CQRSandMediatR.Model;
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

        public DbSet<DetailModel> Details { get; set; }
    }
}
