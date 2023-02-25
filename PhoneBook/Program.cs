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
    int choice = Helper.GetValidNumberInRange(1, 5, "Enter a valid input");

    switch (choice)
    {
        case 1:
            var contact = new Contact();
            userInput.EditContactInfo(contact);
            await dbController.Insert(contact);
            break;
        case 2:
            var deleteList = (await dbController.GetAll()).ToList();
            display.DisplayContacts(deleteList);
            var deleteItem = await dbController.Get(userInput.GetId());
            await dbController.Delete(deleteItem);
            break;
        case 3:
            var updateList = (await dbController.GetAll()).ToList();
            display.DisplayContacts(updateList);
            var updateItemId = await dbController.Get(userInput.GetId());
            userInput.EditContactInfo(updateItemId);
            await dbController.Update(updateItemId);
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


