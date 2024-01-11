using AutoMapper;
using backend.Application.Bookings.DTOs;
using Domain.Interfaces;
using MediatR;

namespace backend.Application.Bookings.Queries;
public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<BookingDTO>>
{
    private readonly IBookingsRepository _bookingRepository;
    private readonly IMapper _mapper;
    public GetAllBookingsQueryHandler(IBookingsRepository bookingRepository, IMapper mapper) 
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }
    public async Task<List<BookingDTO>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
    {
        var bookings = await _bookingRepository.GetAllAsync();
        var result  = _mapper.Map<List<BookingDTO>>(bookings);
        return result;
    }
}
