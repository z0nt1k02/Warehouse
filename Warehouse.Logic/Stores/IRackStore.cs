using Warehouse.Logic.Entities;

namespace Warehouse.Logic.Stores;

public interface IRackStore
{
    Task<List<RackEntity>> GetByZone(Guid zoneId);
    Task<RackEntity?> GetById(Guid id);
    Task Add(RackEntity rackEntity);
    Task Update(RackEntity rackEntity);
    Task Delete(RackEntity rackEntity);
}