using CaseStudy.Core.Common;
using CaseStudy.Core.Data;
using CaseStudy.Core.Dtos;
using CaseStudy.Core.Models;
using CaseStudy.Core.Services;
using CaseStudy.Services.Publishers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CaseStudy.Services.Services
{
    public class OrdersService: IOrdersService
    {
        private readonly ActionContext actionContext;
        private readonly ILogger<OrdersService> logger;

        public OrdersService(IServiceProvider serviceProvider)
        {
            this.actionContext = serviceProvider.GetRequiredService<ActionContext>();
            this.logger = serviceProvider.GetRequiredService<ILogger<OrdersService>>();
        }

        public int GetOrderById(int id, out OrderDto orderDto)
        {
            orderDto = new OrderDto();

            var User = UsersData.Users.Where(x => x.Id == actionContext.UserId).FirstOrDefault();

            if (User == null)
                return -1;

            var Order = OrdersData.Orders.Where(x => x.Id == id).FirstOrDefault();

            if (Order == null)
                return -2;

            if (Order.UserId != actionContext.UserId)
            {
                logger.LogError("UnAuthorized access of Order ID: " + id + " by the User " + actionContext.UserId);
                return -3;
            }

            orderDto.FirstName = User.FirstName;
            orderDto.LastName = User.LastName;
            orderDto.Email = User.Email;
            orderDto.Address = User.Address;
            orderDto.City = User.City;
            orderDto.Region = User.Region;
            orderDto.ZipCode= User.ZipCode;
            orderDto.TotalAmount = Order.TotalAmount;
            orderDto.orderProducts = Order.orderProductModels.Select(x => new OrderProductDto()
            {
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                Price = x.Price
            }).ToList();

            return 1;
        }

        public int GetOrders(int PageNo, int PageSize, out OrderListDto orderListDto)
        {
            orderListDto = null;

            var User = UsersData.Users.Where(x => x.Id == actionContext.UserId).FirstOrDefault();

            if (User == null)
                return -1;

            var totalItems = OrdersData.Orders.Where(x => x.UserId == actionContext.UserId).Count();
            var pageNumber = PageNo <= 0 ? 1 : PageNo;
            var pageSize = PageSize <= 0 ? totalItems : PageSize;
            var totalPages = ((int)totalItems + pageSize - 1) / pageSize;
            var pageItems = OrdersData.Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            List<OrderDto> orderDtos = new List<OrderDto>();

            foreach (var item in pageItems)
            {
                OrderDto orderDto = new OrderDto();

                orderDto.FirstName = User.FirstName;
                orderDto.LastName = User.LastName;
                orderDto.Email = User.Email;
                orderDto.Address = User.Address;
                orderDto.City = User.City;
                orderDto.Region = User.Region;
                orderDto.ZipCode = User.ZipCode;
                orderDto.TotalAmount = item.TotalAmount;
                orderDto.orderProducts = item.orderProductModels.Select(x => new OrderProductDto()
                {
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList();

                orderDtos.Add(orderDto);
            }

            orderListDto = new OrderListDto(orderDtos, totalItems, pageSize, pageNumber, totalPages);

            return 1;
        }

        public int PlaceOrder(List<PlaceOrderDto> placeOrderDto)
        {
            if(actionContext.UserId <= 0)
            {
                return -1;
            }

            double TotalAmount = 0;

            List<OrderProductModel> orderProductModels = new List<OrderProductModel>();

            foreach (var placeOrder in placeOrderDto)
            {
                var product = ProductsData.Products.Where(x => x.Id == placeOrder.ProductID).FirstOrDefault();

                if (product != null)
                {
                    if (product.Quantity <= 0)
                    {
                        return -2;
                    }

                    if (product.Quantity < placeOrder.Quantity)
                    {
                        return -3;
                    }
                }
                else
                {
                    return -4;
                }

                TotalAmount += placeOrder.Quantity * product.Price;

                orderProductModels.Add(new OrderProductModel()
                {
                    ProductName = product.Name,
                    Quantity = placeOrder.Quantity,
                    Price = product.Price
                });
            }

            var NewOrderId = OrdersData.Orders.Count > 0 ? OrdersData.Orders.Max(x => x.Id) + 1 : 1;

            OrderModel orderModel = new OrderModel()
            {
                Id = NewOrderId,
                UserId = actionContext.UserId,
                TotalAmount = TotalAmount,
                orderProductModels = orderProductModels
            };

            foreach (var placeOrder in placeOrderDto)
            {
                ProductsData.Products.Where(x => x.Id == placeOrder.ProductID).First().Quantity -= placeOrder.Quantity;
            }

            OrdersData.Orders.Add(orderModel);

            OrderPublisherQueue orderPublisher = new OrderPublisherQueue();
            orderPublisher.PublishData(NewOrderId);
            
            return NewOrderId;
        }
    }
}
