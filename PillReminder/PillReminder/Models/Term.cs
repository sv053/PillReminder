using System;
using System.Collections.Generic;
using System.Text;
using PillReminder.ViewModels;

namespace PillReminder.Models
{
   public class Term : RestAnswer // : Item
    {
      public string ID { get; set; }
      public string TITLE { get; set; }
      public string DESCRIPTION { get; set; }
   //   public string ACTIVE { get; set; }
    }
}
