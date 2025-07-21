using AirlineBookingSystem.Flights.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Core.Interfaces
{
    public interface IBookingsRepository: IGenericRepository<Booking>
    {
    }
}
