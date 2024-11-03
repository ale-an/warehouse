using Abstractions;

namespace Storage.Models;

/// <summary>
/// Модель коробки в базе данных.
/// </summary>
public sealed class Box : WarehouseExpirationalEntity
{
    /// <summary>
    /// Вес объекта склада.
    /// </summary>
    public double Weight { get; set; }
    
    /// <summary>
    /// Дата производства.
    /// </summary>
    public required DateTime? ProductionDate { get; set; }
}