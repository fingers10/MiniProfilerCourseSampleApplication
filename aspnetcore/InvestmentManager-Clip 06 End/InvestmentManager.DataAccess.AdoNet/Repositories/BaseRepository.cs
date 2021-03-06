﻿using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System;
using System.Data;
using System.Data.SqlClient;


namespace InvestmentManager.DataAccess.AdoNet.Repositories
{
    internal class BaseRepository 
    {

        public BaseRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        protected String _connectionString;

        protected IDbConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            var wrapperConnection = 
                new ProfiledDbConnection(sqlConnection, MiniProfiler.Current);

            return wrapperConnection;
        }

    }
}
