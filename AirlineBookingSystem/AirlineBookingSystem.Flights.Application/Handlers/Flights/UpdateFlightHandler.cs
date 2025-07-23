using AirlineBookingSystem.Flights.Application.Commands.Flights;
using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    internal class UpdateFlightHandler : IRequestHandler<UpdateFlightCommand, UpdateFlightResult>
    {
        private readonly IFlightsRepository _repository;
        private readonly IMapper _mapper;
        public UpdateFlightHandler(IFlightsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateFlightResult> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightToUpdate = await _repository.GetAsync(request.id);
            if (flightToUpdate == null)
            {
                return new UpdateFlightResult { NotFound = true };
            }
            _mapper.Map(request.flight, flightToUpdate);
            try
            {
                await _repository.UpdateAsync(flightToUpdate);
                return new UpdateFlightResult { Success = true };
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new UpdateFlightResult { ErrorMessage = "Concurrency conflict." };
            }
            catch (DbUpdateException ex)
            {
                return new UpdateFlightResult { ErrorMessage = "Database error." };
            }
            catch (Exception ex)
            {
                return new UpdateFlightResult { ErrorMessage = "Unknown error occurred." };
            }
        }
    }
}

