using PhoneBook.BuilderContext;
using PhoneBook.Controller;
using PhoneBook.Model.DBO;
using PhoneBook.Model.DTO;
using PhoneBook.Services;

namespace PhoneBook;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var display = new DisplayService();
        var db = new PhoneBookContext();
        var dbController = new ContactStore(db);
        var userInput = new UserInputService();
        var appEnd = false;

        while (!appEnd)
        {
            display.PrintTable(DisplayServiceExtension.GetMainMenu(), "Main Menu");
            int choice = Helper.GetValidNumberInRange(1, 3, "Enter a valid input");

            switch (choice)
            {
                case 1:
                    await PerformCrud(display, dbController, userInput);
                    break;
                case 2:
                    var itemList = (await dbController.GetAll()).Select(x => new ContactDto(x)).ToList();
                    display.PrintTable(itemList, "Contacts");
                    Console.ReadKey();
                    break;
                case 3:
                    appEnd = true;
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }

        
    }

    private static async Task PerformCrud(DisplayService display, ContactStore dbController, UserInputService userInput)
    {
        display.PrintTable(DisplayServiceExtension.GetCrudMenu(), "CRUD Menu");
        int choice = Helper.GetValidNumberInRange(1, 3, "Enter a valid input");
        Contact? item;
        switch (choice)
        {
            case 1:
                var contact = new Contact();
                userInput.EditContactInfo(contact);
                await dbController.Insert(contact);
                break;
        
            case 2:
                display.PrintTable((await dbController.GetAll()).ToList(), "Contacts");
                item = await dbController.Get(userInput.GetId());
                if (item != null) await dbController.Delete(item);
                break;
        
            case 3:
                display.PrintTable((await dbController.GetAll()).ToList(), "Contacts");
                item = await dbController.Get(userInput.GetId());
                if (item != null)
                {
                    userInput.EditContactInfo(item);
                    await dbController.Update(item);
                }
                break;
        }
    }


}