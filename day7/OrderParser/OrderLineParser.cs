using System.Globalization;

namespace OrderParser;

internal sealed class OrderLineParser
{
    public OrderParseResult Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return OrderParseResult.Failure("Строка заказа пустая.");
        }

        string[] parts = input.Split(';', StringSplitOptions.None);
        if (parts.Length != 6)
        {
            return OrderParseResult.Failure(
                "Неверный формат. Ожидается 6 полей: orderId;customer;product;quantity;price;orderDate.");
        }

        string orderId = parts[0].Trim();
        string customerName = parts[1].Trim();
        string productName = parts[2].Trim();
        string quantityText = parts[3].Trim();
        string priceText = parts[4].Trim();
        string orderDateText = parts[5].Trim();

        if (string.IsNullOrWhiteSpace(orderId) ||
            string.IsNullOrWhiteSpace(customerName) ||
            string.IsNullOrWhiteSpace(productName))
        {
            return OrderParseResult.Failure("ID заказа, клиент и товар не должны быть пустыми.");
        }

        if (!int.TryParse(quantityText, NumberStyles.Integer, CultureInfo.InvariantCulture, out int quantity) || quantity <= 0)
        {
            return OrderParseResult.Failure("Количество должно быть целым числом больше 0.");
        }

        if (!TryParseDecimalFlexible(priceText, out decimal price) || price <= 0)
        {
            return OrderParseResult.Failure("Цена должна быть положительным числом.");
        }

        if (!DateTime.TryParse(orderDateText, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out DateTime orderDate))
        {
            return OrderParseResult.Failure("Дата заказа не распознана. Пример: 2026-04-08 14:30.");
        }

        Order order = new()
        {
            OrderId = orderId,
            CustomerName = customerName,
            ProductName = productName,
            Quantity = quantity,
            Price = price,
            OrderDate = orderDate
        };

        return OrderParseResult.Success(order);
    }

    private static bool TryParseDecimalFlexible(string input, out decimal value)
    {
        if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
        {
            return true;
        }

        string normalized = input.Replace(',', '.');
        return decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
    }
}
