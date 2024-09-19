using System;
using System.Data;
using System.Data.SqlClient;

namespace BowlingSys.DBConnect.Services
{
    public class BookingService
    {
        private readonly string _connectionString;

        public BookingService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetEmployeeById(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetEmployeeById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }
    }
}
