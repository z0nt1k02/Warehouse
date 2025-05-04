using Warehouse.Application.Dto.Warehouse;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Interfaces;

public interface IWarehouseService
{
    Task<IReadOnlyList<WarehouseEntity>> GetAllWarehousesAsync();
    Task<WarehouseEntity?> GetById(Guid id);
    
    Task<WarehouseEntity> AddWarehouse(CreateUpdateWarehouseDto dto);
    Task UpdateWarehouse(Guid id,CreateUpdateWarehouseDto dto);
    
    Task DeleteWarehouse(Guid id);
}