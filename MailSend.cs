using System;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

public static class MailSend
{
    public static async Task SendEmails(string fromEmail, string password, string toEmails, string subject, string body)
    {
        try
        {
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(fromEmail, password);

            foreach (var email in toEmails.Split(','))
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromEmail, fromEmail));
                message.To.Add(MailboxAddress.Parse(email.Trim()));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                await smtp.SendAsync(message);
                Console.WriteLine($"Sent to: {email.Trim()}");
            }

            await smtp.DisconnectAsync(true);
            Console.WriteLine("All emails sent successfully!");
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
