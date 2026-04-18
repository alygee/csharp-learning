namespace OrderParser;

internal sealed class OrderParseResult
{
    private OrderParseResult(bool isSuccess, Order? order, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Order = order;
        ErrorMessage = errorMessage;
    }

    public bool IsSuccess { get; }

    public Order? Order { get; }

    public string? ErrorMessage { get; }

    public static OrderParseResult Success(Order order) => new(true, order, null);

    public static OrderParseResult Failure(string errorMessage) => new(false, null, errorMessage);
}
