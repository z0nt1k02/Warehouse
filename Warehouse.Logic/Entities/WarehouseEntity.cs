namespace Warehouse.Logic.Entities;

public class WarehouseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; }=string.Empty;
    public List<ZoneEntity> Zones { get; set; } = [];


}