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
    public partial class NewsDetailPage : ContentPage
    {
        NewsViewModel viewModel;
       public News News { get; set; }
        public NewsDetailPage(News anews)
        {
            
            //   BindingContext = viewModel = new NewsViewModel(anews);
            News = anews;
            InitializeComponent();
            BindingContext = this;
        }


    }
}