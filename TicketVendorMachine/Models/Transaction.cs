// ============================================
// File: Models/Transaction.cs
// ============================================
using System;

namespace TicketVendorMachine.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionCode { get; set; }
        public string MachineId { get; set; }
        public int OriginStationId { get; set; }
        public int DestinationStationId { get; set; }
        public string TicketType { get; set; }
        public int Quantity { get; set; }
        public decimal FareAmount { get; set; }
        public double? Distance { get; set; }
        public int? JourneyTime { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentReference { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        // Navigation properties
        public Station OriginStation { get; set; }
        public Station DestinationStation { get; set; }
    }
}