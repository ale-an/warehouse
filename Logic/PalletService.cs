using System.Collections.ObjectModel;
using Models;
using Storage.Logic.Interfaces;

namespace Logic;

/// <summary>
/// Представляет сервис паллет.
/// </summary>
public sealed class PalletService : IPalletService
{
    /// <summary>
    /// Создает экземпляр типа <see cref="PalletService"/>.
    /// </summary>
    /// <param name="boxRepository">
    /// Репозиторий коробок.
    /// </param>
    /// <param name="palletBoxRepository">
    /// Репозиторий связующей сущности паллет и коробок.
    /// </param>
    /// <param name="palletRepository">
    /// Репозиторий паллет.
    /// </param>
    public PalletService(
        IBoxRepository boxRepository,
        IPalletBoxRepository palletBoxRepository,
        IPalletRepository palletRepository)
    {
        _boxRepository = boxRepository;
        _palletBoxRepository = palletBoxRepository;
        _palletRepository = palletRepository;
    }

    /// <inheritdoc />
    public IReadOnlyDictionary<DateTime, Pallet[]> GetGroupedPallets()
    {
        var pallets = GetPallets();

        return pallets.GroupBy(
                x => x.ExpirationDate,
                (key, list) =>
                    new
                    {
                        Key = key,
                        Pallets = list.OrderBy(p => p.Weight)
                    })
            .OrderBy(x => x.Key)
            .ToDictionary(z => z.Key, z => z.Pallets.ToArray());
    }

    /// <inheritdoc />
    public Pallet[] GetMaxExpirationalPallets()
    {
        var pallets = GetPallets();

        return pallets
            .OrderByDescending(x => x.Boxes.Max(b => b.ExpirationDate))
            .Take(3)
            .OrderBy(x => x.Volume())
            .ToArray();
    }

    private Pallet[] GetPallets()
    {
        var pallets = _palletRepository.GetAll();
        var boxes = _boxRepository.GetAll();
        var palletsBoxes = _palletBoxRepository.GetAll();

        var groupedBoxes = palletsBoxes.GroupJoin(
            boxes,
            pb => pb.BoxId,
            b => b.Id,
            (pb, b) =>
                new
                {
                    pb.PalletId,
                    Boxes = b.Select(x =>
                            new Box(
                                x.Id,
                                x.Length,
                                x.Width,
                                x.Height,
                                x.Weight,
                                x.ProductionDate,
                                x.ExpirationDate))
                        .ToArray()
                }
        );

        return pallets.GroupJoin(groupedBoxes,
                p => p.Id,
                gb => gb.PalletId,
                (p, gb) =>
                    new Pallet(
                        p.Id,
                        p.Length,
                        p.Width,
                        p.Height,
                        new ReadOnlyCollection<Box>(gb.SelectMany(z => z.Boxes).ToList())))
            .ToArray();
    }

    private readonly IBoxRepository _boxRepository;
    private readonly IPalletBoxRepository _palletBoxRepository;
    private readonly IPalletRepository _palletRepository;
}