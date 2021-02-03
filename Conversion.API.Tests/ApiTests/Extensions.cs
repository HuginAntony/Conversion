using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tournament.WebApi.Tests.ApiTests
{
    public static class Extensions
    {
        public static async Task<T> Deserialize<T>(this HttpResponseMessage newResponse)
        {
            var bytes = await newResponse.Content.ReadAsByteArrayAsync();

            return JsonSerializer.Deserialize<T>(bytes, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}