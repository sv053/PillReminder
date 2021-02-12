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
    public partial class GlossariyPage : ContentPage
    {
        GlossariyDetailViewModel glossariy;
      //  Term Term;
        public GlossariyPage()
        {
            InitializeComponent();

            BindingContext = glossariy = new GlossariyDetailViewModel(new Models.Term());

         //   glossariy.LoadTermsCommand.Execute(null);
        }

      
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (glossariy.TotalTerms == 0)
            {
                glossariy.IsTermsBusy = true;
            }
        }

        private void loadBtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void termTgr_Tapped(object sender, EventArgs e)
        {
            StackLayout sen = sender as StackLayout;
            Term term = sen.Children[0].BindingContext as Term;
            string tid = term.ID;
            //   await Shell.Current.GoToAsync($"{nameof(TermDetailPage)}?{nameof(TermDetailViewModel.Id)}={tid}");
         //  await glossariy.ExecuteLoadTermCommand(tid);
            await Navigation.PushAsync(new TermDetailPage(term ));
            //   await Shell.Current.GoToAsync($"{nameof(TermDetailPage)}?{nameof(TermDetailViewModel.Ter)}={glossariy.Ter}");
        }

    }
   
}