using AirlineBookingSystem.Flights.Application.Queries.Bookings;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Bookings
{
    public class GetBookingHandler : IRequestHandler<GetBookingQuery, BookingDetailsDto>
    {
        private readonly IBookingsRepository _repository;
        private readonly IMapper _mapper;

        public GetBookingHandler(IBookingsRepository repository, IMapper mapper)
        {
           _repository = repository;
           _mapper = mapper;
        }
        public async Task<BookingDetailsDto> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetAsync(request.id);
            return booking is null ? null : _mapper.Map<BookingDetailsDto>(booking);
        }
    }
}
