namespace PhoneBook.Controller;

public interface IDbController
{
    public Task Insert();
    public Task Delete();
    public Task Get();
    public Task Update();
}