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

    public Task<Contact?> Get(int id)
    {
        return Db.Set<Contact>().FirstOrDefaultAsync(x => x.ContactId == id);
    }

    public async Task Update(Contact contact)
    {
        Db.Update(contact);
        await Db.SaveChangesAsync();
    }

    public Task<List<Contact>> GetAll()
    {
       return Db.Set<Contact>().ToListAsync();
    }
}