using System.Linq.Expressions;
using PhoneBook.Model.DBO;

namespace PhoneBook.Controller;

public interface IContactStore
{
    public Task Insert(Contact contact);
    public Task Delete(Contact contact);
    public Task<Contact?> GetContact(Expression<Func<Contact, bool>> condition);
    public Task<List<Contact>> GetContacts(Expression<Func<Contact, bool>> condition);
    public Task Update(Contact contact);
}