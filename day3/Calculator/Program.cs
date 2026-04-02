namespace Calculator;

/// <summary>
/// День 3: тренировка if, switch, тернарного оператора.
/// Дополни тело методов и при необходимости добавь операции в меню.
/// </summary>
internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Калькулятор с меню — день 3 ===");
        Console.WriteLine();

        bool shouldContinue;
        do
        {
            ShowMenu();
            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (NormalizeMenuChoice(choice))
            {
                case MenuChoice.Add:
                    RunBinaryOperation("сложение", (a, b) => a + b);
                    break;
                case MenuChoice.Subtract:
                    RunBinaryOperation("вычитание", (a, b) => a - b);
                    break;
                case MenuChoice.Multiply:
                    RunBinaryOperation("умножение", (a, b) => a * b);
                    break;
                case MenuChoice.Divide:
                    RunDivision();
                    break;
                case MenuChoice.Exit:
                    Console.WriteLine("Выход из программы.");
                    return;
                case MenuChoice.Unknown:
                default:
                    Console.WriteLine("Неизвестная команда. Введите число от 1 до 5.");
                    break;
            }

            Console.WriteLine();
            Console.Write("Ещё раз? (да/нет): ");
            string? answer = Console.ReadLine();
            shouldContinue = ShouldRepeat(answer);
            Console.WriteLine();
        } while (shouldContinue);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("  1 — сложение");
        Console.WriteLine("  2 — вычитание");
        Console.WriteLine("  3 — умножение");
        Console.WriteLine("  4 — деление");
        Console.WriteLine("  5 — выход");
        Console.Write("Команда: ");
    }

    /// <summary>
    /// Разбор пункта меню: здесь удобно потренировать switch по строкам/числам.
    /// </summary>
    private static MenuChoice NormalizeMenuChoice(string? raw)
    {
        string trimmed = (raw ?? string.Empty).Trim();

        // Пример: можно заменить на int.TryParse + внутренний switch по числу.
        return trimmed switch
        {
            "1" => MenuChoice.Add,
            "2" => MenuChoice.Subtract,
            "3" => MenuChoice.Multiply,
            "4" => MenuChoice.Divide,
            "5" => MenuChoice.Exit,
            _ => MenuChoice.Unknown,
        };
    }

    private static void RunBinaryOperation(string operationName, Func<double, double, double> compute)
    {
        if (!TryReadDouble("Первое число: ", out double a))
        {
            Console.WriteLine("Не удалось прочитать первое число.");
            return;
        }

        if (!TryReadDouble("Второе число: ", out double b))
        {
            Console.WriteLine("Не удалось прочитать второе число.");
            return;
        }

        double result = compute(a, b);

        // Тернарный оператор: короткая подпись к результату (можно заменить своей логикой).
        string signHint = result >= 0 ? "неотрицательный" : "отрицательный";
        Console.WriteLine($"Операция: {operationName}");
        Console.WriteLine($"Результат: {result} ({signHint})");
    }

    private static void RunDivision()
    {
        if (!TryReadDouble("Делимое: ", out double a))
        {
            Console.WriteLine("Не удалось прочитать делимое.");
            return;
        }

        if (!TryReadDouble("Делитель: ", out double b))
        {
            Console.WriteLine("Не удалось прочитать делитель.");
            return;
        }

        if (b == 0)
        {
            Console.WriteLine("Деление на ноль невозможно.");
            return;
        }

        double result = a / b;
        string signHint = result >= 0 ? "неотрицательный" : "отрицательный";
        Console.WriteLine($"Операция: деление");
        Console.WriteLine($"Результат: {result} ({signHint})");
    }

    private static bool TryReadDouble(string prompt, out double value)
    {
        Console.Write(prompt);
        string? line = Console.ReadLine();
        return double.TryParse(
            line,
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out value);
    }

    private static bool ShouldRepeat(string? answer)
    {
        string normalized = (answer ?? string.Empty).Trim().ToLowerInvariant();
        return normalized is "да" or "д" or "y" or "yes";
    }

    private enum MenuChoice
    {
        Unknown = 0,
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4,
        Exit = 5,
    }
}
