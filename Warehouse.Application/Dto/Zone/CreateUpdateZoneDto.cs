using System.ComponentModel.DataAnnotations;

namespace Warehouse.Application.Dto.Warehouse;

public record CreateUpdateZoneDto
(
    [Required]
    [StringLength(40, MinimumLength = 3)]
    string Name,

    [Required]
    Guid WarehouseId 
);