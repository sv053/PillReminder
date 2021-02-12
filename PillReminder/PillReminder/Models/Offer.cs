using PillReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PillReminder.Models
{
    public class Offer : RestAnswer
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string LINK { get; set; }
        public string DESCRIPTION { get; set; }
        public string ENCLOSURE { get; set; }
        public string PUBDATE { get; set; }
        public string CATEGORY { get; set; }
        public int ISACTION { get; set; }
        public int ACTIVE { get; set; }

    }
}
