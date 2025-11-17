using System;

namespace TicketVendorMachine.Models
{
    public class PaymentResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string AuthorizationCode { get; set; }
        public string TransactionReference { get; set; }
        public string ErrorCode { get; set; }

        public static PaymentResult CreateSuccess(string authCode, string reference)
        {
            return new PaymentResult
            {
                Success = true,
                Message = "Payment processed successfully",
                AuthorizationCode = authCode,
                TransactionReference = reference
            };
        }

        public static PaymentResult CreateFailure(string errorMessage, string errorCode = null)
        {
            return new PaymentResult
            {
                Success = false,
                Message = errorMessage,
                ErrorCode = errorCode
            };
        }
    }
}