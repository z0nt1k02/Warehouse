using System.ComponentModel.DataAnnotations;

namespace Warehouse.Application.Dto.Warehouse;

public record CreateUpdateWarehouseDto
(
    [Required]
    string Name, 
    [Required]
    string Address
);