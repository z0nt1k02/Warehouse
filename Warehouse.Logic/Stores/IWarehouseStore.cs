using Warehouse.Logic.Entities;

namespace Warehouse.Logic.Stores;

public interface IWarehouseStore
{
    Task<List<WarehouseEntity>> Get();
    Task<WarehouseEntity?> GetById(Guid id);
    Task Add(WarehouseEntity warehouse);
    Task Update(WarehouseEntity warehouseEntity);
    Task Delete(WarehouseEntity warehouseEntity);
}