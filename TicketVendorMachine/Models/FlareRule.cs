using System;

namespace TicketVendorMachine.Models
{
    public class FareRule
    {
        public int FareRuleId { get; set; }
        public int ZoneFrom { get; set; }
        public int ZoneTo { get; set; }
        public decimal BaseFare { get; set; }
        public decimal PerKmRate { get; set; }
        public string TicketType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
