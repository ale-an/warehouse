using Models;

namespace Logic;

/// <summary>
/// Представляет интерфейс сервиса паллет.
/// </summary>
public interface IPalletService
{
    /// <summary>
    /// Возвращает все паллеты,
    /// сгруппированные по сроку годности,
    /// отсортированные по возрастанию срока годности,
    /// в каждой группе паллеты отсортированы по весу.
    /// </summary>
    IReadOnlyDictionary<DateTime, Pallet[]> GetGroupedPallets();

    /// <summary>
    /// Возвращает 3 паллеты,
    /// которые содержат коробки с наибольшим сроком годности,
    /// отсортированные по возрастанию объема.
    /// </summary>
    Pallet[] GetMaxExpirationalPallets();
}