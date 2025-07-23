using AirlineBookingSystem.Flights.Application.Commands.Bookings;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Bookings
{
    internal class CreateBookingHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IBookingsRepository _repository;
        private readonly IMapper _mapper;
        public CreateBookingHandler(IBookingsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = _mapper.Map<Booking>(request.booking);
            booking.Flight = null;
            await _repository.AddAsync(booking);
            return booking.Id;
        }
    }
}
