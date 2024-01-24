using AutoMapper;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace backend.Application.Bookings.Commands.CreateBooking;
public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Result>
{
    private readonly IBookingsRepository _bookingRepository;
    private readonly IMapper _mapper;
    public CreateBookingCommandHandler(IBookingsRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }
    public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var booking = _mapper.Map<Booking>(request.Booking);
            await _bookingRepository.AddAsync(booking);
            booking.AddDomainEvent(new BookingCreatedEvent(booking));
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new List<string> { ex.Message });
        }
    }
}
