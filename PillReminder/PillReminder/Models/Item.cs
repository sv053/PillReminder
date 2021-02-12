using System;
using PillReminder.ViewModels;

namespace PillReminder.Models
{
    public class Item : RestAnswer
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }

    }
}