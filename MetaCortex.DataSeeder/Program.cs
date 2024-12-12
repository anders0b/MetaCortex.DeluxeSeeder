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
            Console.WriteLine("LET THE SEEDING COMMENCE");
            Console.WriteLine("--------------------------");

            while (true)
            {
                var customer = entities.RandomCustomer();
                Customer returnCustomer = await customerSeeder.Seed(customer, "http://ocelot-frontend:5000/customers");
                await Task.Delay(1000);
                Console.WriteLine($"Created customer with name: {returnCustomer.name}");

                await Task.Delay(1000);

                var product = entities.RandomProduct();
                Product returnProduct = await productSeeder.Seed(product, "http://ocelot-frontend:5000/products");
                Console.WriteLine($"Created customer with name: {returnProduct.name}");
                await Task.Delay(1000);
                Console.WriteLine(returnProduct);

                if (randomProductList.Count <= 3)
                {
                    randomProductList.Add(returnProduct);
                    Console.WriteLine($"Added product to list, new count: {randomProductList.Count}");
                }
                else
                {
                    var order = entities.RandomOrder();
                    order.customerId = returnCustomer.id;
                    var orderProducts = ConvertToOrderProduct.Convert(randomProductList);
                    order.products = orderProducts;
                    var returnOrder = await orderSeeder.Seed(order, "http://ocelot-frontend:5000/orders");
                    Console.WriteLine($"Created order with id: {returnOrder.id}");
                    randomProductList.Clear();
                }
                await Task.Delay(4000);
                Console.WriteLine("Aw shit, here we go again");

            }
        }
    }
}
