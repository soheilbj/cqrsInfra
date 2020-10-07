using System.Threading.Tasks;

namespace CQRSInfra.Application.Configuration.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message);
    }
}