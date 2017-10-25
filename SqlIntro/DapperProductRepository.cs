using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlIntro
{
    public class DapperProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                public void GetProductsWithReview(Product prod)
                {
                    using (var conn = new MySqlConnection(_connectionString))
                    {
                        conn.Open();
                        conn.Execute("select * from product p inner join productreview pr on p.ProductId = pr.ProductID");
                    }
                }
                public void GetProductsAndReviews(Product prod)
                {
                    using (var conn = new MySqlConnection(_connectionString))
                    {
                        conn.Open();
                        conn.Execute("select * from product p left join productreview pr on p.ProductId = pr.ProductID");
                    }
                }
            }
        }
    }
}
