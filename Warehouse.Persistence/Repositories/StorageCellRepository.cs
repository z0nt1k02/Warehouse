using Microsoft.EntityFrameworkCore;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Stores;


namespace Warehouse.Persistence.Repositories;

public class StorageCellRepository : IStorageCellEntity
{
    private readonly WarehouseDbContext _context;

    public StorageCellRepository(WarehouseDbContext context)
    {
        _context = context;
    }

    public async Task<List<StorageCellEntity>> GetByRack(Guid rackId)
    {
        return await _context.StorageCells
            .Include(s=>s.Boxes)
            .Include(s=>s.Items)
            .Where(sc => sc.RackId == rackId)
            .ToListAsync();
    }

    public async Task<StorageCellEntity?> GetById(Guid id)
    {
        return await _context.StorageCells
            .Include(s => s.Boxes)
            .Include(s => s.Items)
            .FirstOrDefaultAsync(sc => sc.Id == id);
    }

    public async Task Add(StorageCellEntity storageCellEntity)
    {
        await _context.StorageCells.AddAsync(storageCellEntity);
        await _context.SaveChangesAsync();
    }
}