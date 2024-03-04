using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EntFrmLab2.DAL
{
    public class Context:DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GoalScorer> GoalScorers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            var connectString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne<Team>(f => f.Team1Id)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne<Team>(f => f.Team2Id)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}