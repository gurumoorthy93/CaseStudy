using CaseStudy.Core.Dtos;

namespace CaseStudy.Core.Services
{
    public interface IOrdersService
    {
        int GetOrderById(int id, out OrderDto orderDto);
        int GetOrders(int PageNo, int PageSize, out OrderListDto orderDtos);
        int PlaceOrder(List<PlaceOrderDto> placeOrderDto);
    }
}
