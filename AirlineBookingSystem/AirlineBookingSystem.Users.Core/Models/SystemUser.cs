using Microsoft.AspNetCore.Identity;

namespace AirlineBookingSystem.Users.Core.Models
{
    public class SystemUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
