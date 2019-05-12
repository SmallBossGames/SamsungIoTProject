using SamsungIoTClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SamsungIoTClient.ViewModels
{
    class QuickInfoViewModel:BaseViewModel
    {
        public ObservableCollection<QuickInfoItem> Items { get; }
        public Command LoadItemsCommand { get; set; }

        public QuickInfoViewModel()
        {
            Title = "Общая информация";
            Items = new ObservableCollection<QuickInfoItem>();
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

                var item = await WebAPIDataStore.GetQuickInfoAsync();

                if(item==null)
                {
                    return;
                }

                Items.Add(new QuickInfoItem
                {
                    Name = "Средняя температура",
                    Value = $"{item.AvgTemperature} °С"
                });

                Items.Add(new QuickInfoItem
                {
                    Name = "Средняя влажность",
                    Value = $"{item.AvgHumidity}%"
                });

                Items.Add(new QuickInfoItem
                {
                    Name = "Утечка газа",
                    Value = item.LeakOfGasStatus ? "есть" : "нет",
                });

                Items.Add(new QuickInfoItem
                {
                    Name = "Температура теплоносителя",
                    Value = $"{item.HeatCarrierTemperature} °С"
                });
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
