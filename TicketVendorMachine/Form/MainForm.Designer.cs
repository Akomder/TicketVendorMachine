
namespace TicketVendorMachine
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPurchase = new System.Windows.Forms.TabPage();
            this.grpStationSelection = new System.Windows.Forms.GroupBox();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.cmbOrigin = new System.Windows.Forms.ComboBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.btnCalculateFare = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpFareDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelJourney = new System.Windows.Forms.Label();
            this.labelZone = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.lnlTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblOriginStation = new System.Windows.Forms.Label();
            this.lblDestStation = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblJourneyTime = new System.Windows.Forms.Label();
            this.lblZones = new System.Windows.Forms.Label();
            this.lblFareAmount = new System.Windows.Forms.Label();
            this.grpPayment = new System.Windows.Forms.GroupBox();
            this.btnPayCreditCard = new System.Windows.Forms.Button();
            this.btnPayCash = new System.Windows.Forms.Button();
            this.btnPayVNPay = new System.Windows.Forms.Button();
            this.btnPayZaloPay = new System.Windows.Forms.Button();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.grpReportFilters = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.grpReportSummary = new System.Windows.Forms.GroupBox();
            this.lblTotalTransactions = new System.Windows.Forms.Label();
            this.lblSuccessfulTrans = new System.Windows.Forms.Label();
            this.lblFailedTrans = new System.Windows.Forms.Label();
            this.lblSuccessRate = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalTickets = new System.Windows.Forms.Label();
            this.lblMachineId = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPurchase.SuspendLayout();
            this.grpStationSelection.SuspendLayout();
            this.grpFareDetails.SuspendLayout();
            this.grpPayment.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.grpReportFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.grpReportSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPurchase);
            this.tabControl1.Controls.Add(this.tabReports);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1176, 620);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPurchase
            // 
            this.tabPurchase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPurchase.Controls.Add(this.grpStationSelection);
            this.tabPurchase.Controls.Add(this.grpFareDetails);
            this.tabPurchase.Controls.Add(this.grpPayment);
            this.tabPurchase.Location = new System.Drawing.Point(4, 29);
            this.tabPurchase.Name = "tabPurchase";
            this.tabPurchase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPurchase.Size = new System.Drawing.Size(1168, 587);
            this.tabPurchase.TabIndex = 0;
            this.tabPurchase.Text = "Purchase Ticket";
            // 
            // grpStationSelection
            // 
            this.grpStationSelection.Controls.Add(this.lblOrigin);
            this.grpStationSelection.Controls.Add(this.cmbOrigin);
            this.grpStationSelection.Controls.Add(this.lblDestination);
            this.grpStationSelection.Controls.Add(this.cmbDestination);
            this.grpStationSelection.Controls.Add(this.btnCalculateFare);
            this.grpStationSelection.Controls.Add(this.btnReset);
            this.grpStationSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.grpStationSelection.Location = new System.Drawing.Point(20, 20);
            this.grpStationSelection.Name = "grpStationSelection";
            this.grpStationSelection.Size = new System.Drawing.Size(500, 250);
            this.grpStationSelection.TabIndex = 0;
            this.grpStationSelection.TabStop = false;
            this.grpStationSelection.Text = "Select Route";
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblOrigin.Location = new System.Drawing.Point(20, 40);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(116, 20);
            this.lblOrigin.TabIndex = 0;
            this.lblOrigin.Text = "Origin Station:";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbOrigin.FormattingEnabled = true;
            this.cmbOrigin.Location = new System.Drawing.Point(20, 65);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.Size = new System.Drawing.Size(460, 28);
            this.cmbOrigin.TabIndex = 1;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDestination.Location = new System.Drawing.Point(20, 110);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(156, 20);
            this.lblDestination.TabIndex = 2;
            this.lblDestination.Text = "Destination Station:";
            // 
            // cmbDestination
            // 
            this.cmbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(20, 135);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(460, 28);
            this.cmbDestination.TabIndex = 3;
            // 
            // btnCalculateFare
            // 
            this.btnCalculateFare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCalculateFare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculateFare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCalculateFare.ForeColor = System.Drawing.Color.White;
            this.btnCalculateFare.Location = new System.Drawing.Point(20, 185);
            this.btnCalculateFare.Name = "btnCalculateFare";
            this.btnCalculateFare.Size = new System.Drawing.Size(220, 45);
            this.btnCalculateFare.TabIndex = 4;
            this.btnCalculateFare.Text = "Calculate Fare";
            this.btnCalculateFare.UseVisualStyleBackColor = false;
            this.btnCalculateFare.Click += new System.EventHandler(this.btnCalculateFare_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(260, 185);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(220, 45);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpFareDetails
            // 
            this.grpFareDetails.Controls.Add(this.label1);
            this.grpFareDetails.Controls.Add(this.labelJourney);
            this.grpFareDetails.Controls.Add(this.labelZone);
            this.grpFareDetails.Controls.Add(this.labelDistance);
            this.grpFareDetails.Controls.Add(this.lnlTo);
            this.grpFareDetails.Controls.Add(this.lblFrom);
            this.grpFareDetails.Controls.Add(this.lblOriginStation);
            this.grpFareDetails.Controls.Add(this.lblDestStation);
            this.grpFareDetails.Controls.Add(this.lblDistance);
            this.grpFareDetails.Controls.Add(this.lblJourneyTime);
            this.grpFareDetails.Controls.Add(this.lblZones);
            this.grpFareDetails.Controls.Add(this.lblFareAmount);
            this.grpFareDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.grpFareDetails.Location = new System.Drawing.Point(550, 20);
            this.grpFareDetails.Name = "grpFareDetails";
            this.grpFareDetails.Size = new System.Drawing.Size(590, 250);
            this.grpFareDetails.TabIndex = 1;
            this.grpFareDetails.TabStop = false;
            this.grpFareDetails.Text = "Journey Details";
            this.grpFareDetails.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Total Fare:";
            // 
            // labelJourney
            // 
            this.labelJourney.AutoSize = true;
            this.labelJourney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJourney.Location = new System.Drawing.Point(313, 108);
            this.labelJourney.Name = "labelJourney";
            this.labelJourney.Size = new System.Drawing.Size(79, 22);
            this.labelJourney.TabIndex = 16;
            this.labelJourney.Text = "Journey:";
            // 
            // labelZone
            // 
            this.labelZone.AutoSize = true;
            this.labelZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZone.Location = new System.Drawing.Point(23, 138);
            this.labelZone.Name = "labelZone";
            this.labelZone.Size = new System.Drawing.Size(56, 22);
            this.labelZone.TabIndex = 15;
            this.labelZone.Text = "Zone:";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDistance.Location = new System.Drawing.Point(23, 108);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(85, 22);
            this.labelDistance.TabIndex = 14;
            this.labelDistance.Text = "Distance:";
            // 
            // lnlTo
            // 
            this.lnlTo.AutoSize = true;
            this.lnlTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlTo.Location = new System.Drawing.Point(79, 68);
            this.lnlTo.Name = "lnlTo";
            this.lnlTo.Size = new System.Drawing.Size(37, 22);
            this.lnlTo.TabIndex = 13;
            this.lnlTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(79, 36);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(56, 22);
            this.lblFrom.TabIndex = 12;
            this.lblFrom.Text = "From:";
            // 
            // lblOriginStation
            // 
            this.lblOriginStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblOriginStation.Location = new System.Drawing.Point(150, 40);
            this.lblOriginStation.Name = "lblOriginStation";
            this.lblOriginStation.Size = new System.Drawing.Size(420, 20);
            this.lblOriginStation.TabIndex = 1;
            // 
            // lblDestStation
            // 
            this.lblDestStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDestStation.Location = new System.Drawing.Point(150, 70);
            this.lblDestStation.Name = "lblDestStation";
            this.lblDestStation.Size = new System.Drawing.Size(420, 20);
            this.lblDestStation.TabIndex = 3;
            // 
            // lblDistance
            // 
            this.lblDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDistance.Location = new System.Drawing.Point(120, 110);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(100, 20);
            this.lblDistance.TabIndex = 5;
            // 
            // lblJourneyTime
            // 
            this.lblJourneyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblJourneyTime.Location = new System.Drawing.Point(390, 110);
            this.lblJourneyTime.Name = "lblJourneyTime";
            this.lblJourneyTime.Size = new System.Drawing.Size(150, 20);
            this.lblJourneyTime.TabIndex = 7;
            // 
            // lblZones
            // 
            this.lblZones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblZones.Location = new System.Drawing.Point(120, 140);
            this.lblZones.Name = "lblZones";
            this.lblZones.Size = new System.Drawing.Size(150, 20);
            this.lblZones.TabIndex = 9;
            // 
            // lblFareAmount
            // 
            this.lblFareAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblFareAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblFareAmount.Location = new System.Drawing.Point(20, 210);
            this.lblFareAmount.Name = "lblFareAmount";
            this.lblFareAmount.Size = new System.Drawing.Size(550, 30);
            this.lblFareAmount.TabIndex = 11;
            this.lblFareAmount.Text = "0 ₫";
            // 
            // grpPayment
            // 
            this.grpPayment.Controls.Add(this.btnPayCreditCard);
            this.grpPayment.Controls.Add(this.btnPayCash);
            this.grpPayment.Controls.Add(this.btnPayVNPay);
            this.grpPayment.Controls.Add(this.btnPayZaloPay);
            this.grpPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.grpPayment.Location = new System.Drawing.Point(20, 290);
            this.grpPayment.Name = "grpPayment";
            this.grpPayment.Size = new System.Drawing.Size(1120, 270);
            this.grpPayment.TabIndex = 2;
            this.grpPayment.TabStop = false;
            this.grpPayment.Text = "Select Payment Method";
            this.grpPayment.Visible = false;
            // 
            // btnPayCreditCard
            // 
            this.btnPayCreditCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPayCreditCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayCreditCard.ForeColor = System.Drawing.Color.White;
            this.btnPayCreditCard.Location = new System.Drawing.Point(30, 50);
            this.btnPayCreditCard.Name = "btnPayCreditCard";
            this.btnPayCreditCard.Size = new System.Drawing.Size(250, 180);
            this.btnPayCreditCard.TabIndex = 0;
            this.btnPayCreditCard.Text = "💳\n\nCredit Card\n\nVisa / Mastercard";
            this.btnPayCreditCard.UseVisualStyleBackColor = false;
            this.btnPayCreditCard.Click += new System.EventHandler(this.btnPayCreditCard_Click);
            // 
            // btnPayCash
            // 
            this.btnPayCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnPayCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayCash.ForeColor = System.Drawing.Color.White;
            this.btnPayCash.Location = new System.Drawing.Point(310, 50);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(250, 180);
            this.btnPayCash.TabIndex = 1;
            this.btnPayCash.Text = "💰\n\nCash\n\nClick for Payment";
            this.btnPayCash.UseVisualStyleBackColor = false;
            this.btnPayCash.Click += new System.EventHandler(this.btnPayCash_Click);
            // 
            // btnPayVNPay
            // 
            this.btnPayVNPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnPayVNPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayVNPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayVNPay.ForeColor = System.Drawing.Color.White;
            this.btnPayVNPay.Location = new System.Drawing.Point(590, 50);
            this.btnPayVNPay.Name = "btnPayVNPay";
            this.btnPayVNPay.Size = new System.Drawing.Size(250, 180);
            this.btnPayVNPay.TabIndex = 2;
            this.btnPayVNPay.Text = "💵\n\nVNPay\n\nQR Code Payment";
            this.btnPayVNPay.UseVisualStyleBackColor = false;
            this.btnPayVNPay.Click += new System.EventHandler(this.btnPayVNPay_Click);
            // 
            // btnPayZaloPay
            // 
            this.btnPayZaloPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnPayZaloPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayZaloPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayZaloPay.ForeColor = System.Drawing.Color.White;
            this.btnPayZaloPay.Location = new System.Drawing.Point(870, 50);
            this.btnPayZaloPay.Name = "btnPayZaloPay";
            this.btnPayZaloPay.Size = new System.Drawing.Size(250, 180);
            this.btnPayZaloPay.TabIndex = 3;
            this.btnPayZaloPay.Text = "💸\n\nZaloPay\n\nQR Code Payment";
            this.btnPayZaloPay.UseVisualStyleBackColor = false;
            this.btnPayZaloPay.Click += new System.EventHandler(this.btnPayZaloPay_Click);
            // 
            // tabReports
            // 
            this.tabReports.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabReports.Controls.Add(this.grpReportFilters);
            this.tabReports.Controls.Add(this.dgvReport);
            this.tabReports.Controls.Add(this.grpReportSummary);
            this.tabReports.Location = new System.Drawing.Point(4, 29);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(1168, 587);
            this.tabReports.TabIndex = 1;
            this.tabReports.Text = "Reports & Analytics";
            // 
            // grpReportFilters
            // 
            this.grpReportFilters.Controls.Add(this.label2);
            this.grpReportFilters.Controls.Add(this.labelFrom);
            this.grpReportFilters.Controls.Add(this.dtpFromDate);
            this.grpReportFilters.Controls.Add(this.dtpToDate);
            this.grpReportFilters.Controls.Add(this.btnGenerateReport);
            this.grpReportFilters.Controls.Add(this.btnExportReport);
            this.grpReportFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.grpReportFilters.Location = new System.Drawing.Point(20, 20);
            this.grpReportFilters.Name = "grpReportFilters";
            this.grpReportFilters.Size = new System.Drawing.Size(1120, 100);
            this.grpReportFilters.TabIndex = 0;
            this.grpReportFilters.TabStop = false;
            this.grpReportFilters.Text = "Report Filters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(341, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "To:";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrom.Location = new System.Drawing.Point(61, 32);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(53, 20);
            this.labelFrom.TabIndex = 6;
            this.labelFrom.Text = "From:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 30);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(150, 26);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(380, 30);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(150, 26);
            this.dtpToDate.TabIndex = 3;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(600, 25);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(200, 35);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportReport.ForeColor = System.Drawing.Color.White;
            this.btnExportReport.Location = new System.Drawing.Point(820, 25);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(200, 35);
            this.btnExportReport.TabIndex = 5;
            this.btnExportReport.Text = "Export to CSV";
            this.btnExportReport.UseVisualStyleBackColor = false;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(20, 140);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(1120, 280);
            this.dgvReport.TabIndex = 1;
            // 
            // grpReportSummary
            // 
            this.grpReportSummary.Controls.Add(this.label8);
            this.grpReportSummary.Controls.Add(this.label7);
            this.grpReportSummary.Controls.Add(this.label6);
            this.grpReportSummary.Controls.Add(this.label5);
            this.grpReportSummary.Controls.Add(this.label4);
            this.grpReportSummary.Controls.Add(this.label3);
            this.grpReportSummary.Controls.Add(this.lblTotalTransactions);
            this.grpReportSummary.Controls.Add(this.lblSuccessfulTrans);
            this.grpReportSummary.Controls.Add(this.lblFailedTrans);
            this.grpReportSummary.Controls.Add(this.lblSuccessRate);
            this.grpReportSummary.Controls.Add(this.lblTotalRevenue);
            this.grpReportSummary.Controls.Add(this.lblTotalTickets);
            this.grpReportSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.grpReportSummary.Location = new System.Drawing.Point(20, 440);
            this.grpReportSummary.Name = "grpReportSummary";
            this.grpReportSummary.Size = new System.Drawing.Size(1120, 130);
            this.grpReportSummary.TabIndex = 2;
            this.grpReportSummary.TabStop = false;
            this.grpReportSummary.Text = "Summary";
            this.grpReportSummary.Visible = false;
            // 
            // lblTotalTransactions
            // 
            this.lblTotalTransactions.Location = new System.Drawing.Point(204, 22);
            this.lblTotalTransactions.Name = "lblTotalTransactions";
            this.lblTotalTransactions.Size = new System.Drawing.Size(100, 23);
            this.lblTotalTransactions.TabIndex = 1;
            // 
            // lblSuccessfulTrans
            // 
            this.lblSuccessfulTrans.Location = new System.Drawing.Point(204, 45);
            this.lblSuccessfulTrans.Name = "lblSuccessfulTrans";
            this.lblSuccessfulTrans.Size = new System.Drawing.Size(100, 23);
            this.lblSuccessfulTrans.TabIndex = 3;
            // 
            // lblFailedTrans
            // 
            this.lblFailedTrans.Location = new System.Drawing.Point(204, 68);
            this.lblFailedTrans.Name = "lblFailedTrans";
            this.lblFailedTrans.Size = new System.Drawing.Size(100, 23);
            this.lblFailedTrans.TabIndex = 5;
            // 
            // lblSuccessRate
            // 
            this.lblSuccessRate.Location = new System.Drawing.Point(204, 91);
            this.lblSuccessRate.Name = "lblSuccessRate";
            this.lblSuccessRate.Size = new System.Drawing.Size(100, 23);
            this.lblSuccessRate.TabIndex = 7;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Location = new System.Drawing.Point(560, 25);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(100, 23);
            this.lblTotalRevenue.TabIndex = 9;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.Location = new System.Drawing.Point(560, 57);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(100, 23);
            this.lblTotalTickets.TabIndex = 11;
            // 
            // lblMachineId
            // 
            this.lblMachineId.AutoSize = true;
            this.lblMachineId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMachineId.Location = new System.Drawing.Point(12, 645);
            this.lblMachineId.Name = "lblMachineId";
            this.lblMachineId.Size = new System.Drawing.Size(245, 20);
            this.lblMachineId.TabIndex = 1;
            this.lblMachineId.Text = "Developed by: Akhom && Tan";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDateTime.Location = new System.Drawing.Point(991, 645);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(145, 20);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "dd/MM/yy HH:mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Transaction:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Success:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Failed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(149, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(441, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total Revenue:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(452, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Total Tickets:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblMachineId);
            this.Controls.Add(this.lblDateTime);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Vendor Machine";
            this.tabControl1.ResumeLayout(false);
            this.tabPurchase.ResumeLayout(false);
            this.grpStationSelection.ResumeLayout(false);
            this.grpStationSelection.PerformLayout();
            this.grpFareDetails.ResumeLayout(false);
            this.grpFareDetails.PerformLayout();
            this.grpPayment.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.grpReportFilters.ResumeLayout(false);
            this.grpReportFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.grpReportSummary.ResumeLayout(false);
            this.grpReportSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPurchase;
        private System.Windows.Forms.TabPage tabReports;

        private System.Windows.Forms.GroupBox grpStationSelection;
        private System.Windows.Forms.ComboBox cmbOrigin;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnCalculateFare;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.GroupBox grpFareDetails;
        private System.Windows.Forms.Label lblOriginStation;
        private System.Windows.Forms.Label lblDestStation;
        private System.Windows.Forms.Label lblFareAmount;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblJourneyTime;
        private System.Windows.Forms.Label lblZones;

        private System.Windows.Forms.GroupBox grpPayment;
        private System.Windows.Forms.Button btnPayCreditCard;
        private System.Windows.Forms.Button btnPayCash;
        private System.Windows.Forms.Button btnPayVNPay;
        private System.Windows.Forms.Button btnPayZaloPay;

        private System.Windows.Forms.GroupBox grpReportFilters;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExportReport;

        private System.Windows.Forms.DataGridView dgvReport;

        private System.Windows.Forms.GroupBox grpReportSummary;
        private System.Windows.Forms.Label lblTotalTransactions;
        private System.Windows.Forms.Label lblSuccessfulTrans;
        private System.Windows.Forms.Label lblFailedTrans;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalTickets;
        private System.Windows.Forms.Label lblSuccessRate;

        private System.Windows.Forms.Label lblMachineId;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lnlTo;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelJourney;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}