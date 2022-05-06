namespace WebApi.Domain.Interfaces.ServiceInterfaces
{
    public interface IEmailService
    {
        bool Send(
            string toName,
            string toEmail,
            string subject,
            string body,
            string fromName,
            string fromEmail);
    }
}
