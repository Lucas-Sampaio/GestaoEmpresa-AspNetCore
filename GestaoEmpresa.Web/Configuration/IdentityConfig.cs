using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/login";
            //        options.AccessDeniedPath = "/acesso-negado";
            //    });
            return services;
        }

        public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseAuthentication();
            return app;
        }
    }
}
