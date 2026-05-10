namespace OrderManagement;

internal sealed class OrderConsoleApp
{
    private readonly ProductCatalog _catalog;

    internal OrderConsoleApp(ProductCatalog catalog)
    {
        this._catalog = catalog;
    }

    internal void Run()
    {
        Console.WriteLine("=== День 8: ООП, классы, свойства, конструкторы, инкапсуляция ===");
        Console.WriteLine();

        User customer = this.ReadCustomer();
        Order order = new(CreateOrderNumber(), customer);

        this.FillOrder(order);
        this.PrintOrder(order);
    }

    private User ReadCustomer()
    {
        Console.WriteLine("Введите данные покупателя.");
        string firstName = ConsoleInput.ReadRequiredString("Имя: ");
        string lastName = ConsoleInput.ReadRequiredString("Фамилия: ");
        string email = ConsoleInput.ReadEmail("Email: ");
        Console.WriteLine();

        return new User(Guid.NewGuid(), firstName, lastName, email);
    }

    private void FillOrder(Order order)
    {
        Console.WriteLine("Соберите заказ. Введите номер товара или 0 для завершения.");

        while (true)
        {
            Console.WriteLine();
            this.PrintCatalog();

            if (this._catalog.IsEmpty)
            {
                Console.WriteLine("На складе не осталось доступных товаров.");
                return;
            }

            int choice = ConsoleInput.ReadInt("Номер товара (0 - завершить): ", 0, this._catalog.Count);
            if (choice == 0)
            {
                return;
            }

            Product selectedProduct = this._catalog.GetByNumber(choice);
            if (selectedProduct.StockQuantity == 0)
            {
                Console.WriteLine("Этот товар закончился. Выберите другой.");
                continue;
            }

            int quantity = ConsoleInput.ReadInt(
                $"Количество для \"{selectedProduct.Name}\" (1-{selectedProduct.StockQuantity}): ",
                1,
                selectedProduct.StockQuantity);

            try
            {
                order.AddProduct(selectedProduct, quantity);
                Console.WriteLine(
                    $"Добавлено: {selectedProduct.Name} x {quantity}. Сумма заказа: {order.TotalAmount:F2} руб.");
            }
            catch (Exception ex) when (ex is InvalidOperationException or ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Не удалось добавить товар: {ex.Message}");
            }
        }
    }

    private void PrintCatalog()
    {
        Console.WriteLine("Каталог:");
        for (int i = 0; i < this._catalog.Count; i++)
        {
            Product product = this._catalog.Items[i];
            Console.WriteLine($"  {i + 1}. {product}");
        }
    }

    private void PrintOrder(Order order)
    {
        Console.WriteLine();
        Console.WriteLine($"Покупатель: {order.Customer}");
        Console.WriteLine(order);
        Console.WriteLine();

        if (order.Items.Count == 0)
        {
            Console.WriteLine("Заказ пуст. Вы не добавили ни одного товара.");
        }
        else
        {
            Console.WriteLine("Состав заказа:");
            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine(
                    $"- {item.Product.Name}: {item.Quantity} x {item.UnitPrice:F2} = {item.LineTotal:F2} руб.");
            }

            Console.WriteLine();
            Console.WriteLine($"Итого: {order.TotalAmount:F2} руб.");
        }

        Console.WriteLine();
        Console.WriteLine("Остатки на складе после оформления:");
        foreach (Product product in this._catalog.Items)
        {
            Console.WriteLine($"- {product.Name}: {product.StockQuantity}");
        }
    }

    private static string CreateOrderNumber()
    {
        return $"ORD-{DateTime.Now:MMdd-HHmmss}";
    }
}
