using MetaCortex.DataSeeder.DTOs;

namespace MetaCortex.DataSeeder.Methods
{
    public class RandomizedEntities
    {
        public Customer RandomCustomer()
        {
            string[] firstNames = { "Anders", "Gabriel", "Jesper", "Olle", "Erik", "Johan", "Magnus", "Ingrid", "Johanna", "Linda", "Birgitta", "Sofia", "Sven" };
            string[] LastNames = { "Öberg", "Raimondo", "Heimbrand", "Whendin", "Eriksson", "Larsson", "Olsson", "Persson", "Svensson", "Gustafsson" }; 
            Random random = new Random();
            var customer = new Customer
            {
                name = $"{firstNames[random.Next(firstNames.Length)]} {LastNames[random.Next(LastNames.Length)]}",
                email = "",
                isVip = new Random().Next(0, 2) == 1,
                allowNotifications = new Random().Next(0, 2) == 1
            };
            var emailWithDot = customer.name.Replace(" ", ".").ToLower();
            customer.email = $"{emailWithDot}.{new Random().Next(1, 9999)}@metacortex.se";
            return customer;
        }
        public Product RandomProduct()
        {
            string[] adjectives = { "Super", "Eco", "Smart", "Compact", "Powerful", "Sleek", "Cool", "Modern", "Interesting", "Yellow", "Green", "Expensive", "Cheap" };
            string[] nouns = { "Widget", "Gadget", "Tool", "Device", "Machine", "System", "Trinket", "Entity", "Hole", "Microprocessor", "Doodad" };
            Random random = new Random();

            var product = new Product
            {
                name = $"{adjectives[random.Next(adjectives.Length)]} {nouns[random.Next(nouns.Length)]}",
                price = new Random().Next(1, 9999),
                orderStock = new Random().Next(1, 9999)
            };
            return product;
        }
        public Order RandomOrder()
        {
            string[] paymentMethods = { "Swish", "Klarna", "CreditCard", "Stripe" };
            Random random = new Random();

            var order = new Order
            {
                orderDate = DateTime.Now,
                customerId = string.Empty,
                paymentMethod = $"{paymentMethods[random.Next(paymentMethods.Length)]}",
                isPaid = false,
                vIPStatus = false,
                products = new List<OrderProduct>()
            };
            return order;
        }
    }
}
