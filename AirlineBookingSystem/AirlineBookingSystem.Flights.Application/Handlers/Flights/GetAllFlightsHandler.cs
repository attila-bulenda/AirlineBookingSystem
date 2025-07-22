using AirlineBookingSystem.Flights.Application.Queries.Flights;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    public class GetAllFlightsHandler: IRequestHandler<GetAllFlightsQuery, IEnumerable<FlightDetailsDto>>
    {
        private readonly IFlightsRepository _repository;
        private readonly IMapper _mapper;
        public GetAllFlightsHandler(IFlightsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightDetailsDto>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _repository.GetAllAsync();
            return _mapper.Map<List<FlightDetailsDto>>(flights);
        }
    }
}
