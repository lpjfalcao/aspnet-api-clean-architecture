using AutoMapper;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace TaskManager.Application.Services
{
    public class AppServiceBase<TEntity, TDto> : IAppServiceBase<TEntity, TDto> where TEntity : class where TDto : class
    {
        private IServiceBase<TEntity> service;
        private IMapper mapper;

        public AppServiceBase(IServiceBase<TEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Add(TDto dto)
        {
            var model = this.mapper.Map<TEntity>(dto);
            this.service.Add(model);
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var model = await this.service.GetAll();

            return this.mapper.Map<IEnumerable<TDto>>(model);
        }

        public async Task<TDto> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            var model = await this.service.GetByCondition(expression);

            return this.mapper.Map<TDto>(model);
        }

        public void Remove(TDto dto)
        {
            var model = this.mapper.Map<TEntity>(dto);

            this.service.Remove(model);
        }

        public void Update(TDto dto)
        {
            var model = this.mapper.Map<TEntity>(dto);

            this.service.Update(model);
        }
    }
}
