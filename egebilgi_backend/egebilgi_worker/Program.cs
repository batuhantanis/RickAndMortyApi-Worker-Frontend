using egebilgi_worker;
using egebilgi_worker.Data;
using egebilgi_worker.Data.UnitOfWork.Abstract;
using egebilgi_worker.Data.UnitOfWork.Concrete;
using egebilgi_worker.Services.Abstract;
using egebilgi_worker.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using RestSharp;

IHost host = Host.CreateDefaultBuilder(args)
    
    
    .ConfigureServices((context, services) =>
    {
        
        // var connectionString = "Server=localhost\\SQLEXPRESS;Database=egebilgi;Trusted_Connection=True;TrustServerCertificate=True";
        var dockerConnectionString =
            "Server=egesql;Database=egebilgidb;User Id=sa;Password=Batuhan123!;TrustServerCertificate=True";
        services.AddDbContext<workerDbContext>(options =>
            options.UseSqlServer(dockerConnectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IWorkerService, WorkerService>();
        services.AddSingleton<IRestClient, RestClient>();
        services.AddHostedService<Worker>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<workerDbContext>();
        context.Database.Migrate();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
    
}
host.Run();