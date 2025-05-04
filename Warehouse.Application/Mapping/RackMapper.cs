using Warehouse.Application.Dto.Rack;
using Warehouse.Application.Dto.StorageCell;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Mapping;

public static class RackMapper
{
    public static RackDto ToDto(this RackEntity rackEntity)
    {
        return new RackDto(
            rackEntity.Id,
            rackEntity.Code,
            rackEntity.Cells?.Select(sc=>sc.ToShortDto()).ToList() ?? new List<StorageCellShortDto>()
        );
    }

    public static RackShortDto ToShortDto(this RackEntity rackEntity)
    {
        return new RackShortDto(rackEntity.Id,rackEntity.Code);
    }
}