using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Web_API_Topstyles.Domain.Entities;

namespace Web_API_Topstyles.Domain.Identity
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }
    }
}
