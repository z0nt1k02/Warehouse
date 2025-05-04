using Warehouse.Logic.Enums;

namespace Warehouse.Logic.Entities;

public class ZoneEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty; // "Зона разгрузки", "Зона хранения", "Зона отгрузки" и т.д.
    public ZoneType Type { get; set; } // Тип зоны (enum)
    public Guid WarehouseId { get; set; }
    public WarehouseEntity? Warehouse { get; set; }
    
    public List<RackEntity>? Racks { get; set; }=[];
}