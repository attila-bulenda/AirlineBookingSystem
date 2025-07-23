using AirlineBookingSystem.Flights.Application.Handlers.Bookings;
using AirlineBookingSystem.Flights.Application.Handlers.Flights;
using System.Reflection;


namespace AirlineBookingSystem.Flights.Application.Configurations
{
    public static class HandlerAssemblies
    {
        public static Assembly[] GetMediatRHandlers()
        { 
            return
            [
                Assembly.GetExecutingAssembly(),
                typeof(GetAllFlightsHandler).Assembly,
                typeof(GetAllFlightsWithBookingsHandler).Assembly,
                typeof(GetFlightHandler).Assembly,
                typeof(CreateFlightHandler).Assembly,
                typeof(UpdateFlightHandler).Assembly,
                typeof(GetAllBookingsHandler).Assembly,
                typeof(GetBookingHandler).Assembly
            ];
        }
    }
}
