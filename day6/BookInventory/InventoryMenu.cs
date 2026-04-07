namespace BookInventory;

internal class InventoryMenu
{
    internal BookMenuChoice Choice { get; private set; }

    private static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Учёт книг (день 6)");
        Console.WriteLine("  1 — добавить книгу");
        Console.WriteLine("  2 — удалить по ISBN");
        Console.WriteLine("  3 — найти по ISBN");
        Console.WriteLine("  4 — показать все (массив + список в коде)");
        Console.WriteLine("  5 — выход");
        Console.Write("Команда: ");
    }

    private static BookMenuChoice Normalize(string? raw)
    {
        string trimmed = (raw ?? string.Empty).Trim();

        return trimmed switch
        {
            "1" => BookMenuChoice.Add,
            "2" => BookMenuChoice.Remove,
            "3" => BookMenuChoice.Find,
            "4" => BookMenuChoice.ListAll,
            "5" => BookMenuChoice.Exit,
            _ => BookMenuChoice.Unknown,
        };
    }

    internal void ReadChoice()
    {
        ShowMenu();
        string? line = Console.ReadLine();
        this.Choice = Normalize(line);
    }
}
