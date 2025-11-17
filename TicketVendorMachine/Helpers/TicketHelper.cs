
using System;

namespace TicketVendorMachine.Helpers
{
    public static class TicketHelper
    {
        /// <summary>
        /// Generates a standardized string for the QR code data.
        /// </summary>
        /// <param name="transactionCode">The unique transaction code.</param>
        /// <returns>A formatted QR data string.</returns>
        public static string GenerateQRData(string transactionCode)
        {
            return $"HCMC-METRO|{transactionCode}|{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}