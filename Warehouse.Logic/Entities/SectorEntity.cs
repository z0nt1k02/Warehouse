namespace Warehouse.Logic.Entities;

public class SectorEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;// Например: "Сектор A", "Сектор B"
    public Guid ZoneId { get; set; }
    public ZoneEntity? Zone { get; set; }
    public List<RackEntity> Racks { get; set; } = [];
}