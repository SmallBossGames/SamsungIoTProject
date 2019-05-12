using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SamsungIoTClient.Models;
using SamsungIoTClient.ViewModels;

namespace SamsungIoTClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoilerStatusListViewPage1 : ContentPage
    {

        private readonly QuickInfoViewModel viewModel;
        public BoilerStatusListViewPage1()
        {
            InitializeComponent();

            BindingContext = viewModel = new QuickInfoViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
