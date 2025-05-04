using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class SectorConfiguration : IEntityTypeConfiguration<SectorEntity>
{
    public void Configure(EntityTypeBuilder<SectorEntity> builder)
    {
        builder.HasKey(s=>s.Id);
        
        builder.HasOne(s => s.Zone)
            .WithMany(z => z.Sectors)
            .HasForeignKey(s => s.ZoneId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Racks)
            .WithOne(r => r.Sector);
        
        
        
    }
}