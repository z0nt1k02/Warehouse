﻿using Warehouse.Application.Dto.StorageCell;

namespace Warehouse.Application.Dto.Rack;

public record RackDto(Guid Id,string Code,List<StorageCellShortDto> cells);