using Warehouse.Application.Dto.Rack;

namespace Warehouse.Application.Dto.Warehouse;

public record ZoneDto(Guid id,
    string Name,
    Guid WarehouseId,
    List<RackShortDto> Racks);