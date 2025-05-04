namespace Warehouse.Logic.Entities;

public class ItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public string Article { get; set; } = string.Empty;// Артикул
    public int Volume { get; set; }
    public Guid BoxId { get; set; }
    public BoxEntity? Box { get; set; }
    public Guid StorageCellId { get; set; }
    public StorageCellEntity? StorageCell { get; set; }
    public int ProductTypeId { get; set; }
}