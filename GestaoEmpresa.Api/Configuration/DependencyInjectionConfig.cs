using GestaoEmpresa.DAL;
using GestaoEmpresa.DAL.Repositorio;
using GestaoEmpresa.DAL.Repositorio.RepositorioComum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
