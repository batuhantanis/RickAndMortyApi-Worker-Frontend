using EgeBilgi_Application.GenericRepository;
using EgeBilgi_Domain.Entitities;

namespace EgeBilgi_Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<Character> character { get;}
    public IGenericRepository<CharacterEpisode> characterEpisode { get;}
    public IGenericRepository<Episode> episode { get;}
    public IGenericRepository<Location> location { get;}
    public IGenericRepository<Origin> origin { get;}
    public Task SaveAsync();
}