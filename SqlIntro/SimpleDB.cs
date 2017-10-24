using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class SimpleDB
    {
        private readonly string _connectionString;

        public SimpleDB(string connectionString);
        {
            _connectionString = DbConnectionStringBuilder;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Query<Product>();
            }
        }
    }
}
