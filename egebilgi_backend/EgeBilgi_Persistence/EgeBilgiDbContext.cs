using EgeBilgi_Domain.Entitities;
using Microsoft.EntityFrameworkCore;

namespace EgeBilgi_Persistence;

public class EgeBilgiDbContext : DbContext
{
    public EgeBilgiDbContext(DbContextOptions<EgeBilgiDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Character> Character { get; set; }
    public DbSet<Episode> Episode { get; set; }
    public DbSet<CharacterEpisode> CharacterEpisode { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Origin> Origin { get; set; }
}