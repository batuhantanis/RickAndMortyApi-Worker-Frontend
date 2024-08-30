using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace egebilgi_worker.Data.Configurations;

public class CharacterConfiguration : BaseConfiguration<Character>
{
    public override void upConfigure(EntityTypeBuilder<Character> builder)
    {
        builder.Property(x => x.name);
        builder.Property(x => x.status);
        builder.Property(x => x.species);
        builder.Property(x => x.type);
        builder.Property(x => x.gender);
        builder.Property(x => x.image);
        builder.Property(x => x.url);
        builder.Property(x => x.created);
        builder.HasOne(x => x.origin);
        builder.HasOne(x => x.location).WithMany(x => x.Characters).HasForeignKey(x => x.LocationId);
        builder.HasMany(x => x.CharacterEpisodes).WithOne(x => x.Character).HasForeignKey(x => x.CharacterId);
    }
}