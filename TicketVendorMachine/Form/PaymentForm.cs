// In file: TicketVendorMachine/Form/PaymentForm.cs

using System;
using System.Drawing;
using System.Windows.Forms;
using TicketVendorMachine.Helpers; // --- ADDED THIS ---

namespace TicketVendorMachine
{
    public partial class PaymentForm : System.Windows.Forms.Form
    {
        private string _paymentMethod;
        private decimal _fare;

        public PaymentForm(string paymentMethod, decimal fare)
        {
            InitializeComponent();
            _paymentMethod = paymentMethod;
            _fare = fare;
            this.Text = $"Process Payment: {paymentMethod}";
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblAmount.Text = _fare.ToString("N0") + " ₫";

            // --- THIS IS THE MAIN MODIFICATION ---

            // Generate a sample QR data string (in a real app, this would come from the API)
            // We use our existing TicketHelper for a consistent format.
            string qrData = TicketHelper.GenerateQRData($"PAYMENT-{DateTime.Now.Ticks}");

            switch (_paymentMethod)
            {
                case "QR Code - VNPay":
                    lblInstructions.Text = "Please scan the VNPay QR code to pay";
                    // Generate and display the real QR code
                    picQRCode.Image = QRCodeHelper.GenerateQRCode(qrData); // Use helper
                    picQRCode.BackColor = Color.White; // Reset backcolor
                    picQRCode.Visible = true;
                    break;

                case "QR Code - ZaloPay":
                    lblInstructions.Text = "Please scan the ZaloPay QR code to pay";
                    // Generate and display the real QR code
                    picQRCode.Image = QRCodeHelper.GenerateQRCode(qrData); // Use helper
                    picQRCode.BackColor = Color.White; // Reset backcolor
                    picQRCode.Visible = true;
                    break;

                case "Credit Card":
                    lblInstructions.Text = "Please tap your Credit/Debit Card\non the reader below.";
                    // A real credit card terminal would be separate hardware.
                    // We'll just show a "tap" icon simulation (or hide the QR).
                    picQRCode.Visible = false; // Hide QR for non-QR methods
                    break;

                case "Cash":
                    lblInstructions.Text = $"Please insert banknotes:\n{_fare:N0} ₫";
                    // No QR code for cash
                    picQRCode.Visible = false;
                    break;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // In a real app, this button wouldn't exist.
            // Instead, you would "poll" the payment API every 2-3 seconds
            // to ask "Has this payment been successful yet?".
            // Once the API returns "Success", you would set the DialogResult.

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // User cancelled
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}