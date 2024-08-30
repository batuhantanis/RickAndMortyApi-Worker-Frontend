using egebilgi_worker.Core.Responses;
using egebilgi_worker.Data.Entitities;

namespace egebilgi_worker.Services.Abstract;

public interface IWorkerService
{
    public Task<bool> GetAndSetCharacters();
    
    public Task<bool> GetAndSetLocations();
    
    public Task<bool> GetAndSetEpisodes();
}