using System;
using DatosIonosfericos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MiAppConsola;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = BuildDi();
        using var scope = serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IIonosferaService>();

        Console.WriteLine("Ejecucion iniciada");
        await service.SaveData();
        Console.WriteLine("Ejecucion completa");
        Console.ReadLine();
    }

    private static IServiceProvider BuildDi()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<IonosferaContext>(opt  =>
          opt.UseSqlServer("Server=TINCHO\\SQLEXPRESS;Database=IonosphereDb;Integrated Security=True;TrustServerCertificate=true;"));
        serviceCollection.AddTransient<IIonosferaService, IonosferaService>();

        return serviceCollection.BuildServiceProvider();
    }
}
