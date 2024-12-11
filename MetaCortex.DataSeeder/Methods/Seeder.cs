using System.Text;
using System.Text.Json;

namespace MetaCortex.DataSeeder.Methods
{
    public class Seeder<T> : ISeeder<T> where T : class
    {
        public async Task Seed(T entity, string connectionString)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(entity);
                HttpResponseMessage response = await client.PostAsync(connectionString, new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
    }
}
