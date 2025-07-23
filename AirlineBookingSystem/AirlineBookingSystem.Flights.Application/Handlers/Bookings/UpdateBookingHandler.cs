using AirlineBookingSystem.Flights.Application.Commands.Bookings;
using AirlineBookingSystem.Flights.Application.Exceptions;
using AirlineBookingSystem.Flights.Core.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingSystem.Flights.Application.Handlers.Bookings
{
    internal class UpdateBookingHandler : IRequestHandler<UpdateBookingCommand, DatabaseOperationResult>
    {
        private readonly IBookingsRepository _repository;
        private readonly IMapper _mapper;
        public UpdateBookingHandler(IBookingsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DatabaseOperationResult> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var bookingToUpdate = await _repository.GetAsync(request.id);
            if (bookingToUpdate == null)
            {
                return new DatabaseOperationResult { NotFound = true };
            }
            _mapper.Map(request.booking, bookingToUpdate);
            bookingToUpdate.FlightId = request.booking.FlightId;
            bookingToUpdate.Flight = null;
            try
            {
                await _repository.UpdateAsync(bookingToUpdate);
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
