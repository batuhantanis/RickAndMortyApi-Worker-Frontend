using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace egebilgi_worker.Data.Configurations;

public class OriginConfiguration : BaseConfiguration<Origin>
{
    public override void upConfigure(EntityTypeBuilder<Origin> builder)
    {
        builder.Property(x => x.url);
        builder.Property(x => x.name);
    }
}