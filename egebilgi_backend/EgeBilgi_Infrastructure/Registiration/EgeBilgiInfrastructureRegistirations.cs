using EgeBilgi_Application.Services;
using EgeBilgi_Application.UnitOfWork;
using EgeBilgi_Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EgeBilgi_Infrastructure.Registiration;

public static class EgeBilgiInfrastructureRegistirations
{
    public static void AddEgeBilgiInfrastructureRegistirations(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        serviceCollection.AddScoped<ICharacterService, CharacterService>();
    }
}