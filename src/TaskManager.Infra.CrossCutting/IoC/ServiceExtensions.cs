using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Domain.Services;
using TaskManager.Infra.Data.Contextos;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Infra.CrossCutting.IoC
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection"), builder =>
                builder.MigrationsAssembly("TaskManager.Infra.Data")));

        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<ITarefaAppService, TarefaAppService>();
            services.AddScoped<IProjetoAppService, ProjetoAppService>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IHistoricoAlteracaoService, HistoricoAlteracaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IHistoricoAlteracaoRepository, HistoricoAlteracaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
