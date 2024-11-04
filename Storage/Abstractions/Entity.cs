namespace Storage.Abstractions;

/// <summary>
/// Базовая модель в базе данных.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Идентификатор объекта.
    /// </summary>
    public long Id { get; set; }
}