using MetaCortex.DataSeeder.DTOs;
using MetaCortex.DataSeeder.Methods;

namespace MetaCortex.DataSeeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISeeder<Customer> customerSeeder = new Seeder<Customer>();
            ISeeder<Product> productSeeder = new Seeder<Product>();
            ISeeder<Order> orderSeeder = new Seeder<Order>();
            RandomizedEntities entities = new RandomizedEntities();



            while (true)
            {
                Thread.Sleep(4000);
                //customerSeeder.Seed(customer, "http://localhost:5000/customer").Wait();
                var customer = entities.RandomCustomer();
                Console.WriteLine(customer.Email);
                //productSeeder.Seed(product, "http://localhost:5000/product").Wait();
                Thread.Sleep(4000);
                var product = entities.RandomProduct();
                Console.WriteLine(product.Name);

            }
        }
    }
}
