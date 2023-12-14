using CaseStudy.Core.Subscribers;
using CaseStudy.Services.Subscribers;

namespace CaseStudy.Services.Publishers
{
    public class OrderPublisherQueue
    {
        private List<IOnOrderPlacedSubscriber> onOrderPlacedSubscribers = new();

        public OrderPublisherQueue()
        {
            new InvoiceGenerator(this);
            new Payment(this);
            new EmailSender(this);
        }

        public void PublishData(int OrderId)
        {
            OnOrderPlaced(OrderId);
        }

        public void RegisterSubscriber(IOnOrderPlacedSubscriber onOrderPlacedSubscriber)
        {
            onOrderPlacedSubscribers.Add(onOrderPlacedSubscriber);
        }

        public void UnRegisterSubscriber(IOnOrderPlacedSubscriber onOrderPlacedSubscriber)
        {
            onOrderPlacedSubscribers.Remove(onOrderPlacedSubscriber);
        }

        private void OnOrderPlaced(int orderId)
        {
            foreach (var subscriber in onOrderPlacedSubscribers)
            {
                subscriber.announceOrderPlaced(orderId);
            }
        }
    }
}
