using egebilgi_worker.Data.Configurations;
using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore;

namespace egebilgi_worker.Data;

public class workerDbContext : DbContext
{
    public workerDbContext(DbContextOptions<workerDbContext> options) : base(options)
    {
        
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<CharacterEpisode> CharacterEpisodes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Origin> Origins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterEpisodeConfiguration());
        modelBuilder.ApplyConfiguration(new EpisodeConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new OriginConfiguration());
    }
}