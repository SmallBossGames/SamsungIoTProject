using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using SamsungIoTClient.Models;
using SamsungIoTClient.Views;
using Shared.Models;
using Xamarin.Forms;

namespace SamsungIoTClient.ViewModels
{
    class RoomStatusViewModel : BaseViewModel
    {
        public ObservableCollection<RoomStatusItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private readonly Random random;

        public RoomStatusViewModel()
        {
            random = new Random();
            Title = "Faggot";
            Items = new ObservableCollection<RoomStatusItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                /*var items = new RoomStatus[5];
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = new RoomStatus
                    {
                        RoomNumber = random.Next(1, 6),
                        AirHumidity = (float)(random.NextDouble() * 100),
                        Id = 1488,
                        Temperature = (float)(random.NextDouble() * 100),
                        UpdateTime = DateTime.Now,
                        UserId = ""
                    };
                }*/

                var items = await WebAPIDataStore.GetRoomStatus();
                
                foreach (var item in items)
                {
                    Items.Add(new RoomStatusItem
                    {
                        RoomName = $"Комната {item.RoomNumber}",
                        Humidity = $"{item.AirHumidity}%",
                        Temperature = $"{item.Temperature}°C"
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
