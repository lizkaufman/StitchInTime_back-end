using System;
using Npgsql;
using System.Data;

namespace Stitch_BackEnd
{
    public class BaseRepository
    {
        // Generate new connection based on connection string
        private NpgsqlConnection SqlConnection()
        {
            // This builds a connection string from our separate credentials
            // FIXME: Fix TO USER SECRETS!!!
            var stringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = _config["pgHost"],
                Database = _config["pgDatabase"],
                Username = _config["pgUsername"],
                Password = _config["pgPassword"],
                Port = 5432,
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
