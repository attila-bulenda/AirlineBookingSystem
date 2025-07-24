namespace AirlineBookingSystem.Notifications.Application.Notifications
{
    public static class Notifications
    {
        public static void FlightBookingNotification(string email, string flight)
        {
            Console.WriteLine($"Flight {flight} has been booked and confirmation sent to {email}. Thank you for choosing our airline.");
        }

        public static void FlightUpdateNotification(string flight)
        {
            Console.WriteLine($"Flight {flight} has been changed. Please contact our customer service for further information.");
        }

        public static void UserRegistrationNotification(string email)
        {
            Console.WriteLine($"User with {email} has been created. Thank you for joining our customer base.");
        }

        public static void UserDeletionNotification(string email)
        {
            Console.WriteLine($"User with {email} has been deleted. Hope to see you soon again!");
        }
    }
}