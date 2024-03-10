namespace TecnoDiversity.Utils
{
  public interface IEmailSender
  {
    Task SendEmailAsync(string email, string subject, string message);

  }
}