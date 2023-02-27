using MailKit.Net.Smtp;
using MimeKit;
using PhoneBook.Model.DTO;

namespace PhoneBook.Services;

public class EmailService
{
    private MimeMessage Message { get; }

    public EmailService()
    {
        Message = new MimeMessage();
    }

    public void SendEmail(ContactDto contact, MailboxAddress myDetails)
    {
        Message.To.Add(new MailboxAddress($"{contact.Name}", $"{contact.Email}"));
        Message.Subject = "How you doin'?";
        Message.Body = new TextPart("plain");

        using var client = new SmtpClient ();
        client.Connect ("smtp.friends.com", 587, false);

        // Note: only needed if the SMTP server requires authentication
        client.Authenticate ("joey", "password");

        client.Send (Message);
        client.Disconnect (true);
    }
}