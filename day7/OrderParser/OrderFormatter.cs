using System.Globalization;
using System.Text;

namespace OrderParser;

internal static class OrderFormatter
{
    public static string Format(Order order)
    {
        StringBuilder builder = new();
        builder.AppendLine("Заказ успешно разобран:");
        builder.AppendLine($"ID заказа: {order.OrderId}");
        builder.AppendLine($"Клиент: {order.CustomerName}");
        builder.AppendLine($"Товар: {order.ProductName}");
        builder.AppendLine($"Количество: {order.Quantity}");
        builder.AppendLine($"Цена за единицу: {order.Price.ToString("F2", CultureInfo.InvariantCulture)}");
        builder.AppendLine($"Дата заказа: {order.OrderDate:dd.MM.yyyy HH:mm}");
        builder.AppendLine($"Итоговая сумма: {order.TotalAmount.ToString("F2", CultureInfo.InvariantCulture)}");
        return builder.ToString();
    }
}
