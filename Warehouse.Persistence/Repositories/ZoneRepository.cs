using Warehouse.Logic.Entities;
using Warehouse.Logic.Stores;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Persistence.Repositories;

public class ZoneRepository : IZoneStore
{
    private readonly WarehouseDbContext _context;

    public ZoneRepository(WarehouseDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ZoneEntity>> GetByWarehouse(Guid warehouseId)
    {
        var zones = await _context.Zones
            .Include(x=>x.Racks)
            .Where(z => z.WarehouseId == warehouseId)
            .ToListAsync();
        return zones;
    }

    public async Task<ZoneEntity?> GetById(Guid id)
    {
        return await _context.Zones
            .Include(x=>x.Racks)
            .FirstOrDefaultAsync(z => z.Id == id);
    }

    public async Task Add(ZoneEntity zone)
    {
        await _context.Zones.AddAsync(zone);
        await _context.SaveChangesAsync();
    }

    public async Task Update(ZoneEntity zone)
    {
        _context.Zones.Update(zone);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(ZoneEntity zone)
    {
        _context.Zones.Remove(zone);
        await _context.SaveChangesAsync();
    }
}