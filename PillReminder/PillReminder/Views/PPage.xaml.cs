using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matcha.BackgroundService;
using PillReminder.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PPage : ContentPage //, IPeriodicTask
    {
    
        public PPage()
        {
            InitializeComponent();
        
        }
                   
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Pill selectedPill = (Pill)e.SelectedItem;
           
            PillPage pillPage = new PillPage();
            pillPage.BindingContext = selectedPill; 
           ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(pillPage);
             
        }
        // обработка нажатия кнопки добавления
        private async void CreatePill(object sender, EventArgs e)
        {
            Pill pill = new Pill();
            PillPage pillPage = new PillPage();
          //       NewPillPage pillPage = new NewPillPage();
            pillPage.BindingContext = pill;
            await Navigation.PushAsync(pillPage);

          //  r.Text = DBExists().ToString() + ", ";
        }

        public static bool DBExists()
        {
            string DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(DocumentPath, "friends.db");
            return File.Exists(path);
        }

        private async void removePillBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Pill pill = (Pill)button.CommandParameter;

            App.Database.DeleteItem(pill.Id);
            friendsList.ItemsSource = App.Database.GetItems();
            //await Navigation.PopAsync();
            //await this.Navigation.PushAsync(this);
        }

        //public Task<bool> StartJob()
        //{
        //    return Task.Run(() => ShowNotification());

        //}

        //private bool ShowNotification()
        //{
        //    ret.Text = "i am here!!!";

        //    return true;
        //}
    }
}