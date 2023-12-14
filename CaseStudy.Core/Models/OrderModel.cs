namespace CaseStudy.Core.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            orderProductModels = new List<OrderProductModel>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public IEnumerable<OrderProductModel> orderProductModels { get; set; }
    }

    public class OrderProductModel
    {
        public OrderProductModel()
        {
            ProductName = string.Empty;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
