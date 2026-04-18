namespace OrderParser;

internal sealed class Order
{
    public required string OrderId { get; init; }

    public required string CustomerName { get; init; }

    public required string ProductName { get; init; }

    public required int Quantity { get; init; }

    public required decimal Price { get; init; }

    public required DateTime OrderDate { get; init; }

    public decimal TotalAmount => Quantity * Price;
}
