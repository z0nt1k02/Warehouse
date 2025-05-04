using Warehouse.Logic.Entities;

namespace Warehouse.Logic.Stores;

public interface IZoneStore
{
    Task<IReadOnlyList<ZoneEntity>> GetByWarehouse(Guid warehouseId);
   
    Task<ZoneEntity?> GetById(Guid id);
    Task Add(ZoneEntity zone);
    Task Update(ZoneEntity zone);
    Task Delete(ZoneEntity zone);
}