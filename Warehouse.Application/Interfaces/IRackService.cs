using Warehouse.Application.Dto.Rack;
using Warehouse.Logic.Entities;

namespace Warehouse.Application.Interfaces;

public interface IRackService
{
    Task<IReadOnlyList<RackEntity>> GetByZone(Guid zoneId);
    Task<RackEntity?> GetById(Guid id);
    
    Task<RackEntity> AddRack(CreateUpdateRackDto dto);
    Task UpdateRack(Guid id,CreateUpdateRackDto dto);
    
    Task DeleteRack(Guid id);
}