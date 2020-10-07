using System.Threading.Tasks;
using CQRSInfra.Application.Configuration.Emails;

namespace CQRSInfra.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            // impelemnt  with email service.

            return;
        }
    }
}