using AirlineBookingSystem.Flights.Application.Commands.Flights;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AirlineBookingSystem.Flights.Core.Models;
using AutoMapper;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    public class CreateFlightHandler : IRequestHandler<CreateFlightCommand, int>
    {
        private readonly IFlightsRepository _repository;
        private readonly IMapper _mapper;

        public CreateFlightHandler(IFlightsRepository repository, IMapper mapper)
        {
           _repository = repository;
           _mapper = mapper;
        }

        public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = _mapper.Map<Flight>(request.flight);
            await _repository.AddAsync(flight);
            return flight.Id;
        }
    }
}
