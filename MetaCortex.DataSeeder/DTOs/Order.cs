﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaCortex.DataSeeder.DTOs
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public bool VIPStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}