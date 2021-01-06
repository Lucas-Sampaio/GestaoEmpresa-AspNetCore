using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoEmpresa.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
           
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
