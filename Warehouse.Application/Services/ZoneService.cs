using Warehouse.Application.Dto.Warehouse;
using Warehouse.Application.Interfaces;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Enums;
using Warehouse.Logic.Stores;

namespace Warehouse.Application.Services;

public class ZoneService : IZoneService
{
    private readonly IZoneStore _zoneStore;
    public List<string> Zonenames = new List<string>
    {
        "Зона приема",
        "Зона хранения",
        "Зона отгрузки",
    };

    public ZoneService(IZoneStore zoneStore)
    {
        _zoneStore = zoneStore;
    }


    public async Task<IReadOnlyList<ZoneEntity>> GetByWarehouse(Guid warehouseId)
    {
        var zones = await _zoneStore.GetByWarehouse(warehouseId);
        return zones;
    }

    public Task<ZoneEntity?> GetById(Guid id)
    {
        var zone = _zoneStore.GetById(id);
        if (zone == null)
            throw new Exception($"Zone with id: {id} not found");
        return zone;
    }

    
    public async Task<ZoneEntity> AddZone(string name,ZoneType zoneType,WarehouseEntity warehouse)
    {
        var newZone = new ZoneEntity
        {
            Id = Guid.NewGuid(),
            Name = name,
            WarehouseId = warehouse.Id,
            Warehouse = warehouse,
            Type = zoneType,
        };
        await _zoneStore.Add(newZone);
        return newZone;
    }

    public List<string> GetZoneNames()
    {
        return Zonenames;
    }
}