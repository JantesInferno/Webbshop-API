using System.Security.Principal;
using Web_API_Topstyles.Domain.DTOs.OrderDTOs;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Webshop.Core.Helpers;

namespace Web_API_Topstyles.Core.Interfaces
{
    public interface IOrderService
    {
        Task<ResultResponse<Order>> CreateOrder(OrderDTO orderDto, IIdentity userIdentity);
        Task<ResultResponse<List<Order>>> GetOrdersFromUser(IIdentity userIdentity);
    }
}
