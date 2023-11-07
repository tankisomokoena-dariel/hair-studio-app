using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.Common.Mappings;
using backend.Domain.Entities;

namespace backend.Application.Bookings.DTOs;
public record BookingDTO( int Id, 
                        int UserId, 
                        int ServiceId, 
                        DateTime Date, 
                        DateTime StartTime, 
                        DateTime EndTime, 
                        string? Comments) : IMapFrom<Booking>;

