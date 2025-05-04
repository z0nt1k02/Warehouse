namespace Warehouse.Application.Dto.Rack;

public record CreateUpdateRackDto(string Code,int LevelCount, int CellsOnLevel ,int CellVolume);
