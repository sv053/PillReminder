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
    public partial class NewsPage : ContentPage
    {
        NewsViewModel viewModel;
        
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NewsViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.IsNewsBusy = true;
        }

        private void btnInvis_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Text = "переход на сайт";
            var par = button.Parent.BindingContext;


        }

        private async void tgrNews_Tapped(object sender, EventArgs e)
        {
            StackLayout sen = sender as StackLayout;
            var news = sen.Children[0].BindingContext as News;
            await Navigation.PushAsync(new NewsDetailPage(news));
          //  string tid = term.ID;
          //     await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsViewModel.aNews.ID)}={news.ID}");
          //  await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsViewModel.aNews.ID)}={news.ID}");
          //  await Shell.Current.GoToAsync($"{nameof(())};
            
            //   await glossariy.ExecuteLoadTermCommand(tid);

        }
    }
}