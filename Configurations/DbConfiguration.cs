using EntityFrameworkCore.UnitOfWork.Extensions;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace trilha_net_azure_desafio.Configurations
{
    public static class DbConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RHContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConexaoPadrao"),
                                b => b.MigrationsAssembly("Infraesctructure.Data"));
            }, contextLifetime: ServiceLifetime.Transient);
            services.AddUnitOfWork<RHContext>(ServiceLifetime.Transient);
        }
    }
}
