using Warehouse.Logic.Entities;

namespace Warehouse.Application.Interfaces;

public interface IStorageCellService
{
    public Task<List<StorageCellEntity>> GetByRack(Guid rackId);
    public Task<StorageCellEntity?> GetById(Guid id);
}