using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Contextos;
using System.Linq.Expressions;

namespace TaskManager.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext context;

        public RepositoryBase(RepositoryContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public async Task<IEnumerable<T>> GetListByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.context.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }       
    }
}
