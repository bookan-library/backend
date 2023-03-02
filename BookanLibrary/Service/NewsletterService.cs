using BookanAPI.EmailServices;
using BookanLibrary.Core.Model.Newsletter;
using BookanLibrary.Repository.Core;
using BookanLibrary.Service.Core;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Service
{
    public class NewsletterService : INewsletterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        public NewsletterService(IUnitOfWork unitOfWork, IEmailService emailService) {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task SendNewsletter(Newsletter newsletter)
        {
            await _unitOfWork.NewsLetterRepository.Add(newsletter);
            IEnumerable<NewsletterSubscriber> subscribers = await _unitOfWork.NewsletterSubscriberRepository.GetAll();
            foreach (NewsletterSubscriber subscriber in subscribers) {
                await _emailService.SendNewsletterEmail(newsletter.Title, newsletter.Content, subscriber.SubscriberEmail);
            }
        }

        public async Task Subscribe(NewsletterSubscriber subscriber) {
            await _unitOfWork.NewsletterSubscriberRepository.Add(subscriber);
        }
    }
}
