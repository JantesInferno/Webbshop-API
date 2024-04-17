using System.Linq.Expressions;

namespace Web_API_Topstyles.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<bool> Remove(TEntity entity);
        Task<bool> Update(TEntity entity);
    }
}
