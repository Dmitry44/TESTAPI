using System.Text.Json;
using TESTAPI.Core;

namespace TESTAPI.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient httpClient;
        private readonly Dictionary<string, (IEnumerable<Beer> data, DateTime expiredAt)> cache = new();

        public DataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Beer>> Load(string url)
        {
            if (cache.TryGetValue(url, out var result))
            {
                if (DateTime.Now < result.expiredAt) return result.data;
                else cache.Remove(url);
            }

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var res = await httpClient.GetFromJsonAsync<IEnumerable<Beer>>(url, jsonOptions);
            if (res is not null)
            {
                cache.Add(url, (res, DateTime.Now.AddMinutes(5)));
                return res;
            }

            return new List<Beer>();
        }
    }
}
