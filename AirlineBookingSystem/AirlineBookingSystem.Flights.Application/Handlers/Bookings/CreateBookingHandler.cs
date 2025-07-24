using AirlineBookingSystem.Flights.Application.Commands.Bookings;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;
using AirlineBookingSystem.Invoices.Core.DTOs;
using AutoMapper;
using Contracts.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Bookings
{
    internal class CreateBookingHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IBookingsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public CreateBookingHandler(IBookingsRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = _mapper.Map<Booking>(request.booking);
            booking.Flight = null;
            await _repository.AddAsync(booking);
            // We have some fixed dummy values here, the Flight and Booking models could be extended
            // further with more data but for demo purposes I decided to use some hardcoded values
            // We need to get the freshly saved Booking entity as it contains the correct Flight navigational property
            var newBooking = await _repository.GetAsync(booking.Id);
            var invoice = new InvoiceDto()
            {
                Amount = 68.25m,
                PaymentDate = DateTime.UtcNow,
                CustomerName = booking.PassengerName,
                CustomerEmail = "test@gmail.com",
                FlightNumber = newBooking.Flight.FlightCode
            };
            await _publishEndpoint.Publish(new BookingCreatedEvent(invoice));
            return booking.Id;
        }
    }
}
