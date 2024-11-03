namespace Abstractions;

/// <summary>
/// Базовая модель объекта склада.
/// </summary>
public abstract class WarehouseObject
{
    /// <summary>
    /// Идентификатор объекта склада.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Длина объекта склада.
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

    /// <summary>
    /// Создает экземпляр типа <see cref="WarehouseObject"/>.
    /// </summary>
    /// <param name="id">
    /// Идентификатор объекта склада.
    /// </param>
    /// <param name="length">
    /// Длина объекта склада.
    /// </param>
    /// <param name="width">
    /// Ширина объекта склада.
    /// </param>
    /// <param name="height">
    /// Высота объекта склада.
    /// </param>
    /// <param name="weight">
    /// Вес объекта склада.
    /// </param>
    protected WarehouseObject(
        long id,
        int length,
        int width,
        int height,
        double weight)
    {
        Id = id;
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }

    /// <summary>
    /// Вычисляет объем объекта склада.
    /// </summary>
    public virtual int Volume()
    {
        return Length * Width * Height;
    }
}