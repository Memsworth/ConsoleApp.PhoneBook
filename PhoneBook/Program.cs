using PhoneBook.BuilderContext;
using PhoneBook.Controller;
using PhoneBook.Model.DBO;
using PhoneBook.Model.DTO;
using PhoneBook.Services;

namespace PhoneBook;

internal static class Program
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
            display.DisplayStartMenu();
            int choice = Helper.GetValidNumberInRange(1, 5, "Enter a valid input");

            Contact? item;
            switch (choice)
            {
                case 1:
                    var contact = new Contact();
                    userInput.EditContactInfo(contact);
                    await dbController.Insert(contact);
                    break;
        
                case 2:
                    display.DisplayContacts((await dbController.GetAll()).ToList());
                    item = await dbController.Get(userInput.GetId());
                    if (item != null) await dbController.Delete(item);
                    break;
        
                case 3:
                    display.DisplayContacts((await dbController.GetAll()).ToList());
                    item = await dbController.Get(userInput.GetId());
                    if (item != null)
                    {
                        userInput.EditContactInfo(item);
                        await dbController.Update(item);
                    }
                    break;

                case 4:
                    var itemList = (await dbController.GetAll()).Select(x => new ContactDto(x)).ToList();
                    display.DisplayContacts(itemList);
                    Console.ReadKey();
                    break;
        
                case 5:
                    appEnd = true;
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }

        
    }
}