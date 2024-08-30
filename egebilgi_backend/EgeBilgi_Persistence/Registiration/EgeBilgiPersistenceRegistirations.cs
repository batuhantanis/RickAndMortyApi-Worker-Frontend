using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EgeBilgi_Persistence.Registiration;

public static class EgeBilgiPersistenceRegistirations
{
    public static void AddEgeBilgiPersistenceRegistirations(this IServiceCollection serviceCollection,IConfiguration configuration)
    {
        serviceCollection.AddDbContext<EgeBilgiDbContext>(x =>
            x.UseSqlServer(configuration.GetConnectionString("DockerConnection")));
    }
}