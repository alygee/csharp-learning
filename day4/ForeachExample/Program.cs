namespace ForeachExample;

internal static class Program
{
    private static void Main()
    {
        int[] values = { 2, 5, 8, 10, 12 };

        int sum = 0;
        int count = 0;

        foreach (int x in values)
        {
            sum += x;
            count++;
        }

        double average = count == 0 ? 0 : (double)sum / count;

        Console.WriteLine("Массив: [" + string.Join(", ", values) + "]");
        Console.WriteLine($"Сумма = {sum}");
        Console.WriteLine($"Среднее = {average:F2}");

        Console.WriteLine();
        Console.Write("Введите строку для подсчёта гласных: ");
        string? s = Console.ReadLine();
        s ??= "";

        int vowels = 0;

        foreach (char ch in s)
        {
            char c = char.ToLowerInvariant(ch);
            if (
                c == 'a'
                || c == 'e'
                || c == 'i'
                || c == 'o'
                || c == 'u'
                || c == 'а'
                || c == 'е'
                || c == 'ё'
                || c == 'и'
                || c == 'о'
                || c == 'у'
                || c == 'ы'
                || c == 'э'
            )
            {
                vowels++;
            }
        }

        Console.WriteLine($"Гласных символов: {vowels}");
    }
}
