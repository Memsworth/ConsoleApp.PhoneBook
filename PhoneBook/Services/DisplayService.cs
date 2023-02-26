using ConsoleTableExt;

namespace PhoneBook.Services;

public static class DisplayServiceExtension
{
    public static List<List<object>> GetCrudMenu()
    {
        var options = new List<List<object>>
        {
            new() {1, "Add a contact"},
            new() {2, "Delete a contact"},
            new() {3, "Update a contact"},
        };
        return options;
    }

    public static List<List<object>> GetMainMenu()
    {
        var options = new List<List<object>>
        {
            new() {1, "Perform crud operations"},
            new() {2, "List contacts"},
            new() {3, "Quit the app"}
        };
        return options;
    }
}

public class DisplayService
{
    public void PrintTable(List<List<object>> tableData, string tableName)
    {
        Console.Clear();
        ConsoleTableBuilder.From(tableData)
            .WithTitle(tableName, ConsoleColor.Yellow, ConsoleColor.Black)
            .ExportAndWriteLine();
    }

    public void PrintTable<T>(List<T> tableData, string tableName) where T : class
    {
        Console.Clear();
        ConsoleTableBuilder.From(tableData)
            .WithTitle(tableName, ConsoleColor.Yellow, ConsoleColor.Black).ExportAndWriteLine();
    }

}