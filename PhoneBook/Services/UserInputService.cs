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

    public void EditContactInfo(Contact contact)
    {
        contact.Name = GetInput("Enter a name", GetName)!;
        contact.PhoneNumber = GetInput("Enter a phone number", GetPhone)!;
        contact.EmailAddress = GetInput("Enter an email", GetEmail);
    } 
    
    public int GetId() => Helper.GetValidNumberInRange(1, int.MaxValue, "enter a valid id");

    private string? GetInput(string message, Func<string, bool> validatorFunc)
    {
        Console.WriteLine(message);
        string input;
        do
        {
            input = Console.ReadLine();
        } while (!validatorFunc(input));
        
        return !string.IsNullOrWhiteSpace(input) ? input : null;
    }
    
    private bool GetPhone(string input) => ValidatorService.Validate(input, ServiceHelper.ValidatePhone);
    private bool GetEmail(string input) => ValidatorService.Validate(input, ServiceHelper.ValidateEmail);
    private bool GetName(string input) => ValidatorService.Validate(input, ServiceHelper.ValidateName);
}