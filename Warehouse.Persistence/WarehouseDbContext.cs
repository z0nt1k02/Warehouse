
using Microsoft.EntityFrameworkCore;
using Warehouse.Logic.Entities;
using Warehouse.Persistence.Configurations;


namespace Warehouse.Persistence;

public class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : DbContext(options)
{
    public DbSet<WarehouseEntity> Warehouses { get; set; }
    public DbSet<ZoneEntity> Zones { get; set; }
    public DbSet<RackEntity> Racks { get; set; }
    public DbSet<StorageCellEntity> StorageCells { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<BoxEntity> Boxes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BoxConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new ZoneConfiguration());
        modelBuilder.ApplyConfiguration(new RackConfiguration());
        modelBuilder.ApplyConfiguration(new StorageCellConfiguration());
        modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
    }
}