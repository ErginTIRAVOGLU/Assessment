using Microsoft.EntityFrameworkCore;

namespace Assessment.Rapor.Api.Models
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PgConnectionString"));

        }

        public DbSet<Raporlar> Raporlar { get; set; }
    }
}
