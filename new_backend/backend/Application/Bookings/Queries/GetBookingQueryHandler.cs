using AutoMapper;
using backend.Application.Bookings.DTOs;
using Domain.Interfaces;
using MediatR;

namespace backend.Application.Bookings.Queries;
public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingDTO?>
{
    private readonly IBookingsRepository _bookingRepository;
    private readonly IMapper _mapper;
    public GetBookingQueryHandler(IBookingsRepository bookingRepository, IMapper mapper)
    {
        _mapper = mapper;
        _bookingRepository = bookingRepository;
    }
    public async Task<BookingDTO?> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(request.Id);

        if (booking == null)
        {
            return null;
        }

        return _mapper.Map<BookingDTO>(booking);
    }
}
