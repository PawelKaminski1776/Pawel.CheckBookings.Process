using Microsoft.AspNetCore.Mvc.Abstractions;
using Npgsql;
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

        public async Task<object> SelectAndRunStoredProcedure(string storedProcedure, NpgsqlParameter[] parameters)
        {
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            using var command = new NpgsqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            await using var reader = await command.ExecuteReaderAsync();

            var results = new List<object>();
            while (await reader.ReadAsync())
            {
                results.Add(reader[0]); 
            }

            return results; 
        }


    }
}
