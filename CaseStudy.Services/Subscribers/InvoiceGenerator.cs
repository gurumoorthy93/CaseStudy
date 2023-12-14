using CaseStudy.Core.Subscribers;
using CaseStudy.Services.Publishers;

namespace CaseStudy.Services.Subscribers
{
    public class InvoiceGenerator : IOnOrderPlacedSubscriber
    {
        public InvoiceGenerator(OrderPublisherQueue orderPublisher)
        {
            orderPublisher.RegisterSubscriber(this);
        }

        public void announceOrderPlaced(int OrderId)
        {
            Console.WriteLine("Invoice Generated for the Order: " + OrderId);
        }
    }
}
