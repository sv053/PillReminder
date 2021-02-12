using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Запись на приём";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://talon.zdrav74.ru"));
        }

        public ICommand OpenWebCommand { get; }

        //void webviewNavigating(object sender, WebNavigatingEventArgs e)
        //{
        //  //  labelLoading.IsVisible = true;
        //}

        //void webviewNavigated(object sender, WebNavigatedEventArgs e)
        //{
        // //   labelLoading.IsVisible = false;
        //}
    }
}