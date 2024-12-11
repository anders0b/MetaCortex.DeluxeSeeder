
namespace MetaCortex.DataSeeder.DTOs
{
    public class Customer
    {
        public string id { get; set; }
        public string name { get; set; } = default!;
        public string email { get; set; } = default!;
        public bool isVip { get; set; }
        public bool allowNotifications { get; set; }

    }
}
