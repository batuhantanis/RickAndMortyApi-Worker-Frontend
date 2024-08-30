using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace egebilgi_worker.Data.Configurations;

public class CharacterEpisodeConfiguration : BaseConfiguration<CharacterEpisode>
{
    public override void upConfigure(EntityTypeBuilder<CharacterEpisode> builder)
    {
        builder.HasOne(x => x.Episode).WithMany(x => x.CharacterEpisodes).HasForeignKey(x => x.EpisodeId);
        builder.HasOne(x => x.Character).WithMany(x => x.CharacterEpisodes).HasForeignKey(x => x.CharacterId);
    }
}