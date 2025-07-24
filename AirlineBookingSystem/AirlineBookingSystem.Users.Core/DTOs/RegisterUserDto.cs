using System.ComponentModel.DataAnnotations;

namespace AirlineBookingSystem.Users.Core.DTOs
{
    public class RegisterUserDto: SystemUserDto
    {
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
