using POS._Core;
using POS.Core;
using POS.Xamarin_Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POS.Xamarin_Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderTablePage : ContentPage
    {
        LineItemsViewModel viewModel;
        public List<LineItem> Items { get; set; }
        public List<Product> Products{ get; set; }
        public Manager StateManager { get; set; }
        public Product SelectedProduct { get; set; }
        public int SelectedItemId = 1;
        public int Quantity { get; set; }
        public OrderTablePage()
        {
            InitializeComponent();
            Items = LineItem.GetSampleData();
            BindingContext = viewModel = new LineItemsViewModel();
        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var id = (sender as Element);
            int quantity;
            if(int.TryParse(e.NewTextValue, out quantity))
                if(SelectedItemId != 0)
            viewModel.UpdateQuantity(SelectedItemId, quantity);
        }

        private void ItemRemove(object sender, EventArgs e)
        {
            viewModel.RemoveItem(SelectedItemId);
            SelectedItemId = 0;
        }

        private void ProductSelected(object sender, EventArgs e)
        {
            var productIndex = (sender as Picker).SelectedIndex + 1;
            SelectedProduct = viewModel.Products.FirstOrDefault(p => p.Id == productIndex);
        }

        private void AddNewQuantityChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(e.NewTextValue, out int quantity);
            if(quantity != 0)
            Quantity = quantity;
        }

        private void AddNew(object sender, EventArgs e)
        {
            if(SelectedProduct != null)
            {
                var item = new LineItem(0).Create(SelectedProduct, Quantity);
                viewModel.AddItem(item);
            }            
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedItemId = (e.SelectedItem as LineItem).Id;
        }

        private async void Cashout(object sender, EventArgs e)
        {
            await DisplayAlert("Payup", "Please pay " + viewModel.Total, "OK");
        }
    }
}