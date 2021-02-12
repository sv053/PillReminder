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
    public partial class OffersMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public OffersMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new OffersMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class OffersMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<OffersMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public OffersMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<OffersMasterDetailPageMasterMenuItem>(new[]
                {
                    new OffersMasterDetailPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new OffersMasterDetailPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new OffersMasterDetailPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new OffersMasterDetailPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new OffersMasterDetailPageMasterMenuItem { Id = 4, Title = "Page 5" },
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