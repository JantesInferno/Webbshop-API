using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web_API_Topstyles.Domain.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string SubTitle { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }
    }
}
