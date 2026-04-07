namespace BookInventory;

/// <summary>
/// Книга в каталоге. ISBN — уникальный идентификатор для словаря.
/// </summary>
internal sealed class Book
{
    internal Book(string isbn, string title, string author)
    {
        this.Isbn = isbn;
        this.Title = title;
        this.Author = author;
    }

    internal string Isbn { get; }

    internal string Title { get; }

    internal string Author { get; }

    public override string ToString()
    {
        return $"{this.Title} — {this.Author} (ISBN: {this.Isbn})";
    }
}
