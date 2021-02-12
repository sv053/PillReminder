using PillReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillReminder.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PillsPage : ContentPage
    {
        PillsViewModel _viewModel;
        public PillsPage()
        {
            InitializeComponent();
         //   BindingContext = _viewModel = new PillsViewModel();
         //   BindingContext = this;
        }

        protected override void OnAppearing()
        {
            var v = App.Database.GetItems();

            PillsListView.ItemsSource = v;
            //if (_viewModel.Pills.Count > 0)
            //    PillsListView.ItemsSource = _viewModel.Pills;
            //else
            //    PillsListView.ItemsSource = new PillsList().Pills;

            base.OnAppearing();
         //   _viewModel.OnAppearing();
            
            
           
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

        private async void addNewPillBtn_Clicked(object sender, EventArgs e)
        {
            Pill pill = new Pill();
            NewPillPage newPillPage = new NewPillPage();
            newPillPage.BindingContext = pill;
              await Navigation.PushAsync(newPillPage);

          //  await Shell.Current.GoToAsync($"{nameof(NewPillPage)}");
        }

        private void removePillBtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void editPillBtn_Clicked(object sender, EventArgs e)
        {
         //   Button button = sender as Button;
            var tmp = e;
            // await Navigation.PushAsync(new PillsDetailPage());
            
           //     StackLayout sen = sender as StackLayout;
            //    var news = sen.Children[0].BindingContext as News;
                await Navigation.PushAsync(new PillsDetailPage(new Pill() {Name = "check" }));
                //  string tid = term.ID;
                //     await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsViewModel.aNews.ID)}={news.ID}");
                //  await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsViewModel.aNews.ID)}={news.ID}");
                //  await Shell.Current.GoToAsync($"{nameof(())};

                //   await glossariy.ExecuteLoadTermCommand(tid);

            
        }

        private void editPillBtn_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void CreatePill(object sender, EventArgs e)
        {
            Pill pill = new Pill();
            NewPillPage pillPage = new NewPillPage();
            pillPage.BindingContext = pill;
            await Navigation.PushAsync(pillPage);

        }
    }
}