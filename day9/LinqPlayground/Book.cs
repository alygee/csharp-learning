namespace LinqPlayground;

/// <summary>
/// Книга в каталоге. Поля Year/Price/GenreId добавлены, чтобы было что
/// фильтровать, агрегировать и джойнить в LINQ-запросах.
/// </summary>
internal sealed class Book
{
    internal Book(string isbn, string title, string author, int year, decimal price, int genreId)
    {
        this.Isbn = isbn;
        this.Title = title;
        this.Author = author;
        this.Year = year;
        this.Price = price;
        this.GenreId = genreId;
    }

    internal string Isbn { get; }

    internal string Title { get; }

    internal string Author { get; }

    internal int Year { get; }

    internal decimal Price { get; }

    internal int GenreId { get; }

    public override string ToString()
    {
        return $"{this.Title} — {this.Author} ({this.Year}), {this.Price:0.00} ₽";
    }
}
