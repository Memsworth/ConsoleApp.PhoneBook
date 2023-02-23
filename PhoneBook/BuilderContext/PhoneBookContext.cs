using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Model.DBO;

namespace PhoneBook.BuilderContext;

public class PhoneBookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).AddJsonFile("appsettings.json")
            .Build();
        options.UseSqlite(configuration.GetConnectionString("PhoneBook"));
    }
}