using BookanAPI.Configurations;
using BookanLibrary.Core.Model;
using BookanLibrary.Core.Model.Newsletter;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;

namespace BookanAPI.EmailServices
{
    public class EmailService : IEmailService
    {

        private readonly SendGridClient _client;
        private readonly string _appUrl;

        public EmailService(IConfiguration configuration) {
            string apiKey = configuration["Sendgrid:ApiKey"];
            _appUrl = configuration["Sendgrid:CallbackUrl"];

            Console.WriteLine("api key " + apiKey);
            Console.WriteLine(_appUrl);

            _client = new SendGridClient(apiKey);
            
        }  
        public async Task SendVerificationMail(string code, string receiver, int id)
        {
            try
            {

            
            Console.WriteLine("sending");
            var url = _appUrl + "/verify?id="+ id +"&code=" + code;
            Console.WriteLine(url);
            var body = "Please confirm your email address <a href=" + url + ">Click here </a>";
            Console.WriteLine(body);

            var subject = "Verification!";
            Console.WriteLine("subject " + subject);

            Console.WriteLine("receiver " + receiver);
            string htmlContent = "Please confirm your email address <a href=" + url + ">Click here </a>";


            await SendEmail(body, subject, receiver, htmlContent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task SendNewsletterEmail(Newsletter newsletter, string subscriberEmail) {
            Console.WriteLine("link " + newsletter.PicUrl);
            string htmlContent = newsletter.Content + " <a href=\"http://localhost:3000\"><br><img src=\"" + newsletter.PicUrl + "\"/></a>";
            await SendEmail(newsletter.Content, newsletter.Title, subscriberEmail, htmlContent);
        }


        private async Task SendEmail(string body, string subject, string receiver, string htmlContent) {
            EmailAddress from = new EmailAddress("sara14042000@gmail.com");
            EmailAddress to = new EmailAddress(receiver);
            SendGridMessage message = MailHelper.CreateSingleEmail(from, to, subject, body, htmlContent);
            var response = await _client.SendEmailAsync(message);
        }
    }
}
