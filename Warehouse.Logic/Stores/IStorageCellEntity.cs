using Warehouse.Logic.Entities;

namespace Warehouse.Logic.Stores;

public interface IStorageCellEntity
{
    Task<List<StorageCellEntity>> GetByRack(Guid zoneId);
    Task<StorageCellEntity?> GetById(Guid id);
    Task Add(StorageCellEntity rackEntity);
    
}