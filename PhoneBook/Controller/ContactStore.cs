using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BuilderContext;
using PhoneBook.Model.DBO;

namespace PhoneBook.Controller;

public class ContactStore : IContactStore
{
    private PhoneBookContext Db { get; }

    public ContactStore(PhoneBookContext db) => Db = db;
    
    public async Task Insert(Contact contact)
    {
        await Db.AddAsync(contact);
        await Db.SaveChangesAsync();
    }

    public async Task Delete(Contact contact)
    {
        Db.Remove(contact);
        await Db.SaveChangesAsync();
    }

    public async Task Update(Contact contact)
    {
        Db.Update(contact);
        await Db.SaveChangesAsync();
    }
    public async Task<List<Contact>> GetContacts(Expression<Func<Contact, bool>> condition) =>
        await Db.Set<Contact>().Where(condition).ToListAsync();
    public async Task<Contact?> GetContact(Expression<Func<Contact, bool>> condition) =>
        await Db.Set<Contact>().FirstOrDefaultAsync(condition);
}