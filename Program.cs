using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== Multi Email Sender (Individual) ===");

        Console.Write("Enter your Gmail address: ");
        string fromEmail = Console.ReadLine();

        Console.Write("Enter your App Password: ");
        string password = Password.ReadPassword();

        Console.Write("Enter recipient emails (comma separated): ");
        string toEmails = Console.ReadLine();

        Console.Write("Enter subject: ");
        string subject = Console.ReadLine();

        Console.Write("Enter message: ");
        string body = Console.ReadLine();
         
        //MailSend class
        await MailSend.SendEmails(fromEmail, password, toEmails, subject, body);
    }
}


