using Warehouse.Logic.Entities;

namespace Warehouse.Application.Interfaces;

public interface IStorageCellService
{
    public Task<List<StorageCellEntity>> GetByRack(Guid rackId);
    public Task<StorageCellEntity?> GetById(Guid id);

    public Task AddStorageCell(RackEntity rackEntity, int level, int row, int volume);
}