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
                var returnCustomer = await customerSeeder.Seed(customer, "http://ocelot-frontend:5000/customer");
                Console.WriteLine(customer.Email);

                await Task.Delay(1000);

                var product = entities.RandomProduct();
                Console.WriteLine(product.Name);
                var returnProduct = await productSeeder.Seed(product, "http://ocelot-frontend:5000/products");

                if(randomProductList.Count < 4)
                {
                    randomProductList.Add(returnProduct);
                    Console.WriteLine(randomProductList.Count);
                }
                else if(randomProductList.Count == 3)
                {
                    var order = entities.RandomOrder();
                    order.CustomerId = returnCustomer.Id;
                    order.Products = randomProductList;
                    var returnOrder = await orderSeeder.Seed(order, "http://ocelot-frontend:5000/orders");
                    Console.WriteLine(order.Id);
                }
                else
                {
                    randomProductList.Clear();
                }
                await Task.Delay(4000);

            }
        }
    }
}
