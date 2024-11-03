using Storage.Logic.Interfaces;
using Storage.Models;

namespace Storage.Logic;

/// <summary>
/// Представляет репозиторий коробок.
/// </summary>
public sealed class BoxRepository : IBoxRepository
{
    /// <summary>
    /// Создает экземпляр типа <see cref="BoxRepository"/>.
    /// </summary>
    /// <param name="storageContext">
    /// Контекст хранилища.
    /// </param>
    public BoxRepository(StorageContext storageContext)
    {
        _storageContext = storageContext;
    }

    /// <inheritdoc />
    public Box[] GetAll()
    {
        return _storageContext.Boxes.ToArray();
    }
    
    private readonly StorageContext _storageContext;
}