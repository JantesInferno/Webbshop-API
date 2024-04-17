using System.ComponentModel.DataAnnotations;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Domain.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        [Required]
        public Dictionary<int, int> ProductsQuantity { get; set; }
    }
}
