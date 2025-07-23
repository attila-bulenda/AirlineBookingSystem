using AirlineBookingSystem.Flights.Application.Commands.Flights;
using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Application.Handlers.Flights
{
    internal class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand, DatabaseOperationResult>
    {
        private readonly IFlightsRepository _repository;
        private readonly IMapper _mapper;
        public DeleteFlightHandler(IFlightsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DatabaseOperationResult> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _repository.GetAsync(request.id);
            if (flight == null)
            {
                return new DatabaseOperationResult { NotFound = true };
            }
            try
            {
                await _repository.DeleteAsync(request.id);
                return new DatabaseOperationResult { Success = true };
            }
            catch (DbUpdateConcurrencyException)
            {
                return new DatabaseOperationResult { ErrorMessage = "Concurrency conflict." };
            }
            catch (DbUpdateException)
            {
                return new DatabaseOperationResult { ErrorMessage = "Cannot delete this flight because it has associated bookings." };
            }
            catch (Exception)
            {
                return new DatabaseOperationResult { ErrorMessage = "Unknown error occurred." };
            }
        }
    }
}
