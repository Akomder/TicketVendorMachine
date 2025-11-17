// ============================================
// File: Models/Station.cs
// ============================================
using System;

namespace TicketVendorMachine.Models
{
    public class Station
    {
        public int StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string StationNameVI { get; set; }
        public int ZoneNumber { get; set; }
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{StationName} - {StationNameVI}";
        }

        public string GetDisplayName(string language = "EN")
        {
            return language == "VI" ? StationNameVI : StationName;
        }
    }
}
