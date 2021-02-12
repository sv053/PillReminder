using PillReminder.Services;
using PillReminder.ViewModels;
using PillReminder.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PillReminder.Models;
using Matcha.BackgroundService;
using static PillReminder.Views.NewPillPage;

namespace PillReminder
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "pills.db";
        public static PillsRepository database;

      
        public static PillsRepository Database
        {
            get
            {
                if (database == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    database = new PillsRepository(path);
                }
                return database;
            }
        }

        public static INotificationManager notificationManager;
        public static int notificationNumber = 0;

        public string AppName { get; set; }

        public App()
        {
            InitializeComponent();

            BaseViewModel.BaseUri = "https://mp.xn--d1achwgkbn7a.xn--p1ai/restapi";
            // Use the dependency service to get a platform-specific implementation and initialize it.
            //  DependencyService.Get<INotificationManager>().Initialize();

            DependencyService.Get<INotificationManager>().Initialize();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            //BaseViewModel.Cabinet = 0;
            //BaseViewModel.Patient = 0;


            DependencyService.Register<MockDataStore>();

            MessagingCenter.Subscribe<BaseViewModel>(
          this, // кто подписывается на сообщения
          "ErrorMessage",   // название сообщения
          async (sender) =>
          {
              ShowError((sender as BaseViewModel).Error);
          });


            MessagingCenter.Subscribe<BaseViewModel>(
           this, // кто подписывается на сообщения
           "InfoMessage",   // название сообщения
           async (sender) =>
           {
               ShowInfo((sender as BaseViewModel).Info);
           });
        }
        public void ShowError(string error)
        {
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                if (this.MainPage != null)
                {
                    await this.MainPage.DisplayAlert("Ошибка", error, "Ok");
                }
            });
        }

        public void ShowInfo(string info)
        {
            Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                if (this.MainPage != null)
                {
                    await this.MainPage.DisplayAlert("Сообщение", info, "Ok");
                }
            });
        }
        protected override void OnStart()
        {
            //    ColorStyleViewModel colors = new ColorStyleViewModel();
            //Register Periodic Tasks
            BackgroundAggregatorService.Add(() => new PeriodicCall(60));
            //   BackgroundAggregatorService.Add(() => new PeriodicCall2(4));

            //Start the background service
            BackgroundAggregatorService.StartBackgroundService();

            ColorStyleViewModel colors = new ColorStyleViewModel();

            MessagingCenter.Subscribe<ColorStyleViewModel>(
            this, // кто подписывается на сообщения
            "UploadColors",   // название сообщения
            async (sender) =>
            {
                //AppName = colors.ColorSet.apptitle;
                Device.BeginInvokeOnMainThread(() =>
                {
                    var app = (Application.Current as PillReminder.App);
                    app.MainPage.Resources["BackgroundColor"] = Color.FromHex(colors.ColorSet.bkgcolor);
                    app.MainPage.Resources["HeaderColor"] = Color.FromHex(colors.ColorSet.barcolor);
                });
            });

            colors.SendMobileDataCommand.Execute(null);
        }

        protected override void OnSleep()
        {
         //   BackgroundAggregatorService.StopBackgroundService();
        }

        protected override void OnResume()
        {
        }
    }
}
