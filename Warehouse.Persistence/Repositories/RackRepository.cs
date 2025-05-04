using Microsoft.EntityFrameworkCore;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Stores;
using Warehouse.Persistence;

namespace Warehouse.Persistence.Repositories;

public class RackRepository : IRackStore
{
    private readonly WarehouseDbContext _context;

    public RackRepository(WarehouseDbContext context)
    {
        _context = context;
    }

    public async Task<List<RackEntity>> GetByZone(Guid zoneId)
    {
        return await _context.Racks
            .Include(r=>r.Cells)
            .Where(r => r.ZoneId == zoneId)
            .ToListAsync();
    }

    public async Task<RackEntity?> GetById(Guid id)
    {
        return await _context.Racks
            .Include(r => r.Cells)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task Add(RackEntity rackEntity)
    {
        await _context.Racks.AddAsync(rackEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(RackEntity rackEntity)
    {
        _context.Racks.Update(rackEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(RackEntity rackEntity)
    {
        _context.Racks.Remove(rackEntity);
        await _context.SaveChangesAsync();
    }
}