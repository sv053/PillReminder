using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillReminder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersMasterDetailPageDetail : ContentPage
    {
        public OffersMasterDetailPageDetail()
        {
            InitializeComponent();
            BindingContext = new OffersDetailViewModel();
        }
    }
}