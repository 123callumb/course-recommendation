using Library.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.GenericRepository.Implementation
{
    public class GenericQuerier : IGenericQuerier
    {
        private readonly IDatabaseContext _dbContext;
        public GenericQuerier(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<EntityDTO> Load<Entity, EntityDTO>(Expression<Func<Entity, EntityDTO>> select, Expression<Func<Entity, bool>> where = null) where Entity : class
        {
            var dbSet = LoadDbSet<Entity>().AsQueryable();

            if (where != null)
                dbSet = dbSet.Where(where);

            return dbSet.Select(select);
        }

        public IQueryable<Entity> LoadEntity<Entity>(Expression<Func<Entity, bool>> where) where Entity : class
        {
            return LoadDbSet<Entity>().Where(where);
        }

        public DbSet<TEntity> LoadDbSet<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
