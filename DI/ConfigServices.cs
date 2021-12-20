using Data.EF;
using Data.EF.Repositories;
using Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<DataContext>();
            services.AddTransient<IUsuarioRepository, UsuarioRepositoryEF>();
        }
    }
}