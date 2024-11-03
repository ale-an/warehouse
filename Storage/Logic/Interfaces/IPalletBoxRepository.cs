using Storage.Models;

namespace Storage.Logic.Interfaces;

/// <summary>
/// Представляет интерфейс репозитория связующей сущности паллет и коробок.
/// </summary>
public interface IPalletBoxRepository
{
    /// <summary>
    /// Возвращает коллекцию связующих сущностей.
    /// </summary>
    PalletBox[] GetAll();
}