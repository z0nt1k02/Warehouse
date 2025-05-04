namespace Warehouse.Logic.Entities;

public class BoxEntity
{
    public Guid Id { get; set; }
    public int Volume { get; set; }
    public Guid? StorageCellId { get; set; }
    public StorageCellEntity? StorageCell { get; set; }
    public List<ItemEntity> Items { get; set; } = [];
    
}