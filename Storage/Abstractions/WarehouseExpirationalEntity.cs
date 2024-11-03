namespace Abstractions;

/// <summary>
/// Базовая модель объекта склада с истекающим сроком годности в базе данных.
/// </summary>
public abstract class WarehouseExpirationalEntity : WarehouseEntity
{
    /// <summary>
    /// Срок годности объекта склада.
    /// </summary>
    public DateTime ExpirationDate { get; set; }
}