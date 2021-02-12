using Matcha.BackgroundService;
using PillReminder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PillReminder.Services
{
    class PeriodicCall : IPeriodicTask
    {
        ObservableCollection<Pill> pills;
        public PeriodicCall(int seconds)
        {
            pills = new ObservableCollection<Pill>();

            App.notificationManager = DependencyService.Get<INotificationManager>();
            App.notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
             //   ShowNotification(evtData.Title, evtData.Message);
             //   ShowNote(evtData.Title, evtData.Message);
            };
           Interval = TimeSpan.FromSeconds(seconds);
        }

        public TimeSpan Interval { get; set; }

        //public Task StartJob()
        //{
       
        //}

        Task<bool> IPeriodicTask.StartJob()=>( Task.Run(() => ShowNote()));
        
        bool ShowNote()
        {
          //  App.notificationManager.SendNotification("check", "ahora", DateTime.Now);
            var pillsFromDb = App.Database.GetItems();
            
            foreach (var p in pillsFromDb)
            {
                if (p.toRemind)
                {
                    if ((p.Monday && DateTime.Now.DayOfWeek == DayOfWeek.Monday) || (p.Tuesday && DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) ||
                        (p.Wednesday && DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) || (p.Thursday && DateTime.Now.DayOfWeek == DayOfWeek.Thursday) ||
                           (p.Friday && DateTime.Now.DayOfWeek == DayOfWeek.Friday) || (p.Saturday && DateTime.Now.DayOfWeek == DayOfWeek.Saturday) ||
                           (p.Sunday && DateTime.Now.DayOfWeek == DayOfWeek.Sunday))
                    {
                        var dt = new DateTime(1970, 1, 1) + p.TimeToTakePill;
                        if (dt.Minute == DateTime.Now.Minute && dt.Hour == DateTime.Now.Hour)
                          App.notificationManager.SendNotification("Пора принимать " + p.Name, "время приёма - " + p.TimeToTakePill.ToString(), DateTime.Now.AddSeconds(5));
                    }
                }
            }
          return true; //return false when you want to stop or trigger only once
         //   return false;
        }
       
    }
}
