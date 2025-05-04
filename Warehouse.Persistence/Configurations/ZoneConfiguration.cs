using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class ZoneConfiguration : IEntityTypeConfiguration<ZoneEntity>
{
    public void Configure(EntityTypeBuilder<ZoneEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Warehouse)
            .WithMany(x => x.Zones);
        
        builder.HasMany(z=>z.Sectors)
            .WithOne(s=>s.Zone)
            .HasForeignKey(s=>s.ZoneId);
    }
}