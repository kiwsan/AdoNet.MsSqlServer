using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class DatabaseContext : IDatabaseContext
    {

        private readonly string _connectionString;
        private SqlConnection _connection;

        public DatabaseContext()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connectionString = @"Data Source=KIWSAN\MSSQLSERVER2017;Initial Catalog=SampleDatabase;Integrated Security=True";
        }

        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }

    }
}
