using System.Linq.Expressions;

namespace TaskManager.Application.Interfaces
{
    public interface IAppServiceBase<TEntity, TDto>
    {
        void Add(TDto dto);
        Task<IEnumerable<TDto>> GetListByCondition(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TDto>> GetAll();
        void Update(TDto dto);
        void Remove(TDto dto);
    }
}
