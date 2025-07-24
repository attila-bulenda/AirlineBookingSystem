using AirlineBookingSystem.Invoices.Application.Handlers;
using System.Reflection;

namespace AirlineBookingSystem.Invoices.Application.Configurations
{
    public class HandlerAssemblies
    {
        public static Assembly[] GetMediatRHandlers()
        {
            return
            [
                Assembly.GetExecutingAssembly(),
                typeof(GetInvoiceHandler).Assembly,
                typeof(CreateInvoiceHandler).Assembly,
                typeof(DeleteInvoiceHandler).Assembly
            ];
        }
    }
}
