using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class SimpleDB
    {
        private readonly string _connectionString;

        public SimpleDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT * from Product");
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("Delete from Product where ProductId = @id", new {id = productId});
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("Update Product Set Name = @Name Where ProductId = @id", new {id = prod.ProductId, name = prod.Name});
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("INSERT into product (Name) values (@name)", new {name = prod.Name});
            }
        }
    }
}
