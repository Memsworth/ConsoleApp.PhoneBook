using PhoneBook.BuilderContext;
using PhoneBook.Controller;
using PhoneBook.Services;

var display = new DisplayService();
var dbController = new DbController( new PhoneBookContext());

await dbController.Insert();
display.DisplayStartMenu();