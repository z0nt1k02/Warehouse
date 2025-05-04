using Warehouse.Application.Dto.Rack;
using Warehouse.Application.Dto.Warehouse;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Mapping;

public static class ZoneMapping
{
    public static ZoneDto ToDto(this ZoneEntity entity)
    {
        return new ZoneDto(entity.Id, entity.Name, entity.WarehouseId, entity.Racks?.Select(r => r.ToShortDto()).ToList() ?? new List<RackShortDto>());
    }
    public static ZoneShortDto ToZoneShortDto(this ZoneEntity entity)
    {
        return new ZoneShortDto(entity.Id, entity.Name, entity.WarehouseId);
    }
}