using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EntFrmLab2.DAL
{
    public class Context:DbContext
    {
        private string _connectString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TeamsFb;Integrated Security=True;Connect Timeout=30;";
        public DbSet<FootballTeams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectString);
        }
    }
}