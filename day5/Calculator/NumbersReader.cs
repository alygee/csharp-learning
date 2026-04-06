namespace Calculator;

internal class NumbersReader
{
    private readonly OperationMenu menu;

    internal NumbersReader(OperationMenu menu)
    {
        this.menu = menu;
    }

    private static bool TryReadDouble(string prompt, out double value)
    {
        Console.Write(prompt);
        string? line = Console.ReadLine();
        return double.TryParse(
            line,
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out value
        );
    }

    private static bool TryReadFirstNumber(MenuChoice operation, out double value)
    {
        string prompt = operation switch
        {
            MenuChoice.Add => "Первое слагаемое: ",
            MenuChoice.Subtract => "Уменьшаемое: ",
            MenuChoice.Multiply => "Первый множитель: ",
            MenuChoice.Divide => "Делимое: ",
            _ => throw new ArgumentException("Неизвестная операция"),
        };

        return TryReadDouble(prompt, out value);
    }

    private static bool TryReadSecondNumber(MenuChoice operation, out double value)
    {
        string prompt = operation switch
        {
            MenuChoice.Add => "Второе слагаемое: ",
            MenuChoice.Subtract => "Вычитаемое: ",
            MenuChoice.Multiply => "Второй множитель: ",
            MenuChoice.Divide => "Делитель: ",
            _ => throw new ArgumentException("Неизвестная операция"),
        };

        return TryReadDouble(prompt, out value);
    }

    internal bool TryRead(out MenuChoice operation, out double a, out double b)
    {
        a = 0;
        b = 0;

        this.menu.DefineOperation();
        operation = this.menu.Operation;

        if (operation == MenuChoice.Exit)
        {
            return false;
        }

        if (operation == MenuChoice.Unknown)
        {
            Console.WriteLine("Неизвестная команда.");
            return false;
        }

        if (!TryReadFirstNumber(operation, out a))
        {
            Console.WriteLine("Не удалось прочитать первое число.");
            return false;
        }

        if (!TryReadSecondNumber(operation, out b))
        {
            Console.WriteLine("Не удалось прочитать второе число.");
            return false;
        }

        return true;
    }
}
