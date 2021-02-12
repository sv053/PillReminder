using PillReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillReminder.Models
{
   public class Question : RestAnswer
    {
        public string message { set; get; }
        public string Email { set; get; }
        public string QuestionMessage { set; get; }
    }
}
