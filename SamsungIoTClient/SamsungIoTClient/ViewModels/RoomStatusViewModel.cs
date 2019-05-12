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

        public RoomStatusViewModel()
        {
            Title = "Комнаты";
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
