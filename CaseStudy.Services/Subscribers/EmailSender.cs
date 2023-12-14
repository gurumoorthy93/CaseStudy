using CaseStudy.Core.Subscribers;
using CaseStudy.Services.Publishers;

namespace CaseStudy.Services.Subscribers
{
    public class EmailSender: IOnOrderPlacedSubscriber
    {
        public EmailSender(OrderPublisherQueue orderPublisher)
        {
            orderPublisher.RegisterSubscriber(this);
        }

        public void announceOrderPlaced(int OrderId)
        {
            Console.WriteLine("Email Sent for the Order: " + OrderId);
        }
    }
}
