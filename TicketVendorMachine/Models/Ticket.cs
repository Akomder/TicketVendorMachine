// ============================================
// File: Models/Ticket.cs
// ============================================
using System;

namespace TicketVendorMachine.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketCode { get; set; }
        public int TransactionId { get; set; }
        public string QRCodeData { get; set; }
        public string TicketType { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Status { get; set; }
        public DateTime? UsedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsValid()
        {
            return Status == "Active" &&
                   DateTime.Now >= ValidFrom &&
                   DateTime.Now <= ValidUntil;
        }

        public string GetValidityStatus()
        {
            if (Status != "Active") return "Used/Expired";
            if (DateTime.Now < ValidFrom) return "Not Yet Valid";
            if (DateTime.Now > ValidUntil) return "Expired";
            return "Valid";
        }
    }
}
