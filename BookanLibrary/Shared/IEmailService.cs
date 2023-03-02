using BookanLibrary.Core.Model;

namespace BookanAPI.EmailServices
{
    public interface IEmailService
    {
        Task SendVerificationMail(string code, string receiver, int id);
        Task SendNewsletterEmail(string title, string content, string subscriberEmail);
    }
}
