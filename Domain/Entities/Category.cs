using System.ComponentModel.DataAnnotations;

namespace Web_API_Topstyles.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
