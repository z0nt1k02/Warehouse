using Warehouse.Application.Dto.Rack;
using Warehouse.Application.Interfaces;
using Warehouse.Logic.Entities;
using Warehouse.Logic.Enums;
using Warehouse.Logic.Stores;
using Warehouse.Persistence;

namespace Warehouse.Application.Services;

public class RackService : IRackService
{
    private readonly IRackStore _rackStore;
    private readonly IStorageCellService _storageCellService;
    private readonly IZoneService _zoneService;
    private readonly WarehouseDbContext _context;
    

    public RackService(IRackStore rackStore,IStorageCellService storageCellService,IZoneService zoneService,WarehouseDbContext context)
    {
        _rackStore = rackStore;
        _storageCellService = storageCellService;
        _zoneService = zoneService;
        _context = context;
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
        var zone = await _zoneService.GetById(dto.ZoneId);
        if (zone == null || zone.Type != ZoneType.Storage)
            throw new NullReferenceException("Zone not found");
        
        var rack = new RackEntity
        {
            Id = Guid.NewGuid(),
            Code = dto.Code,
            LevelsCount = dto.LevelCount,
            CellsPerLevel = dto.CellsOnLevel,
            Cells = new List<StorageCellEntity>(),
            Zone = zone,
            ZoneId = zone.Id
        };
        await _rackStore.Add(rack);
        await CreateStorageCell(rack,dto.CellVolume);
        await _context.SaveChangesAsync();
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

    private async Task CreateStorageCell(RackEntity rackEntity,int volume )
    {
        for(int i = 0;i<rackEntity.LevelsCount;i++)
        {
            for(int j = 0;j<rackEntity.CellsPerLevel;j++)
            {
                await _storageCellService.AddStorageCell(rackEntity,i+1,j+1,volume);
            }
        }
    }
}