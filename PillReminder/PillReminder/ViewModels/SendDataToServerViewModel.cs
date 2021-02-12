using PillReminder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
    class SendDataToServerViewModel : BaseViewModel
    {
        public Command SendDataCommand { get; }
        public Command SendQuestionCommand { get; }

        public SendDataToServerViewModel()
        {
            SendQuestionCommand = new Command(async (q) => await ExecuteSendQuestionCommand(q));
        }

        async Task ExecuteSendQuestionCommand(object q)
        {
            try
            {
               Question question = q as Question;
               var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "userquestion"},
                    { "email", question?.Email},
                    { "question", question?.QuestionMessage},
                };
               await AsyncQuery<Question>("", queryparams, (RestAnswer answer) =>
                {
                    var ans = (answer as Question);

                    if (ans != null)
                    {

                    }

                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                
            }
        }
       
    }
}
