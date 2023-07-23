﻿using Microsoft.EntityFrameworkCore;

namespace Assessment.Rapor.Api.Models
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PgConnectionString"));

        }

        public DbSet<Rapor> Raporlar { get; set; }
    }
}
