using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PhoneBook.Services;

public class ValidatorServiceHelper
{
    private static Regex PhoneRegex { get; } = 
        new Regex(
            @"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$");
    public bool ValidateEmail(string input)
    {
        var valid = MailAddress.TryCreate(input, out MailAddress? mailAddress);
        return valid;
    }

    public bool ValidatePhone(string input)
    {
        var matcher = PhoneRegex.Match(input);
        if (matcher.Success) return true;
        return false;
    }
    public bool ValidateName(string input) => !string.IsNullOrWhiteSpace(input);
}