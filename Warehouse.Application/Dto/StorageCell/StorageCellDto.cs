namespace Warehouse.Application.Dto.StorageCell;

public record StorageCellDto(Guid id, string Code, int Volume, Guid RackId);
