using Storage.Models;

namespace Storage.Logic;

/// <summary>
/// Контекст хранилища данных.
/// </summary>
public sealed class StorageContext
{
    /// <summary>
    /// Коллекция паллет.
    /// </summary>
    public List<Pallet> Pallets { get; } = new();
    
    /// <summary>
    /// Коллекция коробок.
    /// </summary>
    public List<Box> Boxes { get; } = new();
    
    /// <summary>
    /// Коллекция связующих сущностей.
    /// </summary>
    public List<PalletBox> PalletBoxes { get; } = new();

    /// <summary>
    /// Создает экземпляр типа <see cref="StorageContext"/>.
    /// </summary>
    /// <remarks>
    /// Заполняет хранилище данными.
    /// </remarks>
    public StorageContext()
    {
        for (int i = 1; i < 6; i++)
        {
            Pallets.Add(new Pallet
            {
                Id = i,
                Length = 10 * i,
                Width = 10 * i,
                Height = 10 * i,
            });
        }

        for (int i = 1; i < 13; i++)
        {
             Boxes.Add(new Box
             {
                 Id = i,
                 Length = 2 * i,
                 Width = 2 * i,
                 Height = 2 * i,
                 Weight = 2 * i,
                 ExpirationDate = new DateTime(2025, i, 1),
                 ProductionDate = i % 2 == 0 ? new DateTime(2024, 11, 3) : null
             });
             
             PalletBoxes.Add(new PalletBox
             {
                 Id = i,
                 PalletId = (i + 1) % 2,
                 BoxId = i
             });
        }
    }
}