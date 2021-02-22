using GestaoEmpresa.Web.Extensions.Atributos;
using GestaoEmpresa.Web.Services;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static GestaoEmpresa.Web.Extensions.Atributos.CnpjAttribute;

namespace GestaoEmpresa.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            #region Atributos
            services.AddSingleton<IValidationAttributeAdapterProvider, CnpjValidationAttributeAdapterProvider>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IValidationAttributeAdapterProvider, PisValidationAttributeAdapterProvider>();
            #endregion

            #region HttpServices
            services.AddHttpClient<IEmpresaService, EmpresaService>();
            services.AddHttpClient<IFuncionarioService, FuncionarioService>();
            #endregion
            return services;
        }
    }
}
