using CaseStudy.Core.Dtos;
using CaseStudy.Services.Services;
using CaseStudy.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Tests.Orders
{
    public class OrdersServiceTest : IClassFixture<OrdersServiceFixture>
    {
        private OrdersServiceFixture _ordersServiceFixture;
        private IServiceProvider _serviceProvider;
        public OrdersServiceTest(OrdersServiceFixture ordersServiceFixture)
        {
            _ordersServiceFixture = ordersServiceFixture;
            _serviceProvider = ordersServiceFixture.ServiceCollection.BuildServiceProvider();
        }

        [Fact]
        public async void Mock_PlaceOrder_BadUser()
        {
            _ordersServiceFixture.Mock_ActionContext_BadRequest();

            var OrdersService = new OrdersService(_serviceProvider);

            List<PlaceOrderDto> placeOrderDto = new List<PlaceOrderDto>
            {
                new PlaceOrderDto(){
                    ProductID = 1,
                    Quantity = 11
            }};

            var result = OrdersService.PlaceOrder(placeOrderDto);

            Assert.Equal(-1, result);
        }

        [Fact]
        public async void Mock_PlaceOrder_BadQuantity()
        {
            _ordersServiceFixture.Mock_ActionContext_Ok();

            var OrdersService = new OrdersService(_serviceProvider);

            List<PlaceOrderDto> placeOrderDto = new List<PlaceOrderDto>
            {
                new PlaceOrderDto(){
                    ProductID = 1,
                    Quantity = 11
            }};

            var result = OrdersService.PlaceOrder(placeOrderDto);

            Assert.Equal(-3, result);
        }

        [Fact]
        public async void Mock_PlaceOrder_Ok()
        {
            _ordersServiceFixture.Mock_ActionContext_Ok();

            var OrdersService = new OrdersService(_serviceProvider);

            List<PlaceOrderDto> placeOrderDto = new List<PlaceOrderDto>
            {
                new PlaceOrderDto(){
                    ProductID = 2,
                    Quantity = 1
            }};

            var result = OrdersService.PlaceOrder(placeOrderDto);

            Assert.Equal(1, result);
        }

        [Fact]
        public async void Mock_GetOrderById_BadRequest()
        {
            _ordersServiceFixture.Mock_ActionContext_Ok();

            var OrdersService = new OrdersService(_serviceProvider);

            var result = OrdersService.GetOrderById(10, out OrderDto orderDto);

            Assert.Equal(-2, result);
        }

        [Fact]
        public async void Mock_GetOrders_Ok()
        {
            _ordersServiceFixture.Mock_ActionContext_Ok();

            var OrdersService = new OrdersService(_serviceProvider);

            var result = OrdersService.GetOrders(1, 1, out OrderListDto orderListDto);

            Assert.Equal(1, result);
        }
    }
}
