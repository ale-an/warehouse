using Storage.Models;

namespace Storage.Logic.Interfaces;

/// <summary>
/// Представляет интерфейс репозитория коробки.
/// </summary>
public interface IBoxRepository
{
    /// <summary>
    /// Возвращает коллекцию коробок.
    /// </summary>
    Box[] GetAll();
}