using Storage.Logic.Interfaces;
using Storage.Models;

namespace Storage.Logic;

/// <summary>
/// Представляет репозиторий связующей сущности паллет и коробок.
/// </summary>
public sealed class PalletBoxRepository : IPalletBoxRepository
{
    /// <summary>
    /// Создает экземпляр типа <see cref="PalletBoxRepository"/>.
    /// </summary>
    /// <param name="storageContext">
    /// Контекст хранилища.
    /// </param>
    public PalletBoxRepository(StorageContext storageContext)
    {
        _storageContext = storageContext;
    }

    /// <inheritdoc />
    public PalletBox[] GetAll()
    {
        return _storageContext.PalletBoxes.ToArray();
    }

    private readonly StorageContext _storageContext;
}