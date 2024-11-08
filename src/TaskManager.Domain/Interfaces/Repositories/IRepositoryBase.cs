using System.Linq.Expressions;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}
