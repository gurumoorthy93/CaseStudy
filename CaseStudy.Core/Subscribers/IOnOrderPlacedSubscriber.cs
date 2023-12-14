namespace CaseStudy.Core.Subscribers
{
    public interface IOnOrderPlacedSubscriber
    {
        void announceOrderPlaced(int OrderId);
    }
}
