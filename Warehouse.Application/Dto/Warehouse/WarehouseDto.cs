namespace Warehouse.Application.Dto.Warehouse;

public record WarehouseDto(Guid Id,string Name,
    string Address,
    List<ZoneShortDto> Zones);