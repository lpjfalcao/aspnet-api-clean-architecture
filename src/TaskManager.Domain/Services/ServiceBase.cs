using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace TaskManager.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public void Add(T entity)
        {
            this.repository.Add(entity);
        }

        public async Task<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.repository.GetByCondition(expression);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.repository.GetAll();
        }

        public void Remove(T entity)
        {
            this.repository.Remove(entity);
        }

        public void Update(T entity)
        {
            this.repository.Update(entity);
        }
    }
}
