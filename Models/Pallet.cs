using Abstractions;

namespace Models;

/// <summary>
/// Модель паллеты.
/// </summary>
public sealed class Pallet : WarehouseObject
{
    /// <summary>
    /// Срок годности.
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Коробки в паллете.
    /// </summary>
    public IReadOnlyCollection<Box> Boxes { get; set; }

    /// <summary>
    /// Создает экземпляр типа <see cref="Pallet"/>.
    /// </summary>
    /// <param name="id">
    /// Идентификатор паллеты.
    /// </param>
    /// <param name="length">
    /// Длина паллеты.
    /// </param>
    /// <param name="width">
    /// Ширина паллеты.
    /// </param>
    /// <param name="height">
    /// Высота паллеты.
    /// </param>
    /// <param name="boxes">
    /// Коробки в паллете.
    /// </param>
    /// <exception cref="Exception">
    /// Вызывается, когда в паллете нет коробки или когда коробка больше, чем паллета.
    /// </exception>
    public Pallet(
        long id,
        int length,
        int width,
        int height,
        IReadOnlyCollection<Box> boxes)
        : base(id, length, width, height, boxes.Sum(x => x.Weight) + 30)
    {
        if (boxes.Count == 0)
        {
            throw new ArgumentException("Ошибка! Паллета не может быть пустой");
        }

        if (boxes.Any(x => x.Length > Length || x.Width > Width))
        {
            throw new ArgumentException("Ошибка! Паллета не может быть меньше коробки");
        }

        ExpirationDate = boxes.Min(x => x.ExpirationDate);
        Boxes = boxes;
    }

    /// <inheritdoc />
    public override int Volume()
    {
        return Boxes.Sum(x => x.Volume()) + base.Volume();
    }
}