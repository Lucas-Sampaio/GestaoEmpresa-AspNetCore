using GestaoEmpresa.Web.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            #region HttpServices
            services.AddHttpClient<IEmpresaService,EmpresaService>();
            #endregion
            return services;
        }
    }
}
