using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillReminder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PillReminder.Models;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersPage : ContentPage
    {
       OfferViewModel _viewModel;
        public OffersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new OfferViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _viewModel.OnAppearing();
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.IsOffersBusy = true;
        }

        private async void tgrOffer_Tapped(object sender, EventArgs e)
        {
            StackLayout sen = sender as StackLayout;
            var offer = sen.Children[0].BindingContext as Offer;
            await Navigation.PushAsync(new OfferDetailPage(offer));
        }
    }
}