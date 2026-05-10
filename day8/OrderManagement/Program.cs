namespace OrderManagement;

internal static class Program
{
    private static void Main()
    {
        OrderConsoleApp app = new(new ProductCatalog());
        app.Run();
    }
}
