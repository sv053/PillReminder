using PillReminder.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PillReminder.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}