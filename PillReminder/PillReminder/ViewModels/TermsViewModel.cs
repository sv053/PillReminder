using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PillReminder.ViewModels
{
    public class TermsViewModel : BaseViewModel
    {
        public ObservableCollection<TermsList> Terms { get; set; }

        //Terms = new ObservableCollection<TermsList>();
        //    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
    }
}
