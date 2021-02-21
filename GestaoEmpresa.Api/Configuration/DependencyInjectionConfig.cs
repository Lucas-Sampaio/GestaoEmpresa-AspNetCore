using GestaoEmpresa.DAL.Repositorio;
using GestaoEmpresa.Dominio.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoEmpresa.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepositorio>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepositorio>();

        }
    }
}
