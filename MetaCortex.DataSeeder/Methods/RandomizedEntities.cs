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
            var customer = new Customer
            {
                Name = "John Dog",
                Email = $"john.dog{new Random().Next(1, 9999)}@test.se",
                IsVip = new Random().Next(0, 2) == 1,
                AllowNotifications = true
            };
            return customer;
        }
        public Product RandomProduct()
        {
            string[] adjectives = { "Super", "Eco", "Smart", "Compact", "Powerful", "Sleek" };
            string[] nouns = { "Widget", "Gadget", "Tool", "Device", "Machine", "System" };
            Random random = new Random();

            var product = new Product
            {
                Name = $"{adjectives[random.Next(adjectives.Length)]} {nouns[random.Next(nouns.Length)]}",
                Price = new Random().Next(1, 9999),
                OrderStock = new Random().Next(1, 9999)
            };
            return product;
        }
    }
}
