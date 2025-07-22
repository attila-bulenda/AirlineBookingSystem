using AirlineBookingSystem.Flights.Application.Queries.Flights;
using AirlineBookingSystem.Flights.Core.DTOs;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    public class GetAllFlightsWithBookingsHandler : IRequestHandler<GetAllFlightsWithBookingsQuery, IEnumerable<FlightDetailsDto>>
    {
        private readonly IFlightsRepository _repository;
        private readonly IMapper _mapper;
        public GetAllFlightsWithBookingsHandler(IFlightsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightDetailsDto>> Handle(GetAllFlightsWithBookingsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _repository.GetAllWithBookingsAsync();
            return flights is null ? null : _mapper.Map<List<FlightDetailsDto>>(flights);
        }
    }
}
