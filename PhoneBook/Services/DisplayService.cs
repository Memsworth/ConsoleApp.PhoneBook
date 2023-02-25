using ConsoleTableExt;
using PhoneBook.Model.DTO;

namespace PhoneBook.Services;

public class DisplayService
{
    private void DisplayOptions<T>(T tableData, string tableName) where T : List<List<object>> => ConsoleTableBuilder.From(tableData)
        .WithTitle(tableName, ConsoleColor.Yellow, ConsoleColor.Black)
        .ExportAndWriteLine();

    private void SingleEntity<T>(List<T> tableData)  where T : class => ConsoleTableBuilder.From(tableData).ExportAndWriteLine();

    public void DisplayContacts<T>(List<T> tableData) where T : class
    {
        Console.Clear();
        ConsoleTableBuilder.From(tableData)
            .WithTitle("Contacts", ConsoleColor.Yellow, ConsoleColor.Black).ExportAndWriteLine();
    }

    public void DisplayStartMenu()
    {
        var options = new List<List<object>>
        {
            new() {1, "Add a contact"},
            new() {2, "Delete a contact"},
            new() {3, "Update a contact"},
            new() {4, "List contacts"},
            new() {5, "Get specific contact"}
        };
        
        DisplayOptions(options, "PhoneBook Options");
    }

    public void CurrentContact(ContactDto contact) => SingleEntity(new List<ContactDto>() {contact});
}