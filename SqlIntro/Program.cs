using System;
using System.Configuration;
using System.Linq;
using Dapper;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            
            var repo = new SimpleDB(connectionString);
            foreach (var prod in repo.GetProducts().Take(1))
            {
                Console.WriteLine(prod.ModifiedDate.ToString("dddd"));
            }

            repo.DeleteProduct(3);
           Console.WriteLine("This should have deleted line 3 from the SQL database.");

            var product = new Product()
            {
                ProductId = 316,
                Name = "Blades"
            };

            repo.UpdateProduct(product);

            Console.ReadLine();
        }

       
    }
}
