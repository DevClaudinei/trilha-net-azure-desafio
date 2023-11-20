using DomainModels.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace trilha_net_azure_desafio.Configurations
{
    public static class ConnectionStringsConfiguration
    {
        public static void AddConnectionStringsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
           services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));    
        }
    }
}
