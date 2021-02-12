using PillReminder.Models;
using PillReminder.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    public partial class AboutPage : ContentPage
    {
        public string AppName
        {
            get
            {
                var app = (Application.Current as PillReminder.App);
                return app.AppName;
            }
        }
        public AboutPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

          
        }
    }
}