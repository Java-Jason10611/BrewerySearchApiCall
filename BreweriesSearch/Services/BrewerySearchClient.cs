using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BreweriesSearch.Services
{
    public class BrewerySearchClient : IBrewerySearchClient
    {
        private readonly HttpClient _client;
        public BrewerySearchClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<BrewerySearchResponse> GetBreweryInfo(string theRest = "breweries")
        {
            var results = await _client.GetAsync($"/{theRest}");
            if (results.IsSuccessStatusCode)
            {
                var stringContent = await results.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var obj = JsonSerializer.Deserialize<BrewerySearchResponse>(stringContent, options);
                return obj;
            }
            else
            {
                throw new HttpRequestException("No brews for yous");
            }
        
        }

    }
}
