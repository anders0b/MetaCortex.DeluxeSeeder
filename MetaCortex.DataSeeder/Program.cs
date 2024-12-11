using MetaCortex.DataSeeder.DTOs;
using MetaCortex.DataSeeder.Methods;

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
                var returnCustomer = await customerSeeder.Seed(customer, "http://ocelot-frontend:5000/customers");
                await Task.Delay(1000);
                Console.WriteLine(returnCustomer.Email, returnCustomer.Id);

                await Task.Delay(1000);

                var product = entities.RandomProduct();
                var returnProduct = await productSeeder.Seed(product, "http://ocelot-frontend:5000/products");
                await Task.Delay(1000);
                Console.WriteLine(returnProduct.Name, returnProduct.Id);

                if (randomProductList.Count <= 3)
                {
                    randomProductList.Add(returnProduct);
                    Console.WriteLine(randomProductList.Count);
                }
                else
                {
                    var order = entities.RandomOrder();
                    order.CustomerId = returnCustomer.Id;
                    order.Products = randomProductList;
                    await orderSeeder.Seed(order, "http://ocelot-frontend:5000/orders");
                    Console.WriteLine(order.Id);
                    randomProductList.Clear();
                }
                await Task.Delay(4000);

            }
        }
    }
}
