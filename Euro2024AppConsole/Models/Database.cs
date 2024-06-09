using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Euro2024AppConsole.Models
{
    public class Database
    {
        public string connectionString;
        
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
