using PillReminder.Models;
using PillReminder.ViewModels;
using PillReminder.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PillReminder
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage),  typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage),     typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PillsPage), typeof(PillsPage));
            Routing.RegisterRoute(nameof(PillsDetailPage), typeof( PillsDetailPage));
         //   Routing.RegisterRoute(nameof(PillsSchedulerMasterDetailPageDetail), typeof(PillsSchedulerMasterDetailPageDetail));
         //   Routing.RegisterRoute(nameof(PillsSchedulerMasterDetailPageMasterMenuItem), typeof( PillsSchedulerMasterDetailPageMasterMenuItem));
            Routing.RegisterRoute(nameof(GlossariyPage), typeof(GlossariyPage));
            Routing.RegisterRoute(nameof(OffersPage), typeof(OffersPage));
            Routing.RegisterRoute(nameof(NewPillPage), typeof(NewPillPage));
            Routing.RegisterRoute(nameof(SendQuestionPage), typeof(SendQuestionPage));
            Routing.RegisterRoute(nameof(NewsPage), typeof(NewsPage));
            Routing.RegisterRoute(nameof(MakeAppointmentPage), typeof(MakeAppointmentPage));
            Routing.RegisterRoute(nameof(TermDetailPage), typeof(TermDetailPage));
            Routing.RegisterRoute(nameof(NewsDetailPage), typeof(NewsDetailPage));
            Routing.RegisterRoute(nameof(OfferDetailPage), typeof(OfferDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
