using System;
using System.Data;
using System.Data.SqlClient;

namespace BowlingSys.DBConnect
{
    public class DBConnect
    {
        private readonly string _connectionString;

        public DBConnect(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object SelectAndRunStoredProcedure(string StoredProcedure,string [] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(StoredProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (string parameter in parameters) {
                        command.Parameters.Add(parameter);
                        }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }
    }
}
