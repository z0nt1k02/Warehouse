using Microsoft.EntityFrameworkCore;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Stores;

namespace Warehouse.Persistence.Repositories;

public class WarehouseRepository : IWarehouseStore
{
    private readonly WarehouseDbContext _context;

    public WarehouseRepository(WarehouseDbContext context)
    {
        _context = context;
    }


    public async Task<List<WarehouseEntity>> Get()
    {
        var warehouses = await _context.Warehouses
            .Include(z=>z.Zones)
            .AsNoTracking()
            .ToListAsync();
        return warehouses;
    }

    public async Task<WarehouseEntity?> GetById(Guid id)
    {
        var warehouse = await _context.Warehouses
            .Include(z=>z.Zones)
            .AsNoTracking()
            .FirstOrDefaultAsync(z => z.Id == id);
        return warehouse;
    }

    public async Task Add(WarehouseEntity warehouse)
    {
        _context.Warehouses.Add(warehouse);
        await _context.SaveChangesAsync();
        
    }

    public async Task Update(WarehouseEntity warehouseEntity)
    {
        _context.Warehouses.Update(warehouseEntity);
        await _context.SaveChangesAsync();
    }

    public Task Delete(WarehouseEntity warehouseEntity)
    {
        _context.Warehouses.Remove(warehouseEntity);
        return _context.SaveChangesAsync();
    }
}