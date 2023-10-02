using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Entities;
public class Payment : BaseAuditableEntity
{
    public int BookingId { get; set; }
    public int ServiceId { get; set; }
    public DateTime Timestamp { get; set; }
    public double AmountPaid { get; set; }
    public byte[]? ProofOfPaymentFile { get; set; }
}
