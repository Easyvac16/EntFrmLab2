using EntFrmLab2.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EntFrmLab2.DAL
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly Context _context;

        public Repository()
        {
            _context = new Context();
        }
        public Repository(DbContextOptions options)
        {
            _context = new Context(options);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            _context.SaveChanges();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            yield return entity;
        }

        public void Remove(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);

            _context.Set<TEntity>().Remove(entity);

            _context.SaveChanges();
        }

        public void Update(int id, TEntity entity)
        {
            var existingEntity = _context.Set<TEntity>().Find(id);

            _context.Entry(existingEntity).CurrentValues
                .SetValues(entity);

            _context.SaveChanges();
        }

        /* public IEnumerable<Team> GetTeams()
        {
            return _context.Teams;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Players;
        }*/


    }
}
