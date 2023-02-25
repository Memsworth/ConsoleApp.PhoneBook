using PhoneBook.Model.DBO;

namespace PhoneBook.Services;

public class UserInputService
{
    private ValidatorService ValidatorService { get; }
    private ValidatorServiceHelper ServiceHelper { get; }

    public UserInputService()
    {
        ValidatorService = new ValidatorService();
        ServiceHelper = new ValidatorServiceHelper();
    }
    
    public string? GetInput(string message, Func<string, string> func) => func(message);

    public void EditContactInfo(Contact contact)
    {
        contact.Name = GetInput("Enter a name", GetName);
        contact.PhoneNumber = GetInput("Enter a phone number", GetPhone);
        contact.EmailAddress = GetInput("Enter an email", GetEmail);
    } 
    
    public int GetId() => Helper.GetValidNumberInRange(1, int.MaxValue, "enter a valid id");
    public string GetPhone(string message)
    {
        string input;
        do
        {
            Console.WriteLine(message);
            input = Console.ReadLine();
        } while (!ValidatorService.Validate(input, ServiceHelper.ValidatePhone));

        return input;
    }

    public string? GetEmail(string message)
    {
        string input;
        Console.WriteLine(message);
        input = Console.ReadLine();
        if (ValidatorService.Validate(input, ServiceHelper.ValidateEmail))
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            return input;
        }
        return null;
    }
    public string GetName(string message)
    {
        string input;
        do
        {
            Console.WriteLine(message);
            input = Console.ReadLine()!;
        } while (!ValidatorService.Validate(input, ServiceHelper.ValidateName));

        return input;
    }
}