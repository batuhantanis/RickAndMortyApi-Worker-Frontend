using egebilgi_worker.Data.Entitities;
using egebilgi_worker.Data.GenericRepository.Abstract;

namespace egebilgi_worker.Data.UnitOfWork.Abstract;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<Character> character { get;}
    public IGenericRepository<CharacterEpisode> characterEpisode { get;}
    public IGenericRepository<Episode> episode { get;}
    public IGenericRepository<Location> location { get;}
    public IGenericRepository<Origin> origin { get;}
    public Task SaveAsync();
}