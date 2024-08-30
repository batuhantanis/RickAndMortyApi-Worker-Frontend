using EgeBilgi_Application.GenericRepository;
using EgeBilgi_Application.UnitOfWork;
using EgeBilgi_Domain.Entitities;
using EgeBilgi_Infrastructure.GenericRepository;
using EgeBilgi_Persistence;

namespace EgeBilgi_Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EgeBilgiDbContext _egeBilgiDbContext;
    private readonly IGenericRepository<Character> _character;
    private readonly IGenericRepository<CharacterEpisode> _characterEpisode;
    private readonly IGenericRepository<Episode> _episode;
    private readonly IGenericRepository<Location> _location;
    private readonly IGenericRepository<Origin> _origin;
    
    public UnitOfWork(EgeBilgiDbContext egeBilgiDbContext)
    {
        _egeBilgiDbContext = egeBilgiDbContext;
    }

    public IGenericRepository<Character> character =>
        _character ?? new GenericRepository<Character>(_egeBilgiDbContext);

    public IGenericRepository<CharacterEpisode> characterEpisode =>
        _characterEpisode ?? new GenericRepository<CharacterEpisode>(_egeBilgiDbContext);

    public IGenericRepository<Episode> episode => _episode ?? new GenericRepository<Episode>(_egeBilgiDbContext);
    public IGenericRepository<Location> location => _location ?? new GenericRepository<Location>(_egeBilgiDbContext);
    public IGenericRepository<Origin> origin => _origin ?? new GenericRepository<Origin>(_egeBilgiDbContext);
    public async Task SaveAsync()
    {
        await _egeBilgiDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _egeBilgiDbContext.Dispose();
    }
}