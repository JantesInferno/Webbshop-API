using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Domain.DTOs.OrderDTOs;

namespace Web_API_Topstyles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("/api/order/get-order-by-userid")]
        [HttpGet]
        public async Task<IResult> GetOrdersFromUser()
        {
            var result = await _orderService.GetOrdersFromUser(User.Identity);

            return Results.Ok(result.Data);
        }

        [Route("/api/order/create-order")]
        [HttpPost]
        public async Task<IResult> CreateOrder(OrderDTO orderDto)
        {
            if (orderDto == null)
                return Results.Problem($"Ofullständig order", statusCode: 400);

            var result = await _orderService.CreateOrder(orderDto, User.Identity);

            if (!result.Success)
                return Results.Problem(result.ErrorMessage, statusCode: 400);

            return Results.Ok(result.Data);
        }
    }
}
