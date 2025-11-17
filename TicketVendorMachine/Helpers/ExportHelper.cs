using System.Data;
using System.IO;

namespace TicketVendorMachine.Helpers
{
    public static class ExportHelper
    {
        /// <summary>
        /// Exports a DataTable to a CSV file.
        /// </summary>
        /// <param name="dataTable">The DataTable to export.</param>
        /// <param name="filename">The full path and filename for the CSV.</param>
        public static void ExportDataTableToCSV(DataTable dataTable, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                // Write headers
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sw.Write(dataTable.Columns[i].ColumnName);
                    if (i < dataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();

                // Write rows
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        sw.Write(row[i].ToString() ?? "");
                        if (i < dataTable.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}