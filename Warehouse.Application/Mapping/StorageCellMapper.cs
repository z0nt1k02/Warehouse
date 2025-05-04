using Warehouse.Application.Dto.StorageCell;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Mapping;

public static class StorageCellMapper
{
    public static StorageCellDto ToDto(this StorageCellEntity entity)
    {
        return new StorageCellDto(entity.Id, entity.Code, entity.Volume, entity.RackId);
    }

    public static StorageCellShortDto ToShortDto(this StorageCellEntity entity)
    {
        return new StorageCellShortDto(entity.RackId, entity.Code);
    }
}