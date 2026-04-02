namespace UnitConverter;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Конвертер длины (м, см, мм) — день 2 ===");
        Console.WriteLine("Введите число, исходную единицу и целевую единицу.");
        Console.WriteLine();

        bool shouldContinue;
        do
        {
            RunOnce();
            Console.Write("Ещё раз? (да/нет): ");
            string? answer = Console.ReadLine();
            shouldContinue = ShouldRepeat(answer);
            Console.WriteLine();
        } while (shouldContinue);
    }

    private static void RunOnce()
    {
        double value;
        while (true)
        {
            Console.Write("Значение: ");
            string? line = Console.ReadLine();
            if (LengthConverter.TryParseLength(line, out value))
            {
                break;
            }

            Console.WriteLine("Не удалось разобрать число. Попробуйте снова (например 1,5 или 2.5).");
        }

        LengthUnit fromUnit;
        while (true)
        {
            Console.Write("Из единицы (м / см / мм): ");
            string? line = Console.ReadLine();
            if (LengthConverter.TryParseUnit(line, out fromUnit))
            {
                break;
            }

            Console.WriteLine("Неизвестная единица. Укажите м, см или мм.");
        }

        LengthUnit toUnit;
        while (true)
        {
            Console.Write("В единицу (м / см / мм): ");
            string? line = Console.ReadLine();
            if (LengthConverter.TryParseUnit(line, out toUnit))
            {
                break;
            }

            Console.WriteLine("Неизвестная единица. Укажите м, см или мм.");
        }

        double meters = LengthConverter.ToMeters(value, fromUnit);
        double result = LengthConverter.FromMeters(meters, toUnit);
        string label = LengthConverter.GetUnitLabel(toUnit);

        Console.WriteLine();
        Console.WriteLine($"Результат: {result.ToString("F6", System.Globalization.CultureInfo.InvariantCulture)} {label}");
        Console.WriteLine($"(промежуточно в метрах: {meters.ToString("G", System.Globalization.CultureInfo.InvariantCulture)} м)");
    }

    private static bool ShouldRepeat(string? answer)
    {
        string normalized = (answer ?? string.Empty).Trim().ToLowerInvariant();
        return normalized is "да" or "д" or "y" or "yes";
    }
}
