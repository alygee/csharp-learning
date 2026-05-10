namespace LinqPlayground;

/// <summary>
/// Жанр книги. Отдельная коллекция нужна, чтобы потренировать Join.
/// </summary>
internal sealed class Genre
{
    internal Genre(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    internal int Id { get; }

    internal string Name { get; }
}
