using PhoneBook.BuilderContext;
using PhoneBook.Model.DBO;

namespace PhoneBook.Controller;

public class DbController : IDbController
{
    private PhoneBookContext Db { get; }

    public DbController(PhoneBookContext db) => Db = db;
    
    public async Task Insert()
    {
        await Db.AddAsync(new Contact { Name = "Ahmet", PhoneNumber = "+912823213" });
        await Db.SaveChangesAsync();

    }

    public async Task Delete()
    {
        throw new NotImplementedException();
    }

    public async Task Get()
    {
        throw new NotImplementedException();
    }

    public async Task Update()
    {
        throw new NotImplementedException();
    }
}