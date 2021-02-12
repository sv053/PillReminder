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
   
    public partial class TermDetailPage : ContentPage
    {
        GlossariyDetailViewModel viewModel;
        public Term Term { get; set; } 
        public TermDetailPage(Term term)
        {
            Term = term;
         //   Title = term?.TITLE;
            InitializeComponent();
            BindingContext = viewModel = new GlossariyDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadTermCommand.Execute(Term.ID);
        }

    }
}