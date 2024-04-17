using System.ComponentModel.DataAnnotations;

namespace Web_API_Topstyles.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
