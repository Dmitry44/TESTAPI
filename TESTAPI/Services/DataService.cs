using System.Text.Json;
using TESTAPI.Core;

namespace TESTAPI.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient httpClient;

        public DataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Beer>> Load(string url)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var data = await httpClient.GetFromJsonAsync<IEnumerable<Beer>>(url, jsonOptions) ?? new List<Beer>();

            return data;
        }
    }
}
