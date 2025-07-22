using AirlineBookingSystem.Flights.Application.Queries.Flights;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    public class GetFlightHandler : IRequestHandler<GetFlightQuery, FlightDto>
    {
        IFlightsRepository _repoistory;
        IMapper _mapper;
        public GetFlightHandler(IFlightsRepository repository, IMapper mapper)
        {
            _repoistory = repository;
            _mapper = mapper;
        }
        public async Task<FlightDto> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = await _repoistory.GetAsync(request.id);
            return flight is null ? null : _mapper.Map<FlightDto>(flight);
        }
    }
}
