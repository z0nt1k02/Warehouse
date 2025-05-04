using Warehouse.Application.Dto.Warehouse;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Mapping;

public static class WarehouseMapper
{
    public static WarehouseDto ToDto(this WarehouseEntity entity)
    {
        return new WarehouseDto(entity.Id,entity.Name,
            entity.Address,
            entity.Zones.Select(z => z.ToZoneShortDto()).ToList());
    }
}