using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matcha.BackgroundService;
using PillReminder.Models;
using PillReminder.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PillPage : ContentPage //, IPeriodicTask
    {
      
        public PillPage()
        {

            InitializeComponent();

            //App.notificationManager = DependencyService.Get<INotificationManager>();
            //App.notificationManager.NotificationReceived += (sender, eventArgs) =>
            //    {
            //        var evtData = (NotificationEventArgs)eventArgs;
            //        ShowNotification(evtData.Title, evtData.Message);
            //    };

         //   PeriodicWebCallTest(seconds)
             
        }
        private void SaveFriend(object sender1, EventArgs e)
        {
            var pill = (Pill)BindingContext;

            //if (pill.TimeToTakePill == null) 
            //    pill.Date =  DateTime.Now;
            // pill.TimeToTakePill = new DateTime(1970, 1, 1) + DateTime.Now;
            if (!String.IsNullOrEmpty(pill.Name))
            {
                App.Database.SaveItem(pill);
            }
            sl.Children.Add(new Label() { Text = pill.Name });
               this.Navigation.PopAsync();

            App.notificationNumber++;
            //string title = $"Пора принять {App.notificationNumber}";
            //string message = $"You have now received {App.notificationNumber} notifications!";
            // App.notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
          
            //string title = $"Пора принять {pill.Name}";
            //string message = $"Будьте здоровы!";
            //App.notificationManager.SendNotification(title, message, new DateTime(1970, 1, 1) + pill.TimeToTakePill);



        }

        //void ShowNotification(string title, string message)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        var msg = new Label()
        //        {
        //            Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
        //        };

        //        sl.Children.Add(msg);
        //    });
        //}
        private void DeleteFriend(object sender, EventArgs e)
        {
            var pill = (Pill)BindingContext;
            App.Database.DeleteItem(pill.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        //public Task<bool> StartJob()
        //{
        //  return  Task.Run(()=> ShowNotification());

        //  //  return true;
        //}

        // bool ShowNotification()
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        var msg = new Label()
        //        {
        //            Text = $"Notification Received:\nTitle: MISS ME \nMessage: "
        //        };

        //        sl.Children.Add(msg);
        //    });
        //    return true;
        //}
    }
}