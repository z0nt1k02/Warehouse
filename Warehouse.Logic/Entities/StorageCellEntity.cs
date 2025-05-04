namespace Warehouse.Logic.Entities;

public class StorageCellEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty; // Уникальный код ячейки (например: "A1-02-03" - Стеллаж A1, уровень 2, ячейка 3)
    public Guid RackId { get; set; }
    public RackEntity? Rack { get; set; }
    public int Level { get; set; } // Номер уровня (полки)
    public int Position { get; set; } // Позиция на уровне
    public int Capacity { get; set; }
    public List<ItemEntity> Items { get; set; } = [];
    public List<BoxEntity> Boxes { get; set; } = [];
}