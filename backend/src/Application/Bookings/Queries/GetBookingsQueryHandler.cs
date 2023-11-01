using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using backend.Application.Bookings.DTOs;
using backend.Application.Common.Interfaces.Repositories;
using MediatR;

namespace backend.Application.Bookings.Queries;
public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, List<BookingDTO>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    public GetBookingsQueryHandler(IBookingRepository bookingRepository, IMapper mapper) 
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }
    public async Task<List<BookingDTO>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
    {
        var bookings = await _bookingRepository.GetAllAsync();
        var result  = _mapper.Map<List<BookingDTO>>(bookings);
        return result;
    }
}
