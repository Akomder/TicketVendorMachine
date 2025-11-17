using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TicketVendorMachine.Models;

namespace TicketVendorMachine.DataAccess
{
    public class DatabaseHelper
    {
        private readonly string _connectionString = "Server=localhost;Database=TicketVendorMachineDB;Integrated Security=true;";

        /// <summary>
        /// Test the database connection
        /// </summary>
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get all stations from the database
        /// </summary>
        public List<Station> GetAllStations()
        {
            List<Station> stations = new List<Station>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT StationId, StationCode, StationName, StationNameVI, ZoneNumber, OrderIndex, IsActive FROM Stations ORDER BY OrderIndex";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                stations.Add(new Station
                                {
                                    StationId = (int)reader["StationId"],
                                    StationCode = reader["StationCode"].ToString(),
                                    StationName = reader["StationName"].ToString(),
                                    StationNameVI = reader["StationNameVI"].ToString(),
                                    ZoneNumber = (int)reader["ZoneNumber"],
                                    OrderIndex = (int)reader["OrderIndex"],
                                    IsActive = (bool)reader["IsActive"]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading stations: {ex.Message}");
            }

            return stations;
        }

        /// <summary>
        /// Calculate fare between two stations
        /// </summary>
        public decimal CalculateFare(int originStationId, int destinationStationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 1 Fare 
                        FROM FareRules 
                        WHERE (OriginStationId = @OriginId AND DestinationStationId = @DestId)
                           OR (OriginStationId = @DestId AND DestinationStationId = @OriginId)
                        ORDER BY Fare";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OriginId", originStationId);
                        cmd.Parameters.AddWithValue("@DestId", destinationStationId);
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error calculating fare: {ex.Message}");
            }

