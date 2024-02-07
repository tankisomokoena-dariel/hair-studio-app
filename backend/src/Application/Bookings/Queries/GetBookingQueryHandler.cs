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
public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingDTO?>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    public GetBookingQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
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
