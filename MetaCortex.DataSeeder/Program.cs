using MetaCortex.DataSeeder.DTOs;
using MetaCortex.DataSeeder.EasterEgg;
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

            foreach(var line in FunnyText.IntroText())
            {
                Console.WriteLine(line);
            }
            foreach (var line in FunnyText.PantherText())
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("60% of the time, it works every time.");
            Console.WriteLine("-------------------------------------");

            while (true)
            {
                var product = entities.RandomProduct();
                Product returnProduct = await productSeeder.Seed(product, "http://ocelot-frontend:5000/products");
                Console.WriteLine($"Created product with name: {returnProduct.name}");
                await Task.Delay(1000);

                if (randomProductList.Count <= 3)
                {
                    randomProductList.Add(returnProduct);
                    Console.WriteLine($"Added product to list, new count: {randomProductList.Count}");
                }
                else
                {
                    var customer = entities.RandomCustomer();
                    Customer returnCustomer = await customerSeeder.Seed(customer, "http://ocelot-frontend:5000/customers");
                    await Task.Delay(1000);
                    Console.WriteLine($"Created customer with name: {returnCustomer.name}");

                    var order = entities.RandomOrder();
                    order.customerId = returnCustomer.id;
                    var orderProducts = ConvertToOrderProduct.Convert(randomProductList);
                    order.products = orderProducts;
                    var returnOrder = await orderSeeder.Seed(order, "http://ocelot-frontend:5000/orders");
                    Console.WriteLine($"Created order with id: {returnOrder.id}");
                    randomProductList.Clear();
                }
                await Task.Delay(4000);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Aw shit, here we go again");

            }
        }
    }
}
