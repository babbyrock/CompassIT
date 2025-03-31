using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CompassIT.Domain.Interfaces;
using CompassIT.Persistence.Context;
using CompassIT.Persistence.Repositories;
using CompassIT.Application.Interfaces;
using CompassIT.Application.Services;
using CompassIT.Application.Mappings;

namespace CompassIT.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)) 
            );


            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddAutoMapper(typeof(ProdutoProfile));

            return services;
        }
    }
}
