using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PhoneBook.Services;

public class ValidatorService
{
    public bool Validate( string input, Func<string, bool> func) => func(input);
}