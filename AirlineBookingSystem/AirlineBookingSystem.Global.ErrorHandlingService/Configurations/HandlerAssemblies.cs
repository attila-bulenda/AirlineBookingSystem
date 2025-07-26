using AirlineBookingSystem.Global.ErrorHandlingService.Handlers;
using System.Reflection;

namespace AirlineBookingSystem.Global.ErrorHandlingService.Configurations
{
    public static class HandlerAssemblies
    {
        public static Assembly[] GetMediatRHandlers()
        {
            return
            [
                Assembly.GetExecutingAssembly(),
                typeof(ErrorLogCreationHandler).Assembly
            ];
        }
    }
}
