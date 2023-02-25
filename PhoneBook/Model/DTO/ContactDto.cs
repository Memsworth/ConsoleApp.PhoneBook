using PhoneBook.Model.DBO;

namespace PhoneBook.Model.DTO;

public class ContactDto
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public ContactDto(Contact contact)
    {
        Name = contact.Name;
        PhoneNumber = contact.PhoneNumber;
        Email = contact.EmailAddress;
    }
}