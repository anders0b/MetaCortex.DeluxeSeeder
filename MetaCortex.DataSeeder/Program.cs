using MetaCortex.DataSeeder.DTOs;
using MetaCortex.DataSeeder.Methods;
using System.Text.Json;

namespace MetaCortex.DataSeeder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ISeeder<Customer> customerSeeder = new Seeder<Customer>();
            ISeeder<Product> productSeeder = new Seeder<Product>();
            ISeeder<Order> orderSeeder = new Seeder<Order>();

            RandomizedEntities entities = new RandomizedEntities();

            var randomProductList = new List<Product>();

            while (true)
            {
                var customer = entities.RandomCustomer();
                Customer returnCustomer = await customerSeeder.Seed(customer, "http://localhost:5000/customers");
                await Task.Delay(1000);
                Console.WriteLine(returnCustomer);

                await Task.Delay(1000);

                var product = entities.RandomProduct();
                Product returnProduct = await productSeeder.Seed(product, "http://localhost:5000/products");
                await Task.Delay(1000);
                Console.WriteLine(returnProduct);

                if (randomProductList.Count <= 3)
                {
                    randomProductList.Add(returnProduct);
                    Console.WriteLine(randomProductList.Count);
                }
                else
                {
                    var order = entities.RandomOrder();
                    order.customerId = returnCustomer.id;
                    order.products = randomProductList;
                    await orderSeeder.Seed(order, "http://localhost:5000/orders");
                    Console.WriteLine(order.id);
                    randomProductList.Clear();
                }
                await Task.Delay(4000);

            }
        }
    }
}
