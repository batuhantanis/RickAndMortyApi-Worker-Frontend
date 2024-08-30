using egebilgi_worker.Data.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace egebilgi_worker.Data.Configurations;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(typeof(TEntity).Name);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedTime).HasDefaultValue(DateTime.Now);
    }
    
    public abstract void upConfigure(EntityTypeBuilder<TEntity> builder);
}