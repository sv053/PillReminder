using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using PillReminder.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using PillReminder.Views;

namespace PillReminder.ViewModels
{
    class PillsViewModel : PillBaseViewModel
    {
        private Pill _selectedPill;

        public ObservableCollection<Pill> Pills { get; }
        public Command LoadPillsCommand { get; }
     //   public Command AddItemCommand { get; }
        public Command<Pill> PillTapped { get; }
        public Command AddItemCommand { get; }
        public string Te { get; set; } = "Ret";

        public PillsViewModel()
        {
            Title = "Расписание приёма лекарств";
            Pills = new ObservableCollection<Pill>();
            LoadPillsCommand = new Command(async () => await ExecuteLoadPillsCommand());
            AddItemCommand = new Command(OnAddItem);
            PillTapped = new Command<Pill>(OnPillSelected);

            
         //   AddItemCommand = new Command(OnAddItem);
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPillPage));
        }
        async Task ExecuteLoadPillsCommand()
        {
            IsBusy = true;
            Te = "ExecuteLoadPillsCommand";
            try
            {
                Pills.Clear();
                //    = await DataStore.GetItemsAsync(true);
                var pills = App.Database.GetItems();

                //var pills = new PillsList().Pills;

                foreach (var pill in pills)
                {
                    Pills.Add(pill);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPill = null;

        }

        public Pill SelectedPill
        {
            get => _selectedPill;
            set
            {
                Te = "SelectedPill";
                SetProperty(ref _selectedPill, value);
                OnPillSelected(value);
            }
        }


        async void OnPillSelected(Pill pill)
        {

            if (pill == null)
                return;
            Te = "pill.Name" + pill.Id;
            // This will push the ItemDetailPage onto the navigation stack
          
              await Shell.Current.GoToAsync($"{nameof(PillsDetailPage)}?{nameof(PillsDetailViewModel.Pill.Id)}={pill.Id}");
        //    await Shell.Current.GoToAsync($"{nameof(PillsDetailPage)}?{nameof(PillsDetailViewModel.Pill)}={pill}");
          //   await Navigation.PushAsync(new PillsDetailPage(pill));
        }
    }
}
