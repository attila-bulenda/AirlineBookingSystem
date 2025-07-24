using AirlineBookingSystem.Flights.Application.Commands.Flights;
using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using Contracts.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    internal class UpdateFlightHandler : IRequestHandler<UpdateFlightCommand, DatabaseOperationResult>
    {
        private readonly IFlightsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public UpdateFlightHandler(IFlightsRepository repository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<DatabaseOperationResult> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flightToUpdate = await _repository.GetAsync(request.id);
            if (flightToUpdate == null)
            {
                return new DatabaseOperationResult { NotFound = true };
            }
            _mapper.Map(request.flight, flightToUpdate);
            try
            {
                await _repository.UpdateAsync(flightToUpdate);
                await _publishEndpoint.Publish(new FlightUpdatedEvent(flightToUpdate.FlightCode));
                return new DatabaseOperationResult { Success = true };
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new DatabaseOperationResult { ErrorMessage = "Concurrency conflict." };
            }
            catch (DbUpdateException ex)
            {
                return new DatabaseOperationResult { ErrorMessage = "Database error." };
            }
            catch (Exception ex)
            {
                return new DatabaseOperationResult { ErrorMessage = "Unknown error occurred." };
            }
        }
    }
}

