﻿using Microsoft.AspNetCore.Mvc.Abstractions;
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
            Console.WriteLine(_connectionString);
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            using var command = new NpgsqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            await using var reader = await command.ExecuteReaderAsync();



            var results = new List<Dictionary<string, object>>();
            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }
                results.Add(row);
            }

            return results; 
        }

        public async Task<object> SelectAndRunFunction(string functionName, NpgsqlParameter[] parameters)
        {
            Console.WriteLine(_connectionString);
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var connection = await dataSource.OpenConnectionAsync();
            await using var transaction = await connection.BeginTransactionAsync();

            using var command = new NpgsqlCommand(functionName, connection)
            {
                CommandType = CommandType.Text,
            };

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            await using var reader = await command.ExecuteReaderAsync();

            var results = new List<Dictionary<string, object>>();
            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.GetValue(i);
                }
                results.Add(row);
            }

            return results;
        }



    }
}
