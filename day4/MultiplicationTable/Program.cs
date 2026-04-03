namespace MultiplicationTable;

internal static class Program
{
    private static void Main()
    {
        int n = ReadIntRange("Введите N для таблицы умножения (1..20): ", 1, 20);

        Console.WriteLine();
        Console.WriteLine($"Таблица умножения: {n}x{n}:");
        Console.WriteLine();

        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= n; col++)
            {
                int value = row * col;
                Console.Write($"{value, 4}");
            }
            Console.WriteLine();
        }
    }

    private static int ReadIntRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Ошибка: введите целое число от {min} до {max}");
        }
    }
}
