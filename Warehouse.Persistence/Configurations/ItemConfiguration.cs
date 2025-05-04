using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
{
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Box)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.BoxId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.StorageCell)
            .WithMany(s => s.Items);
    }
}