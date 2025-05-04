using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Configurations;

public class RackConfiguration : IEntityTypeConfiguration<RackEntity>
{
    public void Configure(EntityTypeBuilder<RackEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Sector)
            .WithMany(x => x.Racks)
            .HasForeignKey(x => x.SectorId);
        
        builder.HasMany(r=>r.Cells)
            .WithOne(x => x.Rack)
            .HasForeignKey(x => x.RackId);

    }
}