using System;
using System.Collections.Generic;
using System.Text;

namespace PillReminder.Services
{
    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
