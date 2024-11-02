namespace Models;

/// <summary>
/// Модель коробки.
/// </summary>
public sealed class Box : WarehouseObject
{
    /// <summary>
    /// Дата производства.
    /// </summary>
    public DateTime? ProductionDate { get; set; }

    /// <summary>
    /// Срок годности.
    /// </summary>
    public DateTime ExpirationDate { get; set; }

    /// <summary>
    /// Создает экземпляр типа <see cref="Box"/>.
    /// </summary>
    /// <param name="id">
    /// Идентификатор коробки.
    /// </param>
    /// <param name="length">
    /// Длина коробки.
    /// </param>
    /// <param name="width">
    /// Ширина коробки.
    /// </param>
    /// <param name="height">
    /// Высота коробки.
    /// </param>
    /// <param name="weight">
    /// Вес коробки.
    /// </param>
    /// <param name="productionDate">
    /// Дата производства коробки.
    /// </param>
    /// <param name="expirationDate">
    /// Срок годности коробки.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Вызывается, когда нет и даты производства, и срока годности.
    /// </exception>
    public Box(
        long id,
        int length,
        int width,
        int height,
        double weight,
        DateTime? productionDate,
        DateTime? expirationDate)
        : base(id, length, width, height, weight)
    {
        if (expirationDate == null && productionDate == null)
        {
            throw new ArgumentException("Ошибка! Должна быть указана дата производства или срок годности");
        }

        ProductionDate = productionDate;
        ExpirationDate = expirationDate ?? productionDate!.Value.AddDays(100);
    }
}