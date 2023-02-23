namespace PhoneBook.Services;

public class UserInputService
{
    public string GetPhone()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        
        throw new NotImplementedException();
    }

    private string GetValidString(string promt)
    {
        string item;
        do
        {
            item = Console.ReadLine()!;
        } while (!string.IsNullOrEmpty(item));
        throw new NotImplementedException();
    }
}