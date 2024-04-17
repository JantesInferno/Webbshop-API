using AutoMapper;
using System.Security.Claims;
using System.Security.Principal;
using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Data.Interfaces;
using Web_API_Topstyles.Domain.DTOs.OrderDTOs;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Topstyles.Domain.Identity;
using Web_API_Webshop.Core.Helpers;

namespace Web_API_Topstyles.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public OrderService(IRepository<Order> orderRepo, IRepository<Product> productRepo, IMapper mapper, IUserService userService)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<ResultResponse<Order>> CreateOrder(OrderDTO orderDto, IIdentity userIdentity)
        {
            var userId = await _userService.GetUserIdFromClaims(userIdentity);

            var order = new Order();

            order.UserId = userId;
            order.OrderDate = DateTime.Now;

            var orderItems = new List<OrderItem>();

            foreach (KeyValuePair<int, int> item in orderDto.ProductsQuantity)
            {
                var product = await _productRepo.GetById(item.Key);
                if (product != null)
                {
                    order.TotalCost += product.Price * item.Value;

                    var orderItem = new OrderItem();
                    orderItem.Quantity = item.Value;
                    orderItem.Product = product;
                    orderItem.OrderId = order.OrderId;
                    orderItems.Add(orderItem);
                }
            }

            if (orderItems.Count > 0)
                order.OrderItems = orderItems;
            else
                return new ResultResponse<Order>(errorMessage: "Varukorgen är tom");

            await _orderRepo.Add(order);

            return new ResultResponse<Order>(data: order);
        }

        public async Task<ResultResponse<List<Order>>> GetOrdersFromUser(IIdentity identity)
        {
            var userId = await _userService.GetUserIdFromClaims(identity);

            var orders = await _orderRepo.Find(order => order.UserId == userId);

            return new ResultResponse<List<Order>>(data: orders);
        }
    }
}
