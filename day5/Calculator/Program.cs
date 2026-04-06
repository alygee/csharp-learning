namespace Calculator;

internal static class Program
{
    private static void Main()
    {
        try
        {
            CalculatorEngine calculator = new CalculatorEngine(
                new NumbersReader(new OperationMenu())
            );
            calculator.Run();
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
