using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Topstyles.Domain.Entities
{
    public class OrderItem
    {
        //OrderItemId, OrderId, ProductId, Price, Quantity
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public virtual Product Product { get; set; }

    }
}
