using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem.Users.Core.DTOs
{
    public class RegisterUserDto: SystemUserDto
    {
        [Required]
        public string Password { get; set; }
    }
}
