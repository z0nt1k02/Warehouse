using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<WarehouseEntity>
{
    public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(w => w.Zones)
            .WithOne(z => z.Warehouse)
            .HasForeignKey(z => z.WarehouseId);
    }
}