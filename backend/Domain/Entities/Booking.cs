﻿using backend.Domain.Enums;
using Domain.Common;

namespace backend.Domain.Entities;
public class Booking : BaseAuditableEntity
{
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public BookingStatus Status { get; set; }
    public string? Comments { get; set; }
}