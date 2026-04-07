namespace BookInventory;

/// <summary>
/// Консольное приложение учёта книг: цикл меню, разбор команд и вызовы хранилища <see cref="BookInventoryStore"/>.
/// </summary>
internal sealed class BookInventoryApp
{
    private readonly InventoryMenu _menu;
    private readonly BookInventoryStore _store = new();

    internal BookInventoryApp(InventoryMenu menu)
    {
        this._menu = menu;
    }

    internal void Run()
    {
        Console.WriteLine("Заготовка «день 6»: массивы, List<T>, Dictionary.");

        while (true)
        {
            this._menu.ReadChoice();

            switch (this._menu.Choice)
            {
                case BookMenuChoice.Add:
                    this.TryAddFromConsole();
                    break;
                case BookMenuChoice.Remove:
                    this.TryRemoveFromConsole();
                    break;
                case BookMenuChoice.Find:
                    this.TryFindFromConsole();
                    break;
                case BookMenuChoice.ListAll:
                    this.PrintAll();
                    break;
                case BookMenuChoice.Exit:
                    Console.WriteLine("До свидания.");
                    return;
                case BookMenuChoice.Unknown:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }

    private void TryAddFromConsole()
    {
        Console.Write("ISBN: ");
        string? isbn = Console.ReadLine();
        Console.Write("Название: ");
        string? title = Console.ReadLine();
        Console.Write("Автор: ");
        string? author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Все поля должны быть заполнены.");
            return;
        }

        Book book = new Book(isbn, title, author);
        if (this._store.TryAdd(book))
        {
            Console.WriteLine("Книга добавлена.");
        }
    }

    private void TryRemoveFromConsole()
    {
        Console.Write("ISBN для удаления: ");
        string? isbn = Console.ReadLine() ?? string.Empty;
        if (this._store.TryRemove(isbn))
        {
            Console.WriteLine("Удалено.");
        }
        else
        {
            Console.WriteLine("Книга с таким ISBN не найдена.");
        }
    }

    private void TryFindFromConsole()
    {
        Console.Write("ISBN для поиска: ");
        string? isbn = Console.ReadLine() ?? string.Empty;
        if (this._store.TryGet(isbn, out Book? book))
        {
            Console.WriteLine($"Найдено: {book}");
        }
        else
        {
            Console.WriteLine("Не найдено.");
        }
    }

    private void PrintAll()
    {
        if (this._store.Count == 0)
        {
            Console.WriteLine("Каталог пуст.");
            return;
        }

        // Массив: снимок Values
        Book[] array = this._store.GetAllBooksAsArray();
        Console.WriteLine($"Всего книг (массив, Length={array.Length}):");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"  [{i}] {array[i]}");
        }

        // List: тот же набор, можно дальше сортировать и т.д.
        List<Book> list = this._store.GetAllBooksAsList();
        Console.WriteLine($"Список (List.Count={list.Count}) — порядок может отличаться от словаря:");
        foreach (Book book in list)
        {
            Console.WriteLine($"  - {book}");
        }
    }
}
