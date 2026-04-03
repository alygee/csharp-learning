namespace WhileDoWhileExample;

internal static class Program
{
    private static void Main()
    {
        int n = ReadIntInRange("Введите N (1..20): ", 1, 20);

        // while: считаем сумму 1..N
        int i = 1;
        int sum = 0;
        while (i <= n)
        {
            sum += i;
            i++;
        }
        Console.WriteLine($"Сумма чисел от 1 до {n} равна {sum}.");

        // do-while: повторяем действие минимум 1 раз
        char answer;
        do
        {
            Console.WriteLine();
            Console.WriteLine($"Квадраты от 1 до {Math.Min(n, 10)}:");
            int k = 1;
            while (k <= Math.Min(n, 10))
            {
                Console.WriteLine($"{k}^2 = {k * k}");
                k++;
            }

            Console.Write("Показать ещё раз? (y/n): ");
            answer = ReadYesNo();
        } while (answer == 'y');
    }

    private static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Ошибка: введите целое число от {min} до {max}.");
        }
    }

    private static char ReadYesNo()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Введите 'y' или 'n': ");
                continue;
            }

            char c = char.ToLowerInvariant(input.Trim()[0]);
            if (c == 'y' || c == 'n')
                return c;

            Console.Write("Введите 'y' или 'n': ");
        }
    }
}