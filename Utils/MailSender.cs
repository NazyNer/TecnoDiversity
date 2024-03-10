using System.Net.Mail;
using System.Net;

namespace TecnoDiversity.Utils
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "tecnotest@outlook.com";
            var pw = "TcTest24";

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
              EnableSsl = true,
              Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(new MailMessage(from: mail,to:email,subject,message));
        }
    }
}