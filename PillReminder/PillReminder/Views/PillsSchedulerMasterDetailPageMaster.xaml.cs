using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PillReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PillsSchedulerMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public PillsSchedulerMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new PillsSchedulerMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class PillsSchedulerMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PillsSchedulerMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public PillsSchedulerMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<PillsSchedulerMasterDetailPageMasterMenuItem>(new[]
                {
                    new PillsSchedulerMasterDetailPageMasterMenuItem { Id = 0, Title = "Новость 1" },
                    new PillsSchedulerMasterDetailPageMasterMenuItem { Id = 1, Title = "Новость 2" },
                    new PillsSchedulerMasterDetailPageMasterMenuItem { Id = 2, Title = "Новость 3" },
                    new PillsSchedulerMasterDetailPageMasterMenuItem { Id = 3, Title = "Новость 4" },
                    new PillsSchedulerMasterDetailPageMasterMenuItem { Id = 4, Title = "Новость 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}