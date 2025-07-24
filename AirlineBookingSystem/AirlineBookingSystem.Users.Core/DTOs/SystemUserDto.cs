using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem.Users.Core.DTOs
{
    public class SystemUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Email]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
