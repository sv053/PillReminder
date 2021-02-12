using PillReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillReminder.Models
{
   public class ColorSettings : RestAnswer
    {
      //  public Color BkgColor { get; set; }
        public string bkgcolor { get; set; }
        public string barcolor { get; set; }
        public string apptitle { get; set; }

    }
}
