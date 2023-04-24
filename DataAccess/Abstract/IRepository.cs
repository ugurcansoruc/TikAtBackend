using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
