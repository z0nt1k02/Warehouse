using Warehouse.Application.Interfaces;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Stores;

namespace Warehouse.Application.Services;

public class StorageCellService : IStorageCellService
{
    private readonly IStorageCellStore _storageCellRepository;

    public StorageCellService(IStorageCellStore storageCellRepository)
    {
        _storageCellRepository = storageCellRepository;
    }

    public async Task<List<StorageCellEntity>> GetByRack(Guid rackId)
    {
        return await _storageCellRepository.GetByRack(rackId);
    }

    public async Task<StorageCellEntity?> GetById(Guid id)
    {
        return await _storageCellRepository.GetById(id);
    }

    public async Task AddStorageCell(RackEntity rackEntity,int level, int row,int volume)
    {
        var storageCellEntity = new StorageCellEntity
        {
            Id = Guid.NewGuid(),
            RackId = rackEntity.Id,
            Volume = volume,
            Rack = rackEntity,
            Code = $"{rackEntity.Code}-{level.ToString()}-{row.ToString()}",
            Boxes = new List<BoxEntity>(),
            Items = new List<ItemEntity>()
        };
        await _storageCellRepository.Add(storageCellEntity);
        
    }
}