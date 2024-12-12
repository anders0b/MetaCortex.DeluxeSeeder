using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaCortex.DataSeeder.DTOs
{
    public class Order
    {
        public string id { get; set; }
        public DateTime orderDate { get; set; }
        public string customerId { get; set; }
        public string paymentMethod { get; set; }
        public bool isPaid { get; set; }
        public bool vIPStatus { get; set; }
        public List<OrderProduct> products { get; set; }
    }
}
