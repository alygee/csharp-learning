namespace Calculator;

internal class OperationMenu
{
    internal MenuChoice Operation { get; private set; }

    private void ShowMenu()
    {
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("  1 —  сложение");
        Console.WriteLine("  2 —  вычитание");
        Console.WriteLine("  3 —  умножение");
        Console.WriteLine("  4 —  деление");
        Console.WriteLine("  5 —  выход");
        Console.Write("Команда: ");
    }

    private MenuChoice Normalize(string? raw)
    {
        string trimmed = (raw ?? string.Empty).Trim();

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

    internal void DefineOperation()
    {
        this.ShowMenu();
        string? choice = Console.ReadLine() ?? string.Empty;
        this.Operation = this.Normalize(choice);
    }
}
