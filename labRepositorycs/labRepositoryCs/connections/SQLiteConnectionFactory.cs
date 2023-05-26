using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Npgsql;

namespace labRepositoryCs.connections
{
    public class SQLiteConnectionFactory:ConnectionFactory
    {
        public override IDbConnection createConnection(IDictionary<string, string> props)
        {
            String connectionString = "Data Source=musicfestival.db;Version=3";
            return new SQLiteConnection(connectionString);
        }
    }
}