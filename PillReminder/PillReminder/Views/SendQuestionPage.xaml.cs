using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillReminder.Models;
using PillReminder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendQuestionPage : ContentPage
    {
        public SendQuestionPage()
        {
            InitializeComponent();
        }

        private void sendQuestion_Clicked(object sender, EventArgs e)
        {
            string email = "";string question = "";
            email = emailEntry.Text;
            question = questionText.Text;

            if ((email != "") && (question != ""))
            {
                SendDataToServerViewModel sendDataToServerViewModel = new SendDataToServerViewModel();
                sendDataToServerViewModel.SendQuestionCommand.Execute(new Question() { Email = email, QuestionMessage = question });
                sendReslutLbl.Text = "Ваш вопрос отправлен.";
                emailEntry.Text = "";
                questionText.Text = "";

                Device.StartTimer(TimeSpan.FromSeconds(3), HideTextTimer);
            }
            else
            {
                sendReslutLbl.Text = "Оба поля не должны быть пустыми.";
            }
        }

        private bool HideTextTimer()
        {
            sendReslutLbl.Text = "";
            return false;
        }
    }
}