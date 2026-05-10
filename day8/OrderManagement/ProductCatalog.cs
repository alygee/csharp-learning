namespace OrderManagement;

internal sealed class ProductCatalog
{
    private readonly List<Product> _items =
    [
        new Product(Guid.NewGuid(), "Ноутбук", 75999.50m, 5),
        new Product(Guid.NewGuid(), "Беспроводная мышь", 2490m, 20),
        new Product(Guid.NewGuid(), "Клавиатура", 3990m, 12),
        new Product(Guid.NewGuid(), "Монитор 27\"", 18990m, 7),
    ];

    internal IReadOnlyList<Product> Items => this._items;

    internal int Count => this._items.Count;

    internal bool IsEmpty => this._items.All(product => product.StockQuantity == 0);

    internal Product GetByNumber(int number)
    {
        if (number < 1 || number > this._items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Номер товара вне диапазона каталога.");
        }

        return this._items[number - 1];
    }
}
