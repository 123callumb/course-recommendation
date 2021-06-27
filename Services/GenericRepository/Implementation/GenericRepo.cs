using Library.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.GenericRepository.Implementation
{
    public class GenericRepo : IGenericRepo
    {
        private readonly IGenericQuerier _genericQuerier;
        private readonly IDatabaseContext _dbContext;
        public GenericRepo(IGenericQuerier genericQuerier, IDatabaseContext dbContext)
        {
            _genericQuerier = genericQuerier;
            _dbContext = dbContext;
        }
        public async Task<int> Add<Entity>(Entity entity) where Entity : class
        {
            _genericQuerier.LoadDbSet<Entity>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRange<Entity>(List<Entity> entity) where Entity : class
        {
            _genericQuerier.LoadDbSet<Entity>().AddRange(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Remove<Entity>(Entity entity) where Entity : class
        {
            _genericQuerier.LoadDbSet<Entity>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveRange<Entity>(List<Entity> entity) where Entity : class
        {
            _genericQuerier.LoadDbSet<Entity>().RemoveRange(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
