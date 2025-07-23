using AirlineBookingSystem.Flights.Application.Queries.Bookings;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Bookings
{
    public class GetAllBookingsHandler: IRequestHandler<GetAllBookingsQuery, IEnumerable<BookingDetailsDto>>
    {
        private readonly IBookingsRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBookingsHandler(IBookingsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDetailsDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _repository.GetAllAsync();
            return bookings is null ? null : _mapper.Map<List<BookingDetailsDto>>(bookings);
        }
    }
}
