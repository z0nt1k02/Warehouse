namespace Warehouse.Application.Dto.Rack;

public record CreateUpdateRackDto(Guid ZoneId,string Code,int LevelCount, int CellsOnLevel ,int CellVolume);
