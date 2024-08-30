using egebilgi_worker.Services.Abstract;
using Newtonsoft.Json;

namespace egebilgi_worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;


    public Worker(ILogger<Worker> logger,IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
             var workerService = scope.ServiceProvider.GetRequiredService<IWorkerService>();
             
             var locations = await workerService.GetAndSetLocations();
             if (locations)
             {
                 var episodes = await workerService.GetAndSetEpisodes();
                 if (episodes)
                 {
                     var characters = await workerService.GetAndSetCharacters();
                     if (characters)
                     {
                         await StopAsync(stoppingToken);
                     }
                 }
             }
            }
        }
    }
}