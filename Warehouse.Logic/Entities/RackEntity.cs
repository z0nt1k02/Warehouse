namespace Warehouse.Logic.Entities;

public class RackEntity
{
    public Guid Id { get; set; }
    public string Code { get; set; } // Уникальный код стеллажа (например: "RACK-001")
    public Guid SectorId { get; set; }
    public SectorEntity? Sector { get; set; }
    public int LevelsCount { get; set; } // Количество уровней (полок)
    public int CellsPerLevel { get; set; } // Количество ячеек на уровне
    public List<StorageCellEntity> Cells { get; set; } = [];
}