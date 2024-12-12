using MetaCortex.DataSeeder.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaCortex.DataSeeder.Methods
{
    public class RandomizedEntities
    {
        public Customer RandomCustomer()
        {
            string[] adjectives = { "Super", "Eco", "Smart", "Compact", "Powerful", "Sleek", "Cool", "Modern", "Interesting", "Yellow", "Green", "Expensive", "Cheap" };
            Random random = new Random();
            var customer = new Customer
            {
                name = $"{adjectives[random.Next(adjectives.Length)]} John",
                email = $"john.dog{new Random().Next(1, 9999)}@test.se",
                isVip = new Random().Next(0, 2) == 1,
                allowNotifications = true
            };
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
