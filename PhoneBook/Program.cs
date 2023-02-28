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
            int choice = Helper.GetValidNumberInRange(1, 4, "Enter a valid input");

            switch (choice)
            {
                case 1:
                    await PerformCrud(display, dbController, userInput);
                    break;
                case 2:
                    var itemList = (await dbController.GetContacts(x => true)).Select(x => new ContactDto(x)).ToList();
                    display.PrintTable(itemList, "Contacts");
                    Console.ReadKey();
                    break;
                case 3:
                    await SendEmail(display, dbController, userInput);
                    break;
                case 4:
                    appEnd = true;
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
    }

    private static async Task SendEmail(DisplayService display, ContactStore dbController, UserInputService userInput)
    {
        var emailService = new EmailService();
        var contacts = await dbController.GetContacts(x => x.EmailAddress != null);
        display.PrintTable(contacts, "Contacts with Emails");
        var contact = await dbController.GetContact(x => x.ContactId == userInput.GetId() && x.EmailAddress != null);

        if (contact == null) return;

        Console.Write("Enter your subject: ");
        var subject = Console.ReadLine();
        Console.Write("Enter your message: ");
        var text = Console.ReadLine();
        
        var emailAdd = userInput.GetInput("Enter your email: ", userInput.GetEmail);
        var senderName = userInput.GetInput("Enter your name: ", userInput.GetName);
        var emailPass = userInput.GetInput("Enter your password: ", userInput.GetName);
        
        emailService.SendEmail(new ContactDto(contact), subject, text, emailAdd, emailPass, senderName);
    }
    
    private static async Task PerformCrud(DisplayService display, ContactStore dbController, UserInputService userInput)
    {
        var contacts = await dbController.GetContacts(x => true);
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
                display.PrintTable(contacts, "Contacts");
                item = await dbController.GetContact(x => x.ContactId == userInput.GetId());
                if (item != null) await dbController.Delete(item);
                break;
        
            case 3:
                display.PrintTable(contacts, "Contacts");
                item = await dbController.GetContact(x => x.ContactId == userInput.GetId());
                if (item != null)
                {
                    userInput.EditContactInfo(item);
                    await dbController.Update(item);
                }
                break;
        }
    }
    


}