
namespace CaseStudy.Core.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            ZipCode = string.Empty;
            orderProducts = new List<OrderProductDto>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string ZipCode { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderProductDto> orderProducts { get; set; }
    }

    public class OrderProductDto
    {
        public OrderProductDto()
        {
            ProductName = string.Empty;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class OrderListDto : PageDetailsDto
    {
        public OrderListDto(IEnumerable<OrderDto> source, long total_records, int page_size, int page_number, int total_pages) : base(total_records, page_size, page_number, total_pages)
        {
            orderDtos = source;
        }

        public IEnumerable<OrderDto> orderDtos { get; set; }
    }
}
