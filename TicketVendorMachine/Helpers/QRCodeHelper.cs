
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace TicketVendorMachine.Helpers
{
    public static class QRCodeHelper
    {
        /// <summary>
        /// Generates a QR code image from a text string.
        /// </summary>
        /// <param name="text">The text to encode in the QR code.</param>
        /// <returns>A Bitmap image of the QR code.</returns>
        public static Bitmap GenerateQRCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // The '20' is the pixel-per-module size. Adjust as needed.
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }
        public static void SaveAsPng(Bitmap qrCodeImage, string filePath)
        {
            qrCodeImage.Save(filePath, ImageFormat.Png);
        }
    }
}