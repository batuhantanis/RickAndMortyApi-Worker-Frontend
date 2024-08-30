using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace egebilgi_worker.Data.Configurations;

public class EpisodeConfiguration : BaseConfiguration<Episode>
{
    public override void upConfigure(EntityTypeBuilder<Episode> builder)
    {
        builder.Property(x => x.url);
        builder.Property(x => x.name);
        builder.Property(x => x.episode);
        builder.Property(x => x.created);

        builder.HasMany(x => x.CharacterEpisodes).WithOne(x => x.Episode).HasForeignKey(x => x.EpisodeId);
    }
}