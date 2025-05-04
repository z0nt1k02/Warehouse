using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class StorageCellConfiguration : IEntityTypeConfiguration<StorageCellEntity>
{
    public void Configure(EntityTypeBuilder<StorageCellEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(s => s.Rack)
            .WithMany(r => r.Cells)
            .HasForeignKey(s => s.RackId);
        
        builder.HasMany(x => x.Items)
            .WithOne(i=>i.StorageCell);

        builder.HasMany(x => x.Boxes)
            .WithOne(b => b.StorageCell);

    }
}