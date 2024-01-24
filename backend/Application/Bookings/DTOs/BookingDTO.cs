using backend.Domain.Enums;

namespace backend.Application.Bookings.DTOs;
public record BookingDTO
{
    public Guid Id { get; init; }
    public int UserId { get; init; }
    public int ServiceId { get; init; }
    public DateTime Date { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
    public BookingStatus Status { get; init; }
    public string? Comments { get; init; }
}

