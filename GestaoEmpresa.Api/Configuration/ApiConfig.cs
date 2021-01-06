using GestaoEmpresa.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestaoEmpresa.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers();
            var connection = Configuration.GetConnectionString("MyConnection");
            services.AddDbContext<GestaoContext>(options => options.UseSqlServer(connection, x => x.MigrationsAssembly(
                typeof(GestaoContext).Assembly.FullName)));
            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            return app;
        }
    }
}
