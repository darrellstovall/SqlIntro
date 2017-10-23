using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=Adventureworks;Uid=root;Pwd=5Fingers"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
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
