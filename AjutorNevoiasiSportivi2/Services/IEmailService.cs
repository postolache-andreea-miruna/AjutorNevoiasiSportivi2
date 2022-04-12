using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}
