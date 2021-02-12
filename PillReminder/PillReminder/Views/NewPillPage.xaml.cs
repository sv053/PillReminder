using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillReminder.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PillReminder.Services;
using Matcha.BackgroundService;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPillPage : ContentPage
    {
        public List<DateTime> TimesOfDay { get; set; }
        public List<string> Units { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; } = DateTime.Now.Hour;
        private static int id = 1;
        public Command SavePillCommand { get; set; }
        public NewPillPage()
        {
            InitializeComponent();
            BindingContext = this;

          //  Units = new List<string>() { "штука", "миллилитр", "грамм", "таблетка", "капля" };
            TimesOfDay = new List<DateTime>();
            SavePillCommand = new Command(async () => await SavePillToDatabase());

            App.notificationManager = DependencyService.Get<INotificationManager>();
            App.notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };

        }

        public class PeriodicWebCall : IPeriodicTask
        {
            public PeriodicWebCall(int seconds)
            {
                Interval = TimeSpan.FromSeconds(seconds);
            }

            public TimeSpan Interval { get; set; }

            public Task StartJob()
            {
                // YOUR CODE HERE
                // THIS CODE WILL BE EXECUTE EVERY INTERVAL

                //  

                Device.BeginInvokeOnMainThread(() =>
                {
                    var msg = new Label()
                    {
                        Text = $"bla-blaMessage: "
                    };

                   // sl.Children.Add(msg);
                });
                
                return RemindAboutPill();

            }

            Task<bool> IPeriodicTask.StartJob()
            {
                throw new NotImplementedException();
            }
        }

        private static async Task RemindAboutPill()
        {


        }
            private async Task SavePillToDatabase()
        {

            //   var pill = (Pill)BindingContext;
            Pill pill = new Pill()
            {
                //   Id = Guid.NewGuid().ToString()
                Id = id++,
                Text = pillName.Text,
                Time = pillRemindTime.Time.ToString(),
                Monday = monChBox.IsChecked,
                Tuesday = tusChBox.IsChecked,
                Wednesday = wedChBox.IsChecked,
                Thursday = thuChBox.IsChecked,
                Friday = friChBox.IsChecked,
                Saturday = satChBox.IsChecked,
                Sunday = sunChBox.IsChecked,
                TimeToTakePill = pillRemindTime.Time,
                toRemind = remindCheckBox.IsChecked


                //    Wednesday
            };
 
            App.Database.SaveItem(pill);

            
         //   resMsg.Text = "сохранено в списке";

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");

            //   pillName.Text = "";
            //    pillRemindTime.Time 
            //   if (!String.IsNullOrEmpty(friend.Name))
            //  this.Navigation.PopAsync();
           

        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                
                sl.Children.Add(msg);
            });
        }
        private void DeletePill(object sender, EventArgs e)
        {
            var pill = (Pill)BindingContext;
            App.Database.DeleteItem(pill.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //  Pill pill = new Pill()
            //  {
            //      //   Id = Guid.NewGuid().ToString()
            //      Id = id++,
            //      Text = pillName.Text,
            //      Description = pillRemindTime.Time.ToString()
            //  };

            //  resMsg.Text = DBExists().ToString()+", ";
            //  resMsg.Text += Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            //  App.Database.SaveItem(pill);

            ////  App.Database.ge
            //  resMsg.Text += "pill-" + pill.Id + " " + pill.Name;
            //  //   resMsg.Text = "сохранено в списке";
            //  App.Database.SaveItem(pill);
            App.notificationNumber++;
            //string title = $"Local Notification #{App.notificationNumber}";
            //string message = $"You have now received {App.notificationNumber} notifications!";
            string title = $"Local Notification #{App.notificationNumber}";
            string message = "You have now received notifications!";
            App.notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10000));
        }
        public static bool DBExists()
            {
                string DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(DocumentPath, "pills.db");
                return File.Exists(path);
            }

        private void SaveFriend(object sender, EventArgs e)
        {
            var pill = (Pill)BindingContext;
            if (!String.IsNullOrEmpty(pill.Name))
            {
                App.Database.SaveItem(pill);

                App.notificationNumber++;
                string title = $"Local Notification #{App.notificationNumber}";
                string message = $"You have now received {App.notificationNumber} notifications!";
                App.notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
                //    notificate(pill.Name, pill.timeOfDay);
                //      OnScheduleClick("its time for", pill.Name);
                // OnScheduleClick;
            }
          //  this.Navigation.PopAsync();
        }

        void OnSendClick(object sender, EventArgs e)
        {
            App.notificationNumber++;
            string title = $"Local Notification #{App.notificationNumber}";
            string message = $"You have now received {App.notificationNumber} notifications!";
            App.notificationManager.SendNotification(title, message);
        }

        void OnScheduleClick(object sender, EventArgs e)
        {
            App.notificationNumber++;
            string title = $"Local Notification #{App.notificationNumber}";
            string message = $"You have now received {App.notificationNumber} notifications!";
            App.notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
        }

        //private void notificate(string noteText, DateTime dt)
        //{
        //    App.notificationNumber++;
        //    string title = $"Local Notification #{App.notificationNumber}";
        //    string message = $"You have now received {App.notificationNumber} notifications!";
        //    App.notificationManager.SendNotification("time for", noteText);
        //}
        private void DeleteFriend(object sender, EventArgs e)
        {
            var pill = (Pill)BindingContext;
            App.Database.DeleteItem(pill.Id);
            this.Navigation.PopAsync();
        }

    }
}