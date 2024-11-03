namespace Abstractions;

/// <summary>
/// Базовая модель объекта склада в базе данных.
/// </summary>
public abstract class WarehouseEntity : Entity
{
    /// <summary>
    /// Длина объекта класса.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Ширина объекта склада.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота объекта склада.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Вес объекта склада.
    /// </summary>
    public double Weight { get; set; }
}