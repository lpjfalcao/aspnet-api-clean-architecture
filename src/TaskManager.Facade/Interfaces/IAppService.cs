using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Interfaces
{
    public interface IAppServiceBase<TEntity, TDto>
    {
        void Add(TDto dto);
        Task<TDto> GetByCondition(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TDto>> GetAll();
        void Update(TDto dto);
        void Remove(TDto dto);
    }
}
