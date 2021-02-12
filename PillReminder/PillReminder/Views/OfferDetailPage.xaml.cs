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
    public partial class OfferDetailPage : ContentPage
    {
        OffersDetailViewModel viewModel;
        public Offer Offer { get; set; }
        public OfferDetailPage(Offer offer)
        {
            Offer = offer;
            InitializeComponent();
            //BindingContext = viewModel = new OffersDetailViewModel();
            BindingContext = this;
        }
    }
}