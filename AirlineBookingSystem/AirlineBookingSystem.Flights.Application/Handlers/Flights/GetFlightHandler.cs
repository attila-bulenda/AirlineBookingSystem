using AirlineBookingSystem.Flights.Application.Queries.Flights;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    public class GetFlightHandler : IRequestHandler<GetFlightQuery, FlightDto>
    {
        IFlightsRepository _repository;
        IMapper _mapper;
        public GetFlightHandler(IFlightsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<FlightDto> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            object? test = null;
            var length = test.ToString();

            var flight = await _repository.GetAsync(request.id);
            return flight is null ? null : _mapper.Map<FlightDto>(flight);
        }
    }
}
