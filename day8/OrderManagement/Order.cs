namespace OrderManagement;

internal sealed class Order
{
    private readonly List<OrderItem> _items = new();

    internal Order(string orderNumber, User customer)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(orderNumber);
        ArgumentNullException.ThrowIfNull(customer);

        this.OrderNumber = orderNumber.Trim();
        this.Customer = customer;
        this.CreatedAt = DateTime.Now;
    }

    internal string OrderNumber { get; }

    internal User Customer { get; }

    internal DateTime CreatedAt { get; }

    internal IReadOnlyList<OrderItem> Items => this._items;

    internal decimal TotalAmount => this._items.Sum(item => item.LineTotal);

    internal void AddProduct(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);

        product.DecreaseStock(quantity);
        this._items.Add(new OrderItem(product, quantity));
    }

    public override string ToString()
    {
        return $"Заказ {this.OrderNumber} от {this.CreatedAt:dd.MM.yyyy HH:mm} для {this.Customer.FullName}";
    }
}
