using System.ComponentModel.DataAnnotations;

namespace Web_API_Topstyles.Domain.DTOs.UserDTOs
{
    public class LoginUserDTO
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
