using PhoneBook;
using PhoneBook.BuilderContext;
using PhoneBook.Controller;
using PhoneBook.Model.DBO;
using PhoneBook.Model.DTO;
using PhoneBook.Services;

var display = new DisplayService();
var db = new PhoneBookContext();
var dbController = new ContactStore(db);
var userInput = new UserInputService();
var appEnd = false;

while (appEnd != true)
{
    display.DisplayStartMenu();
    int choice = Helper.GetValidNumberInRange(1, 4, "Enter a valid input");

    switch (choice)
    {
        case 1:
            var contact = new Contact();
            UpdateContact(contact);
            await dbController.Insert(contact);
            Console.WriteLine("item is inserted");
            break;
        case 2:
            var deleteItem = await dbController.Get(userInput.GetId());
            await dbController.Delete(deleteItem);
            break;
        case 3:
            var updateItemId = await dbController.Get(userInput.GetId());
            UpdateContact(updateItemId);
            await dbController.Update(updateItemId);
            break;
        case 4:
            var itemList = (await dbController.GetAll()).Select(x => new ContactDto(x)).ToList();
            display.DisplayContacts(itemList);
            break;
        case 5:
            appEnd = true;
            break;
        default:
            Console.WriteLine("Wrong input");
            break;
    }
}

void UpdateContact(Contact contact)
{
    contact.Name = userInput.GetInput("Enter a name", userInput.GetName);
    contact.PhoneNumber = userInput.GetInput("Enter a phone number", userInput.GetPhone);
    contact.EmailAddress = userInput.GetInput("Enter an email", userInput.GetEmail);
}