            return 0;
        }

        /// <summary>
        /// Calculate route details (distance and journey time)
        /// </summary>
        public (double distance, int journeyTime) CalculateRouteDetails(int originStationId, int destinationStationId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 1 Distance, JourneyTime 
                        FROM FareRules 
                        WHERE (OriginStationId = @OriginId AND DestinationStationId = @DestId)
                           OR (OriginStationId = @DestId AND DestinationStationId = @OriginId)";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OriginId", originStationId);
                        cmd.Parameters.AddWithValue("@DestId", destinationStationId);
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double distance = reader["Distance"] != DBNull.Value ? Convert.ToDouble(reader["Distance"]) : 0;
                                int journeyTime = reader["JourneyTime"] != DBNull.Value ? Convert.ToInt32(reader["JourneyTime"]) : 0;
                                return (distance, journeyTime);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error calculating route details: {ex.Message}");
            }

            return (0, 0);
        }

        /// <summary>
        /// Save transaction to the database
        /// </summary>
        public int SaveTransaction(Transaction transaction)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Transactions 
                        (TransactionCode, MachineId, OriginStationId, DestinationStationId, TicketType, Quantity, 
                         FareAmount, Distance, JourneyTime, PaymentMethod, PaymentStatus, PaymentReference, 
                         ErrorMessage, CreatedDate, CompletedDate)
                        VALUES 
                        (@TransCode, @MachineId, @OriginId, @DestId, @TicketType, @Qty, 
                         @Fare, @Distance, @JourneyTime, @PaymentMethod, @PaymentStatus, @PaymentRef, 
                         @ErrorMsg, @CreatedDate, @CompletedDate);
                        SELECT SCOPE_IDENTITY();";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TransCode", transaction.TransactionCode);
                        cmd.Parameters.AddWithValue("@MachineId", transaction.MachineId);
                        cmd.Parameters.AddWithValue("@OriginId", transaction.OriginStationId);
                        cmd.Parameters.AddWithValue("@DestId", transaction.DestinationStationId);
                        cmd.Parameters.AddWithValue("@TicketType", transaction.TicketType);
                        cmd.Parameters.AddWithValue("@Qty", transaction.Quantity);
                        cmd.Parameters.AddWithValue("@Fare", transaction.FareAmount);
                        cmd.Parameters.AddWithValue("@Distance", transaction.Distance ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@JourneyTime", transaction.JourneyTime ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PaymentMethod", transaction.PaymentMethod);
                        cmd.Parameters.AddWithValue("@PaymentStatus", transaction.PaymentStatus);
                        cmd.Parameters.AddWithValue("@PaymentRef", transaction.PaymentReference ?? "");
                        cmd.Parameters.AddWithValue("@ErrorMsg", transaction.ErrorMessage ?? "");
                        cmd.Parameters.AddWithValue("@CreatedDate", transaction.CreatedDate);
                        cmd.Parameters.AddWithValue("@CompletedDate", transaction.CompletedDate ?? (object)DBNull.Value);
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving transaction: {ex.Message}");
            }

            return 0;
        }

        /// <summary>
        /// Save ticket to the database
        /// </summary>
        public int SaveTicket(Ticket ticket)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Tickets 
                        (TicketCode, TransactionId, QRCodeData, TicketType, ValidFrom, ValidUntil, Status, UsedDate, CreatedDate)
                        VALUES 
                        (@TicketCode, @TransId, @QRCode, @TicketType, @ValidFrom, @ValidUntil, @Status, @UsedDate, @CreatedDate);
                        SELECT SCOPE_IDENTITY();";
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TicketCode", ticket.TicketCode);
                        cmd.Parameters.AddWithValue("@TransId", ticket.TransactionId);
                        cmd.Parameters.AddWithValue("@QRCode", ticket.QRCodeData ?? "");
                        cmd.Parameters.AddWithValue("@TicketType", ticket.TicketType);
                        cmd.Parameters.AddWithValue("@ValidFrom", ticket.ValidFrom);
                        cmd.Parameters.AddWithValue("@ValidUntil", ticket.ValidUntil);
                        cmd.Parameters.AddWithValue("@Status", ticket.Status);
                        cmd.Parameters.AddWithValue("@UsedDate", ticket.UsedDate ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CreatedDate", ticket.CreatedDate);
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving ticket: {ex.Message}");
            }

            return 0;
        }

        /// <summary>
        /// Get transaction report for a date range
        /// </summary>
        public DataTable GetTransactionReport(DateTime fromDate, DateTime toDate, string machineId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            TransactionCode,
                            MachineId,
                            os.StationName AS [Origin Station],
                            ds.StationName AS [Destination Station],
                            PaymentMethod,
                            PaymentStatus,
                            FareAmount AS [Fare (VND)],
                            Distance,
                            JourneyTime,
                            CreatedDate
                        FROM Transactions t
                        LEFT JOIN Stations os ON t.OriginStationId = os.StationId
                        LEFT JOIN Stations ds ON t.DestinationStationId = ds.StationId
                        WHERE CreatedDate BETWEEN @FromDate AND @ToDate";

                    if (!string.IsNullOrEmpty(machineId))
                    {
                        query += " AND MachineId = @MachineId";
                    }

                    query += " ORDER BY CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);
                        if (!string.IsNullOrEmpty(machineId))
                        {
                            cmd.Parameters.AddWithValue("@MachineId", machineId);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting transaction report: {ex.Message}");
            }

            return dataTable;
        }

        /// <summary>
        /// Get report summary for a date range
        /// </summary>
        public Dictionary<string, object> GetReportSummary(DateTime fromDate, DateTime toDate, string machineId)
        {
            Dictionary<string, object> summary = new Dictionary<string, object>
            {
                { "TotalTransactions", 0 },
                { "SuccessfulTransactions", 0 },
                { "FailedTransactions", 0 },
                { "TotalRevenue", 0m },
                { "TotalTicketsSold", 0 }
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            COUNT(*) AS TotalTransactions,
                            SUM(CASE WHEN PaymentStatus = 'Success' THEN 1 ELSE 0 END) AS SuccessfulTransactions,
                            SUM(CASE WHEN PaymentStatus = 'Failed' THEN 1 ELSE 0 END) AS FailedTransactions,
                            SUM(CASE WHEN PaymentStatus = 'Success' THEN FareAmount ELSE 0 END) AS TotalRevenue
                        FROM Transactions
                        WHERE CreatedDate BETWEEN @FromDate AND @ToDate";

                    if (!string.IsNullOrEmpty(machineId))
                    {
                        query += " AND MachineId = @MachineId";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);
                        if (!string.IsNullOrEmpty(machineId))
                        {
                            cmd.Parameters.AddWithValue("@MachineId", machineId);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                summary["TotalTransactions"] = reader["TotalTransactions"] != DBNull.Value ? Convert.ToInt32(reader["TotalTransactions"]) : 0;
                                summary["SuccessfulTransactions"] = reader["SuccessfulTransactions"] != DBNull.Value ? Convert.ToInt32(reader["SuccessfulTransactions"]) : 0;
                                summary["FailedTransactions"] = reader["FailedTransactions"] != DBNull.Value ? Convert.ToInt32(reader["FailedTransactions"]) : 0;
                                summary["TotalRevenue"] = reader["TotalRevenue"] != DBNull.Value ? Convert.ToDecimal(reader["TotalRevenue"]) : 0m;
                            }
                        }
                    }
                }

                // Get ticket count
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Tickets t
                        INNER JOIN Transactions tr ON t.TransactionId = tr.TransactionId
                        WHERE tr.CreatedDate BETWEEN @FromDate AND @ToDate
                        AND tr.PaymentStatus = 'Success'";

                    if (!string.IsNullOrEmpty(machineId))
                    {
                        query += " AND tr.MachineId = @MachineId";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);
                        if (!string.IsNullOrEmpty(machineId))
                        {
                            cmd.Parameters.AddWithValue("@MachineId", machineId);
                        }

                        object result = cmd.ExecuteScalar();
                        summary["TotalTicketsSold"] = result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting report summary: {ex.Message}");
            }

            return summary;
        }
    }
}
