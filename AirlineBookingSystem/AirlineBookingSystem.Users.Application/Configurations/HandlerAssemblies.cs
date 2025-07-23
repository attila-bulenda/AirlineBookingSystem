using AirlineBookingSystem.Users.Application.Handlers;
using System.Reflection;

namespace AirlineBookingSystem.Users.Application.Configurations
{
    public class HandlerAssemblies
    {        public static Assembly[] GetMediatRHandlers()
        {
            return
            [
                Assembly.GetExecutingAssembly(),
                typeof(RegisterUserHandler).Assembly,
                typeof(LoginUserHandler).Assembly,
                typeof(GetUserInfoHandler).Assembly
            ];
        }
    }
}
