using System.ComponentModel.DataAnnotations;

namespace Web_API_Topstyles.Domain.DTOs.UserDTOs
{
    public class UserDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
