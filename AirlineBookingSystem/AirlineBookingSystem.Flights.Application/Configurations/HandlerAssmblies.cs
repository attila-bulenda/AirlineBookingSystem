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
            ];
        }
    }
}
