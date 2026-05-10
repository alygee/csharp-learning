namespace OrderManagement;

internal sealed class OrderItem
{
    internal OrderItem(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Количество должно быть больше 0.");
        }

        this.Product = product;
        this.Quantity = quantity;
        this.UnitPrice = product.Price;
    }

    internal Product Product { get; }

    internal int Quantity { get; }

    internal decimal UnitPrice { get; }

    internal decimal LineTotal => this.UnitPrice * this.Quantity;
}
