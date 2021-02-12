using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillReminder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PillReminder.Models;
using PillReminder.ViewModels;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class PillsDetailPage : ContentPage
    {
        public Pill Pill { get; set; }
     //   public string Name { get; set; }


        public List<bool> days;
        public PillsDetailPage()
        {
            //Friend selectedFriend = (Friend)e.SelectedItem;
            //FriendPage friendPage = new FriendPage();
            //friendPage.BindingContext = selectedFriend;
            //await Navigation.PushAsync(friendPage);
        //    Name = name;
          //  Pill = new PillsList().Pills.Where(r=> r.Id == ).FirstOrDefault();
            InitializeComponent();
            BindingContext = new PillsDetailViewModel(Pill);
            days = new List<bool>();
        }
        public PillsDetailPage(Pill pi)
        {
            //Friend selectedFriend = (Friend)e.SelectedItem;
            //FriendPage friendPage = new FriendPage();
            //friendPage.BindingContext = selectedFriend;
            //await Navigation.PushAsync(friendPage);

            Pill = new PillsViewModel().Pills.Where(r => r.Name == pi.Name).FirstOrDefault();
            Pill = pi;
            InitializeComponent();
            BindingContext = new PillsDetailViewModel(Pill);
            days = new List<bool>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
            
        }

        private void mnBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void tuBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void wedBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void thuBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void frBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void satBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void suBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void saveBtn_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            changeBtnColor(button);
        }

        private void changeBtnColor(Button btn)
        {
            
            if (!(btn.BackgroundColor == Color.Red))
            {
                btn.BackgroundColor = Color.Red;
            }

            else
            {
                btn.BackgroundColor = Color.DimGray;
            }
        }
    }
}