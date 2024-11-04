using Models;

namespace Logic;

/// <summary>
/// Представляет сервис для взаимодействия с клиентом.
/// </summary>
public sealed class ClientService
{
    /// <summary>
    /// Создает экземпляр типа <see cref="ClientService"/>.
    /// </summary>
    /// <param name="palletService">
    /// Сервис паллет.
    /// </param>
    public ClientService(IPalletService palletService)
    {
        _palletService = palletService;
    }
    
    /// <summary>
    /// Выводит сообщение для пользователя.
    /// </summary>
    public void Execute()
    {
        Console.WriteLine("Здравствуйте!");
        Console.WriteLine("Нажмите 1 для вывода всех паллет, " +
                          "сгруппированных по сроку годности, " +
                          "отсортированных по возрастанию срока годности, " +
                          "в каждой группе паллеты отсортированы по весу.");
        Console.WriteLine("Нажмите 2 для вывода 3 паллет, " +
                          "которые содержат коробки с наибольшим сроком годности, " +
                          "отсортированные по возрастанию объема.");
        Console.WriteLine("Нажмите 3 для завершения программы.");

        while (true)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var groupedPallets = _palletService.GetGroupedPallets();
                    foreach (var (date, pallets) in groupedPallets)
                    {
                        Console.WriteLine($"Группа, срок годности до {date: dd.MM.yyyy}");
                        foreach (var pallet in pallets)
                        {
                            WritePallet(pallet);
                        }
                    }

                    break;
                case "2":
                    var expirationalPallets = _palletService.GetMaxExpirationalPallets();
                    foreach (var pallet in expirationalPallets)
                    {
                        WritePallet(pallet);
                    }

                    break;
                case "3":
                    Console.WriteLine("Программа завершается...");
                    return;
                default:
                    Console.WriteLine("Ошибка! Введите 1, 2 или 3.");
                    break;
            }
        }
    }
    
    private void WritePallet(Pallet pallet)
    {
        Console.WriteLine(pallet);
        foreach (var box in pallet.Boxes)
        {
            Console.WriteLine($"     {box}");
        }
    }

    private readonly IPalletService _palletService;
}