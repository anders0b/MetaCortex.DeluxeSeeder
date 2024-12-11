
namespace MetaCortex.DataSeeder.DTOs
{
    public class Customer
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsVip { get; set; }
        public bool AllowNotifications { get; set; }

    }
}
