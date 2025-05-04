using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class BoxConfiguration : IEntityTypeConfiguration<BoxEntity>
{
    public void Configure(EntityTypeBuilder<BoxEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.StorageCell)
            .WithMany(x => x.Boxes)
            .HasForeignKey(x => x.StorageCellId);


        builder.HasMany(x => x.Items)
            .WithOne(x => x.Box);

    }
}