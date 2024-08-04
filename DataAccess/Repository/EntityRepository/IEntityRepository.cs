using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<T> Get(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
