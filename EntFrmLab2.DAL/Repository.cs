using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntFrmLab2.DAL
{
    public class Repository<TEntity> where TEntity : class
    {
        private static readonly Context _context;

        public Repository()
        {
            _context = new Context();
        }

        public static void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            _context.SaveChanges();
        }

        public IQueryable<Team> GetTeams()
        {
            return _context.Teams;
        }

        public IQueryable<Player> GetPlayers()
        {
            return _context.Players;
        }


    }
}
