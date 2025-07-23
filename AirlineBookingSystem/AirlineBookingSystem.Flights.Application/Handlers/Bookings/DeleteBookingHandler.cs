using AirlineBookingSystem.Flights.Application.Commands.Bookings;
using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Application.Handlers.Bookings
{
    internal class DeleteBookingHandler : IRequestHandler<DeleteBookingCommand, DatabaseOperationResult>
    {
        private readonly IBookingsRepository _repository;
        private readonly IMapper _mapper;
        public DeleteBookingHandler(IBookingsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DatabaseOperationResult> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _repository.GetAsync(request.id);
            if (booking == null)
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
                return new DatabaseOperationResult { ErrorMessage = "Cannot delete this booking due to related data or a database constraint." };
            }
            catch (Exception)
            {
                return new DatabaseOperationResult { ErrorMessage = "Unknown error occurred." };
            }
        }
    }
}
