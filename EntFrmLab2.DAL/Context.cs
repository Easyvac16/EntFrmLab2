using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EntFrmLab2.DAL
{
    public class Context:DbContext
    {
        public DbSet<FootballTeams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            var connectString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectString);
        }
    }
}