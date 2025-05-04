using Warehouse.Persistence.Repositories;

namespace Warehouse.Application.Services;

public class ItemService
{
    private readonly ItemRepository _itemRepository;
    
    public ItemService(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    
    
    
}