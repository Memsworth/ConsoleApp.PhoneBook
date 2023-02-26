using Microsoft.EntityFrameworkCore;
using PhoneBook.Model.DBO;

namespace PhoneBook.BuilderContext;

public class PhoneBookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    private string DbPath { get; }
    
    public PhoneBookContext()
    {
        var folder = Environment.SpecialFolder.Personal;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "phonebook.db");
    }
    
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}