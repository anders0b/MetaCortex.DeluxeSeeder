using System.Text;
using System.Text.Json;

namespace MetaCortex.DataSeeder.Methods
{
    public class Seeder<T> : ISeeder<T> where T : class
    {
        public async Task<T> Seed(T entity, string connectionString)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonSerializer.Serialize(entity);
                var response = await client.PostAsync(connectionString, new StringContent(json, Encoding.UTF8, "application/json"));
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseString)!; //never null if API-projects are working
            }
        }
    }
}
