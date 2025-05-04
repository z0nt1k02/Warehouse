using Warehouse.Application.Dto.Warehouse;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Enums;

namespace Warehouse.Application.Interfaces;

public interface IZoneService
{
    Task<IReadOnlyList<ZoneEntity>> GetByWarehouse(Guid warehouseId);
    Task<ZoneEntity?> GetById(Guid id);
    Task<ZoneEntity> AddZone(string name,ZoneType zoneType,WarehouseEntity warehouse);
    List<string> GetZoneNames();
    
}