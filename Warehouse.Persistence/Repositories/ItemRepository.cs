using Warehouse.Logic.Entities;

namespace Warehouse.Persistence.Repositories;

public class ItemRepository
{
    private readonly WarehouseDbContext _context;
    public ItemRepository(WarehouseDbContext context)
    {
        _context = context;
    }
    
    public async Task<ItemEntity> GetById(Guid id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task CreateItem(ItemEntity item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
    }
}