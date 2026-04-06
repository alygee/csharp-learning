namespace Calculator;

internal class CalculatorEngine
{
    private readonly NumbersReader reader;

    internal CalculatorEngine(NumbersReader numbersReader)
    {
        this.reader = numbersReader;
    }

    private static double RunDivision(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно.");
        }

        return a / b;
    }

    public void Run()
    {
        if (!this.reader.TryRead(out MenuChoice operation, out double a, out double b))
        {
            if (operation == MenuChoice.Exit)
            {
                Console.WriteLine("До свидания.");
            }

            return;
        }

        double result = operation switch
        {
            MenuChoice.Add => a + b,
            MenuChoice.Subtract => a - b,
            MenuChoice.Multiply => a * b,
            MenuChoice.Divide => RunDivision(a, b),
            _ => throw new ArgumentException("Неизвестная операция"),
        };

        Console.WriteLine($"Результат: {result}");
    }
}
