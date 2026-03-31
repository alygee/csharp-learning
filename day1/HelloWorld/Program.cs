bool shouldContinue;

do
{
    GreetUser();
    Console.Write("Повторить? (да/нет): ");
    string? answer = Console.ReadLine();
    shouldContinue = AppLogic.ShouldRepeat(answer);
    Console.WriteLine();
} while (shouldContinue);

static void GreetUser()
{
    Console.Write("Введите ваше имя: ");
    string? name = Console.ReadLine();
    bool useGuestName = string.IsNullOrWhiteSpace(name);
    string normalizedName = AppLogic.NormalizeName(name);

    if (useGuestName)
    {
        Console.WriteLine("Имя не введено. Будем считать, что вы Гость.");
    }

    Console.WriteLine($"Привет, {normalizedName}!");
    Console.WriteLine($"Сегодня: {DateTime.Now:dd.MM.yyyy}");
}

public static class AppLogic
{
    public static bool ShouldRepeat(string? answer)
    {
        string normalized = (answer ?? string.Empty).Trim().ToLowerInvariant();
        return normalized is "да" or "д" or "y" or "yes";
    }

    public static string NormalizeName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Гость";
        }

        return name.Trim();
    }
}
