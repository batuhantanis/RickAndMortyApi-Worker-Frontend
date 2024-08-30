using Microsoft.Extensions.DependencyInjection;

namespace EgeBilgi_MediatR.Registiration;

public static class EgeBilgiMediatrRegistirations
{
    public static void AddEgeBilgiMediatrRegistirations(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LibraryEntrypoint).Assembly));
    }
}