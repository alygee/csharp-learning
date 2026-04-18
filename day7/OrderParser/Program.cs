namespace OrderParser;

internal static class Program
{
    private static readonly string Example =
        "ORD-1001;Иван Петров;Ноутбук;2;75999.50;2026-04-08 14:30";

    private static void Main()
    {
        OrderLineParser parser = new();

        Console.WriteLine("Введите строку заказа в формате:");
        Console.WriteLine("orderId;customer;product;quantity;price;orderDate");
        Console.WriteLine($"Пример: {Example}");
        Console.WriteLine("Нажмите Enter без ввода, чтобы использовать пример.");
        Console.WriteLine();

        string? userInput = Console.ReadLine();
        string input = string.IsNullOrWhiteSpace(userInput) ? Example : userInput;

        OrderParseResult result = parser.Parse(input);
        if (!result.IsSuccess || result.Order is null)
        {
            Console.WriteLine($"Ошибка: {result.ErrorMessage ?? "Неизвестная ошибка парсинга."}");
            return;
        }

        Console.WriteLine();
        Console.WriteLine(OrderFormatter.Format(result.Order));
    }
}
