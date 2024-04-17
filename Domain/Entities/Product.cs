using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Topstyles.Domain.Entities
{
    public class Product
    {
        [Key]
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

        [Required]
        public string ImageURL { get; set; }


        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
