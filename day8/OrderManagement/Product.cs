namespace OrderManagement;

internal sealed class Product
{
    internal Product(Guid id, string name, decimal price, int stockQuantity)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Цена должна быть больше 0.");
        }

        if (stockQuantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Остаток не может быть отрицательным.");
        }

        this.Id = id;
        this.Name = name.Trim();
        this.Price = price;
        this.StockQuantity = stockQuantity;
    }

    internal Guid Id { get; }

    internal string Name { get; }

    internal decimal Price { get; private set; }

    internal int StockQuantity { get; private set; }

    internal void ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newPrice), "Цена должна быть больше 0.");
        }

        this.Price = newPrice;
    }

    internal void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Количество должно быть больше 0.");
        }

        this.StockQuantity += quantity;
    }

    internal void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Количество должно быть больше 0.");
        }

        if (quantity > this.StockQuantity)
        {
            throw new InvalidOperationException("Недостаточно товара на складе.");
        }

        this.StockQuantity -= quantity;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Price:F2} руб. (остаток: {this.StockQuantity})";
    }
}
