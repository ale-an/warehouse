using Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Registrations; // Requires NuGet package

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddStorage()
            .AddServices()
            .AddSingleton<ClientService>();
    })
    .Build();

var clientService = host.Services.GetRequiredService<ClientService>();

clientService.Execute();