using egebilgi_worker.Data.Entitities;
using egebilgi_worker.Data.GenericRepository.Abstract;
using egebilgi_worker.Data.GenericRepository.Concrete;
using egebilgi_worker.Data.UnitOfWork.Abstract;

namespace egebilgi_worker.Data.UnitOfWork.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly workerDbContext _workerDbContext;
    private readonly IGenericRepository<Character> _character;
    private readonly IGenericRepository<CharacterEpisode> _characterEpisode;
    private readonly IGenericRepository<Episode> _episode;
    private readonly IGenericRepository<Location> _location;
    private readonly IGenericRepository<Origin> _origin;
    public UnitOfWork(workerDbContext workerDbContext)
    {
        _workerDbContext = workerDbContext;
    }

    public IGenericRepository<Character> character => _character ?? new GenericRepository<Character>(_workerDbContext);

    public IGenericRepository<CharacterEpisode> characterEpisode =>
        _characterEpisode ?? new GenericRepository<CharacterEpisode>(_workerDbContext);

    public IGenericRepository<Episode> episode => _episode ?? new GenericRepository<Episode>(_workerDbContext);
    public IGenericRepository<Location> location => _location ?? new GenericRepository<Location>(_workerDbContext);
    public IGenericRepository<Origin> origin => _origin ?? new GenericRepository<Origin>(_workerDbContext);
    
    
    public async Task SaveAsync()
    {
      await _workerDbContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _workerDbContext.Dispose();
    }
}