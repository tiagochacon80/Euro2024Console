using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euro2024AppConsole.Models;
using MySql.Data.MySqlClient;

namespace Euro2024AppConsole.Data
{
    public class Database
    {
        public readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

    }        
}
