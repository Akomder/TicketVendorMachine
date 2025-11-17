
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TicketVendorMachine.Models;
using TicketVendorMachine.DataAccess;
using TicketVendorMachine.Helpers; // --- MODIFIED: Added using statement for Helpers

namespace TicketVendorMachine
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private DatabaseHelper db;
        private List<Station> stations;
        private Station selectedOrigin;
        private Station selectedDestination;
        private decimal calculatedFare;
        private double distance;
        private int journeyTime;
        private string machineId = "Developed by: Akhom && Tan"; // Can be configured

        // --- MODIFIED: Added field to store report data for export ---
        private DataTable reportData;

        public MainForm()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            try
            {
                db = new DatabaseHelper();

                // Test connection
                if (!db.TestConnection())
                {
                    MessageBox.Show(
                        "Cannot connect to database. Please check:\n" +
                        "1. SQL Server is running\n" +
                        "2. Database 'TicketVendorMachine' exist\n" +
                        "3. Connection string is correct",
                        "Database Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Load stations
                LoadStations();

                // Set default values
                lblMachineId.Text = $"{machineId}";
                lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                // Hide fare details initially
                grpFareDetails.Visible = false;
                grpPayment.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Initialization error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStations()
        {
            stations = db.GetAllStations();

            // Load origin combo box
            cmbOrigin.DataSource = new List<Station>(stations);
            cmbOrigin.DisplayMember = "StationName";
            cmbOrigin.ValueMember = "StationId";
            cmbOrigin.SelectedIndex = -1;

            // Load destination combo box
            cmbDestination.DataSource = new List<Station>(stations);
            cmbDestination.DisplayMember = "StationName";
            cmbDestination.ValueMember = "StationId";
            cmbDestination.SelectedIndex = -1;
        }

        #region Purchase Tab Events

        private void btnCalculateFare_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cmbOrigin.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select origin station", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbDestination.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select destination station", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedOrigin = (Station)cmbOrigin.SelectedItem;
                selectedDestination = (Station)cmbDestination.SelectedItem;

                if (selectedOrigin.StationId == selectedDestination.StationId)
                {
                    MessageBox.Show("Origin and destination cannot be the same", "Invalid Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate fare
                calculatedFare = db.CalculateFare(selectedOrigin.StationId, selectedDestination.StationId);

                if (calculatedFare == 0)
                {
                    MessageBox.Show("Unable to calculate fare. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate route details
                var routeDetails = db.CalculateRouteDetails(selectedOrigin.StationId, selectedDestination.StationId);
                distance = routeDetails.distance;
                journeyTime = routeDetails.journeyTime;

                // Display fare details
                lblOriginStation.Text = selectedOrigin.StationName;
                lblDestStation.Text = selectedDestination.StationName;
                lblFareAmount.Text = calculatedFare.ToString("N0") + " ₫";
                lblDistance.Text = distance.ToString("N1") + " km";
                lblJourneyTime.Text = journeyTime + " minutes";

                // Get zones
                int zones = Math.Abs(selectedDestination.ZoneNumber - selectedOrigin.ZoneNumber);
                if (zones == 0) zones = 1; // Same zone
                lblZones.Text = zones == 1 ? "1 zone" : zones + " zones";

                grpFareDetails.Visible = true;
                grpPayment.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating fare: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayCreditCard_Click(object sender, EventArgs e)
        {
            ShowPaymentForm("Credit Card");
        }

        private void btnPayCash_Click(object sender, EventArgs e)
        {
            ShowPaymentForm("Cash");
        }

        private void btnPayVNPay_Click(object sender, EventArgs e)
        {
            ShowPaymentForm("QR Code - VNPay");
        }

        private void btnPayZaloPay_Click(object sender, EventArgs e)
        {
            ShowPaymentForm("QR Code - ZaloPay");
        }

        private void ShowPaymentForm(string paymentMethod)
        {
            try
            {
                // Create and show the payment form as a dialog
                // We pass the fare and method to it
                using (PaymentForm paymentDialog = new PaymentForm(paymentMethod, calculatedFare))
                {
                    this.Cursor = Cursors.Default; // Ensure cursor is normal for the dialog
                    DialogResult result = paymentDialog.ShowDialog();

                    // Check if the user "confirmed" the payment on that form
                    if (result == DialogResult.OK)
                    {
                        // If confirmed, THEN process the payment and print the ticket
                        ProcessPayment(paymentMethod);
                    }
                    // else (result == DialogResult.Cancel), do nothing. The user cancelled.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment processing error: {ex.Message}\nPlease try again or contact support.",
                    "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ProcessPayment(string paymentMethod)
        {
            try
            {
                // Show processing
                this.Cursor = Cursors.WaitCursor;

                // Create transaction
                Transaction trans = new Transaction
                {
                    TransactionCode = "TXN" + DateTime.Now.Ticks,
                    MachineId = machineId,
                    OriginStationId = selectedOrigin.StationId,
                    DestinationStationId = selectedDestination.StationId,
                    TicketType = "Single",
                    Quantity = 1,
                    FareAmount = calculatedFare,
                    Distance = distance,
                    JourneyTime = journeyTime,
                    PaymentMethod = paymentMethod,
                    PaymentStatus = "Success", // We assume OK from PaymentForm means success
                    PaymentReference = (paymentMethod == "Cash") ? "CASH_PAID" : Guid.NewGuid().ToString(),
                    CreatedDate = DateTime.Now,
                    CompletedDate = DateTime.Now
                };

                // Save transaction
                int transactionId = db.SaveTransaction(trans);

                if (transactionId > 0)
                {
                    // Create ticket
                    Ticket ticket = new Ticket
                    {
                        TicketCode = "TKT" + DateTime.Now.Ticks,
                        TransactionId = transactionId,
                        // --- MODIFIED: Call the new TicketHelper ---
                        QRCodeData = TicketHelper.GenerateQRData(trans.TransactionCode),
                        TicketType = "Single",
                        ValidFrom = DateTime.Now,
                        ValidUntil = DateTime.Now.AddHours(2),
                        Status = "Active",
                        CreatedDate = DateTime.Now
                    };

                    int ticketId = db.SaveTicket(ticket);

                    if (ticketId > 0)
                    {
                        // Show success message
                        string message =
                            "╔══════════════════════════════════════╗\n" +
                            "║       PAYMENT SUCCESSFUL! ✓          ║\n" +
                            "╚══════════════════════════════════════╝\n\n" +
                            $"Transaction ID: {trans.TransactionCode}\n" +
                            $"Ticket Code: {ticket.TicketCode}\n\n" +
                            $"From: {selectedOrigin.StationName}\n" +
                            $"To: {selectedDestination.StationName}\n" +
                            $"Fare: {calculatedFare:N0} ₫\n\n" +
                            $"Valid Until: {ticket.ValidUntil:HH:mm dd/MM/yyyy}\n" +
                            $"Payment Method: {paymentMethod}\n\n" +
                            "Please collect your ticket from the printer.\n" +
                            "Thank you for using HCMC Metro!";

                        MessageBox.Show(message, "Ticket Issued Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset form
                        ResetPurchaseForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment processing error: {ex.Message}\nPlease try again or contact support.",
                    "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- REMOVED: GenerateQRData() method was moved to TicketHelper ---

        private void ResetPurchaseForm()
        {
            cmbOrigin.SelectedIndex = -1;
            cmbDestination.SelectedIndex = -1;
            grpFareDetails.Visible = false;
            grpPayment.Visible = false;
            calculatedFare = 0;
            selectedOrigin = null;
            selectedDestination = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetPurchaseForm();
        }

        #endregion

        #region Reports Tab Events

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);

                // --- MODIFIED: Store data in the class field ---
                this.reportData = db.GetTransactionReport(fromDate, toDate, null);
                dgvReport.DataSource = this.reportData;

                // Format currency columns
                if (dgvReport.Columns["Fare (VND)"] != null)
                {
                    dgvReport.Columns["Fare (VND)"].DefaultCellStyle.Format = "N0";
                    dgvReport.Columns["Fare (VND)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Get summary
                var summary = db.GetReportSummary(fromDate, toDate, null);

                lblTotalTransactions.Text = summary["TotalTransactions"].ToString();
                lblSuccessfulTrans.Text = summary["SuccessfulTransactions"].ToString();
                lblFailedTrans.Text = summary["FailedTransactions"].ToString();
                lblTotalRevenue.Text = Convert.ToDecimal(summary["TotalRevenue"]).ToString("N0") + " ₫";
                lblTotalTickets.Text = summary["TotalTicketsSold"].ToString();

                // Calculate success rate
                int total = Convert.ToInt32(summary["TotalTransactions"]);
                int successful = Convert.ToInt32(summary["SuccessfulTransactions"]);
                double successRate = total > 0 ? (successful * 100.0 / total) : 0;
                lblSuccessRate.Text = successRate.ToString("N1") + "%";

                grpReportSummary.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                // --- MODIFIED: Check the DataTable field, not the grid ---
                if (this.reportData == null || this.reportData.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export. Please generate a report first.",
                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    FileName = $"HCMC_Metro_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportHelper.ExportDataTableToCSV(this.reportData, saveDialog.FileName);
                    MessageBox.Show("Report exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}