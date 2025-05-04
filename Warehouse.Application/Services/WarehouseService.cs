using Warehouse.Application.Dto.Warehouse;
using Warehouse.Application.Interfaces;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Enums;
using Warehouse.Logic.Stores;

namespace Warehouse.Application.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseStore _warehouseStore;
    private readonly IZoneService _zoneService;
    public WarehouseService(IWarehouseStore warehouseStore,IZoneService zoneService)
    {
        _warehouseStore = warehouseStore;
        _zoneService = zoneService;
    }
    public async Task<IReadOnlyList<WarehouseEntity>> GetAllWarehousesAsync()
    {
        var warehouses = await _warehouseStore.Get();
        return warehouses;
    }

    public Task<WarehouseEntity?> GetById(Guid id)
    {
        var warehouse = _warehouseStore.GetById(id);
        if(warehouse == null)
             throw new Exception($"Warehouse with id: {id} not found");
        return warehouse;
    }

    public async Task<WarehouseEntity> AddWarehouse(CreateUpdateWarehouseDto dto)
    {
        var newWarehouse = new WarehouseEntity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Address = dto.Address,
            Zones = new List<ZoneEntity>()
        };
        
        await  _warehouseStore.Add(newWarehouse);
        await CreateZones(newWarehouse);
        return newWarehouse;
    }

    public async Task UpdateWarehouse(Guid id, CreateUpdateWarehouseDto dto)
    {
        var updatableWarehouse = await _warehouseStore.GetById(id);
        if(updatableWarehouse == null)
            throw new Exception($"Warehouse with id: {id} not found");
        updatableWarehouse.Name = dto.Name;
        updatableWarehouse.Address = dto.Address;
        await _warehouseStore.Update(updatableWarehouse);
    }

    public async Task DeleteWarehouse(Guid id)
    {
        var deletedWarehouse = await _warehouseStore.GetById(id);
        if (deletedWarehouse == null)
            throw new Exception($"Warehouse with id: {id} not found");
        await _warehouseStore.Delete(deletedWarehouse);
    }

    private async Task CreateZones(WarehouseEntity warehouse)
    {
        var zoneNames = _zoneService.GetZoneNames();
        var values = (ZoneType[])Enum.GetValues(typeof(ZoneType));
        for (var i = 0; i < zoneNames.Count; i++)
        {
            await _zoneService.AddZone(zoneNames[i], values[i], warehouse);
        }
    }
    
    
}