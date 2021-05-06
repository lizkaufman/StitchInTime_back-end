using System;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Stitch_BackEnd
{
    public class BaseRepository
    {
        IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Generate new connection based on connection string
        private NpgsqlConnection SqlConnection()
        {
            // This builds a connection string from our separate credentials
            var stringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = _configuration["pgHost"],
                Database = _configuration["pgDatabase"],
                Username = _configuration["pgUsername"],
                Password = _configuration["pgPassword"],
                Port = int.Parse(_configuration["pgPort"]),
                SslMode = Npgsql.SslMode.Require, // Heroku Specific Setting
                TrustServerCertificate = true // Heroku Specific Setting
            };



            return new NpgsqlConnection(stringBuilder.ConnectionString);
        }

        // Open new connection and return it for use
        public IDbConnection CreateConnection()
        {
            var connection = SqlConnection();
            connection.Open();
            return connection;
        }

    }
}
