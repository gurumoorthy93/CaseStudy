using CaseStudy.Core.Subscribers;
using CaseStudy.Services.Publishers;

namespace CaseStudy.Services.Subscribers
{
    public class Payment : IOnOrderPlacedSubscriber
    {
        public Payment(OrderPublisherQueue orderPublisher)
        {
            orderPublisher.RegisterSubscriber(this);
        }

        public void announceOrderPlaced(int OrderId)
        {
            Console.WriteLine("Payment done for the Order: " + OrderId);
        }
    }
}
