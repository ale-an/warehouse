using Microsoft.Extensions.DependencyInjection;
using Storage.Logic;
using Storage.Logic.Interfaces;

namespace Service.Registrations;

public static class Storage
{
    public static IServiceCollection AddStorage(this IServiceCollection services) =>
        services.AddSingleton<IBoxRepository, BoxRepository>()
            .AddSingleton<IPalletRepository, PalletRepository>()
            .AddSingleton<IPalletBoxRepository, PalletBoxRepository>()
            .AddSingleton<StorageContext>();
}