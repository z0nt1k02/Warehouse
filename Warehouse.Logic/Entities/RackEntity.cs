namespace Warehouse.Logic.Entities;

public class RackEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty; // Уникальный код стеллажа 
    public Guid ZoneId { get; set; }
    public ZoneEntity? Zone { get; set; }
    public int LevelsCount { get; set; } // Количество уровней (полок)
    public int CellsPerLevel { get; set; } // Количество ячеек на уровне
    public List<StorageCellEntity> Cells { get; set; } = [];
}