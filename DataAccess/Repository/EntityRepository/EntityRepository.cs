using System.Linq.Expressions;
using Core.Entities.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class Repository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly EducationPortalDbContext _context;
        private readonly DbSet<TEntity> _dbSet; 
        public Repository(EducationPortalDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(o => o.Id == id) ?? throw new ApplicationException();
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter) ?? throw new ApplicationException();
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            if(filter == null)
            {
                return await _dbSet.ToListAsync();
            }
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}