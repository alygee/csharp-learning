namespace BookInventory;

/// <summary>
/// Каталог: основное хранилище — Dictionary по ISBN.
/// Дополнительно показаны копия в массив и список для учебных целей.
/// </summary>
internal sealed class BookInventoryStore
{
    private readonly Dictionary<string, Book> _byIsbn = new(StringComparer.OrdinalIgnoreCase);

    internal bool TryAdd(Book book)
    {
        string key = NormalizeIsbn(book.Isbn);
        if (string.IsNullOrWhiteSpace(key))
        {
            Console.WriteLine("ISBN не может быть пустым.");
            return false;
        }

        if (this._byIsbn.ContainsKey(key))
        {
            Console.WriteLine("Книга с таким ISBN уже есть.");
            return false;
        }

        Book normalized = new Book(key, book.Title, book.Author);
        this._byIsbn.Add(key, normalized);
        return true;
    }

    internal bool TryRemove(string isbn)
    {
        string key = NormalizeIsbn(isbn);
        if (string.IsNullOrWhiteSpace(key))
        {
            Console.WriteLine("ISBN не может быть пустым.");
            return false;
        }

        return this._byIsbn.Remove(key);
    }

    internal bool TryGet(string isbn, out Book? book)
    {
        string key = NormalizeIsbn(isbn);
        return this._byIsbn.TryGetValue(key, out book);
    }

    /// <summary>
    /// Снимок каталога в массив (фиксированная коллекция после копирования).
    /// </summary>
    internal Book[] GetAllBooksAsArray()
    {
        Book[] result = new Book[this._byIsbn.Count];
        int index = 0;
        foreach (Book book in this._byIsbn.Values)
        {
            result[index] = book;
            index++;
        }

        return result;
    }

    /// <summary>
    /// Тот же набор книг в виде List — удобно сортировать/дополнять по ходу программы.
    /// </summary>
    internal List<Book> GetAllBooksAsList()
    {
        return new List<Book>(this._byIsbn.Values);
    }

    internal int Count => this._byIsbn.Count;

    private static string NormalizeIsbn(string isbn)
    {
        return isbn.Trim();
    }
}
