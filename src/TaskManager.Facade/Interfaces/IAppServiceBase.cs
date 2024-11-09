using System.Linq.Expressions;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Interfaces
{
    public interface IAppServiceBase<TEntity>
    {
        Task<MessageHelper<TEntity>> Add<TDto>(TDto dto);
        Task<MessageHelper<IEnumerable<TDto>>> GetListByCondition<TDto>(Expression<Func<TEntity, bool>> expression);
        Task<MessageHelper<TDto>> GetByCondition<TDto>(Expression<Func<TEntity, bool>> expression);
        Task<MessageHelper<IEnumerable<TDto>>> GetAll<TDto>();
        void Update<TDto>(TDto dto);
        void Remove<TDto>(TDto dto);
        Task Commit();
    }
}
