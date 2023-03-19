using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Newsletter;

namespace BookanAPI.EmailServices
{
    public interface IEmailService
    {
        Task SendVerificationMail(string code, string receiver, int id);
        Task SendNewsletterEmail(Newsletter newsletter, string subscriberEmail);
    }
}
