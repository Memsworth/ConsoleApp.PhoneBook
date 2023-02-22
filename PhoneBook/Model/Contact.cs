namespace PhoneBook.Model;

public class Contact
{
    public int ContactId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
}