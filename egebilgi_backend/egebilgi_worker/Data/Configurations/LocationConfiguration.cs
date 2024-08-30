using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace egebilgi_worker.Data.Configurations;

public class LocationConfiguration : BaseConfiguration<Location>
{
    public override void upConfigure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(x => x.url);
        builder.Property(x => x.name);
        builder.Property(x => x.type);
        builder.Property(x => x.dimension);
        builder.Property(x => x.created);

        builder.HasMany(x => x.Characters).WithOne(x => x.location).HasForeignKey(x => x.LocationId);
    }
}