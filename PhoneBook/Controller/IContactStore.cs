using PhoneBook.Model.DBO;

namespace PhoneBook.Controller;

public interface IContactStore
{
    public Task Insert(Contact contact);
    public Task Delete(Contact contact);
    public Task<Contact?> Get(int id);
    public Task Update(Contact contact);
    public Task<List<Contact>> GetAll();
}