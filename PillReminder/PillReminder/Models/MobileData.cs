using PillReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillReminder.Models
{
   public class MobileData : RestAnswer
    {
        public string Os { set; get; }
        public string SoftVersion { set; get; }
        public string UserDomain { set; get; }

    }
}
