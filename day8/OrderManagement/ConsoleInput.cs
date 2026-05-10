namespace OrderManagement;

internal static class ConsoleInput
{
    internal static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Поле не должно быть пустым.");
        }
    }

    internal static string ReadEmail(string prompt)
    {
        while (true)
        {
            string email = ReadRequiredString(prompt);
            if (email.Contains('@') && !email.StartsWith('@') && !email.EndsWith('@'))
            {
                return email;
            }

            Console.WriteLine("Введите корректный email.");
        }
    }

    internal static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Введите целое число от {min} до {max}.");
        }
    }
}
