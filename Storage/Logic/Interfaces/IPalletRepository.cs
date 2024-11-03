using Storage.Models;

namespace Storage.Logic.Interfaces;

/// <summary>
/// Представляет интерфейс репозитория паллеты.
/// </summary>
public interface IPalletRepository
{
    /// <summary>
    /// Возвращает коллекцию паллет.
    /// </summary>
    Pallet[] GetAll();
}