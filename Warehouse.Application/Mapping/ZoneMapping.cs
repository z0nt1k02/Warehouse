using Warehouse.Application.Dto.Warehouse;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Mapping;

public static class ZoneMapping
{
    public static ZoneShortDto ToZoneShortDto(this ZoneEntity entity)
    {
        return new ZoneShortDto(entity.Id, entity.Name, entity.WarehouseId);
    }
}