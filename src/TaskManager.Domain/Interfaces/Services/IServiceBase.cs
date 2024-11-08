using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}
