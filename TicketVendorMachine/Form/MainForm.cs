using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using TicketVendorMachine.Models;
using TicketVendorMachine.DataAccess;

namespace TicketVendorMachine
{
    public partial class MainForm : Form
    {
        private DatabaseHelper db;
        private List<Station> stations;
        private Station selectedOrigin;
        private Station selectedDestination;
        private decimal calculatedFare;
        private double distance;
        private int journeyTime;
        private string machineId = "Develop by: Akhom && Tan"; // Can be configured

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
            ProcessPayment("Credit Card");
        }

        private void btnPayCash_Click(object sender, EventArgs e)
        {
            ProcessPayment("Cash");
        }

        private void btnPayVNPay_Click(object sender, EventArgs e)
        {
            ProcessPayment("QR Code - VNPay");
        }

        private void btnPayZaloPay_Click(object sender, EventArgs e)
        {
            ProcessPayment("QR Code - ZaloPay");
        }


        // --- MODIFIED ProcessPayment METHOD ---
        private void ProcessPayment(string paymentMethod)
        {
            try
            {
                // Show processing
                this.Cursor = Cursors.WaitCursor;

                // --- MODIFIED ---
                // Handle cash payment simulation differently
                if (paymentMethod == "Cash")
                {
                    string cashMessage = $"Please insert {calculatedFare:N0} ₫\n\n" +
                                         "(Please insert banknotes.)\n\n" +
                                         "Click OK to confirm payment, or Cancel to abort.";

                    DialogResult result = MessageBox.Show(cashMessage, "Cash Payment",
                                          MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.Cancel)
                    {
                        // User cancelled the cash payment
                        this.Cursor = Cursors.Default;
                        return; // Stop processing
                    }
                    // If user clicked OK, proceed as if payment was successful
                }
                else
                {
                    // Simulate non-cash payment processing delay
                    System.Threading.Thread.Sleep(1500);
                }
                // --- END MODIFICATION ---


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
                    PaymentStatus = "Success", // In real system, this would come from payment gateway
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
                        QRCodeData = GenerateQRData(trans.TransactionCode),
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

        private string GenerateQRData(string transactionCode)
        {
            return $"HCMC-METRO|{transactionCode}|{DateTime.Now:yyyyMMddHHmmss}";
        }

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

                // Get transaction data
                DataTable reportData = db.GetTransactionReport(fromDate, toDate, null);
                dgvReport.DataSource = reportData;

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
                if (dgvReport.Rows.Count == 0)
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
                    ExportToCSV(dgvReport, saveDialog.FileName);
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

        private void ExportToCSV(DataGridView grid, string filename)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
            {
                // Write headers
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    sw.Write(grid.Columns[i].HeaderText);
                    if (i < grid.Columns.Count - 1) sw.Write(",");
                }
                sw.WriteLine();

                // Write rows
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;

                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        sw.Write(row.Cells[i].Value?.ToString() ?? "");
                        if (i < grid.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();
                }
            }
        }





        #endregion

     
    }
}