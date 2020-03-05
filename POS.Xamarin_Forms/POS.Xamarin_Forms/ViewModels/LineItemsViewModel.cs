using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using POS.Xamarin_Forms.Models;
using POS.Xamarin_Forms.Views;
using POS._Core;
using System.Linq;
using System.ComponentModel;

namespace POS.Xamarin_Forms.ViewModels
{
    public class LineItemsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<LineItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ObservableCollection<Product> Products { get; set; }
        public string Total { get => Items.Sum(i => i.Amount).ToString() + "$"; }
        public LineItemsViewModel()
        {
            Title = "Orders";
            Items = new ObservableCollection<LineItem>(LineItem.GetSampleData());
            Products = new ObservableCollection<Product>(Product.GetProducts());
            LoadItemsCommand = new Command( async () => await  ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<OrderTablePage, LineItem>(this, "AddItem", (obj, item) =>
            {
                // Check if item exists, if it does add to it if doesn't create

                var newItem = item as LineItem;
                Items.Add(newItem);
                // Not pushing to DB
            });
        }

        public void AddItem(LineItem item)
        {
            item.Id = (int) DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Items.Add(item);
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            item.Quantity = quantity;
        }

        public void RemoveItem(int id)
        {
            var itemRemove = Items.FirstOrDefault(i => i.Id == id);
            Items.Remove(itemRemove);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await Task.Delay(1000);
                Items = new ObservableCollection<LineItem>();
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