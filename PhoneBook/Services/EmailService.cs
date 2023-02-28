using System.Net.Mime;
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

    public void SendEmail(ContactDto contact, string? subject, string? text, string? emailAdd, string? emailPass)
    {
        
        Message.From.Add(new MailboxAddress("abubakar ahmed", emailAdd));
        Message.To.Add(new MailboxAddress($"{contact.Name}", $"{contact.Email}"));
        Message.Subject = subject;
        Message.Body = new TextPart("plain")
        {
            Text = text
        };

        using var client = new SmtpClient ();
        client.Connect ("smtp.gmail.com", 587, false);
        
        // Note: only needed if the SMTP server requires authentication
        client.Authenticate (emailAdd, emailPass);

        client.Send (Message);
        client.Disconnect (true);
    }
}