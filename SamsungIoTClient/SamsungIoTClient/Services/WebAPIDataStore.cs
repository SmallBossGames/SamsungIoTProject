using SamsungIoTClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
using Shared.Utilities;
using Newtonsoft.Json;

namespace SamsungIoTClient.Services
{
    class WebAPIDataStore
    {
        HttpClient _client;

        public WebAPIDataStore()
        {
            _client = new HttpClient();
        }

        public async Task<BoilerStatus> GetBoilerStatusAsync()
        {
            var uri = new Uri(Constants.boilerStatusGetURI);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BoilerStatus>(content);
            }
            return new BoilerStatus();
        }
    }
}
