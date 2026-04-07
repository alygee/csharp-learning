namespace BookInventory;

internal static class Program
{
    private static void Main()
    {
        BookInventoryApp app = new BookInventoryApp(new InventoryMenu());
        app.Run();
    }
}
