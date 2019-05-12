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
    public class WebAPIDataStore : IWebAPIDataStore
    {
        private readonly HttpClient _client;

        public WebAPIDataStore()
        {
            _client = new HttpClient();
        }

        public async Task<QuickInfo> GetQuickInfoAsync()
        {
            var uri = new Uri(Constants.quickInfoURL);
            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QuickInfo>(content);
            }
            return null;
        }

        public async Task<BoilerStatus> GetBoilerCurrentStatusAsync()
        {
            var uri = new Uri(Constants.currentBoilerStatusURL);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BoilerStatus>(content);
            }
            return null;
        }

        public async Task<RoomStatus[]> GetRoomStatus()
        {
            var uri = new Uri(Constants.currentRoomsStatusURL);
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RoomStatus[]>(content);
            }
            return new RoomStatus[0];
        }

        public async Task<RoomStatus> GetRoomStatus(int number)
        {
            var uri = new Uri(string.Format(Constants.currentRoomsStatusURL, number));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RoomStatus>(content);
            }
            return null;
        }
    }
}
