using Warehouse.Application.Dto.Rack;
using Warehouse.Application.Interfaces;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Stores;

namespace Warehouse.Application.Services;

public class RackService : IRackService
{
    private readonly IRackStore _rackStore;
    private readonly StorageCellService _storageCellService;

    public RackService(IRackStore rackStore,StorageCellService storageCellService)
    {
        _rackStore = rackStore;
        _storageCellService = storageCellService;
    }

    public async Task<IReadOnlyList<RackEntity>> GetByZone(Guid zoneId)
    {
        return await _rackStore.GetByZone(zoneId);
    }
    

    public async Task<RackEntity?> GetById(Guid id)
    {
        return await _rackStore.GetById(id);
    }

    public async Task<RackEntity> AddRack(CreateUpdateRackDto dto)
    {
        var rack = new RackEntity
        {
            Id = Guid.NewGuid(),
            // Заполните свойства объекта `RackEntity` из `dto`
            Code = dto.Code,
            LevelsCount = dto.LevelCount,
            CellsPerLevel = dto.CellsOnLevel,
            Cells = new List<StorageCellEntity>()
        };
        await _rackStore.Add(rack);
        await CreateStorageCell(rack);
        return rack;
    }

    public async Task UpdateRack(Guid id, CreateUpdateRackDto dto)
    {
        var existingRack = await _rackStore.GetById(id);
        if (existingRack == null)
        {
            throw new KeyNotFoundException("Rack not found");
        }

        // Обновите свойства `existingRack` из `dto`

        await _rackStore.Update(existingRack);
    }

    public async Task DeleteRack(Guid id)
    {
        var rack = await _rackStore.GetById(id);
        if (rack == null)
        {
            throw new KeyNotFoundException("Rack not found");
        }

        await _rackStore.Delete(rack);
    }

    private async Task CreateStorageCell(RackEntity rackEntity)
    {
        for(int i = 0;i<rackEntity.LevelsCount;i++)
        {
            for(int j = 0;j<rackEntity.CellsPerLevel;j++)
            {
                /*await _storageCellService.AddStorageCell(rackEntity,i+1,j+1);*/
            }
        }
    }
}