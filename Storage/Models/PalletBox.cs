using Storage.Abstractions;

namespace Storage.Models;

/// <summary>
/// Модель связующей таблицы паллет и коробок.
/// </summary>
public sealed class PalletBox : Entity
{
    /// <summary>
    /// Идентификатор паллеты.
    /// </summary>
    public required long PalletId { get; set; }

    /// <summary>
    /// Идентификатор коробки.
    /// </summary>
    public required long BoxId { get; set; }
}