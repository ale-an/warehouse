using Storage.Logic.Interfaces;
using Storage.Models;

namespace Storage.Logic;

/// <summary>
/// Представляет репозиторий паллет.
/// </summary>
public sealed class PalletRepository : IPalletRepository
{
    /// <summary>
    /// Создает экземпляр типа <see cref="PalletRepository"/>.
    /// </summary>
    /// <param name="storageContext">
    /// Контекст хранилища.
    /// </param>
    public PalletRepository(StorageContext storageContext)
    {
        _storageContext = storageContext;
    }

    /// <inheritdoc />
    public Pallet[] GetAll()
    {
        return _storageContext.Pallets.ToArray();
    }

    private readonly StorageContext _storageContext;
}