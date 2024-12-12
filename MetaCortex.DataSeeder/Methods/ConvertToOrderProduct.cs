using MetaCortex.DataSeeder.DTOs;

namespace MetaCortex.DataSeeder.Methods;

public static class ConvertToOrderProduct
{
    public static List<OrderProduct> Convert(List<Product> products)
    {
        var orderProducts = new List<OrderProduct>();
        foreach (var product in products)
        {
            {
                orderProducts.Add(new OrderProduct
                {
                    Id = product.id,
                    Name = product.name,
                    Price = product.price,
                    Quantity = product.orderStock
                });
            };
        }
        return orderProducts;
    }
}
