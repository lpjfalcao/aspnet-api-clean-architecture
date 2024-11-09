using AutoMapper;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Interfaces.Services;
using System.Linq.Expressions;
using TaskManager.Infra.Data.Helpers;

namespace TaskManager.Application.Services
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private IServiceBase<TEntity> service;
        private IMapper mapper;

        public AppServiceBase(IServiceBase<TEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<MessageHelper<TEntity>> Add<TDto>(TDto dto)
        {
            var message = new MessageHelper<TEntity>();

            try
            {
                var model = this.mapper.Map<TEntity>(dto);
                
                var entity = this.service.Add(model);

                await this.service.Commit();

                message.Ok(entity);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }

        public async Task<MessageHelper<IEnumerable<TDto>>> GetAll<TDto>()
        {
            var message = new MessageHelper<IEnumerable<TDto>>();

            try
            {
                var dados = this.mapper.Map<IEnumerable<TDto>>(await this.service.GetAll());

                if (!dados.Any())
                {
                    message.NotFound("Nenhum dado foi encontrado");

                    return message;
                }

                message.Ok(dados);                
                
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }

        public async Task<MessageHelper<TDto>> GetByCondition<TDto>(Expression<Func<TEntity, bool>> expression)
        {
            var message = new MessageHelper<TDto>();

            try
            {
                var dados = this.mapper.Map<TDto>(await this.service.GetByCondition(expression));

                if (dados == null)
                {
                    message.NotFound("Nenhum dado foi encontrado");

                    return message;
                }

                message.Ok(dados);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }            

            return message;
        }

        public async Task<MessageHelper<IEnumerable<TDto>>> GetListByCondition<TDto>(Expression<Func<TEntity, bool>> expression)
        {
            var message = new MessageHelper<IEnumerable<TDto>>();

            try
            {
                var dados = this.mapper.Map<IEnumerable<TDto>>(await this.service.GetListByCondition(expression));

                if (dados == null)
                {
                    message.NotFound("Nenhum dado foi encontrado");

                    return message;
                }

                message.Ok(dados);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }
            
            return message;
        }

        public void Remove<TDto>(TDto dto)
        {
            var model = this.mapper.Map<TEntity>(dto);

            this.service.Remove(model);
        }

        public void Update<TDto>(TDto dto)
        {
            var model = this.mapper.Map<TEntity>(dto);

            this.service.Update(model);
        }

        public async Task Commit()
        {
            await this.service.Commit();
        }
    }
}
