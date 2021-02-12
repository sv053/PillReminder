using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PillReminder.Models;
using PillReminder.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PillReminder.ViewModels
{
    class OffersViewModel : BaseOfferViewModel
    {
        private Offer _selectedOffer;
        public ObservableCollection<Offer> Offers { get; }
        public Command LoadOffersCommand { get; }
                    
          public Command<Offer> OfferTapped { get; }

            public OffersViewModel()
            {
                
                Title = "Акции";
                Offers = new ObservableCollection<Offer>();
                LoadOffersCommand = new Command(async () => await ExecuteLoadItemsCommand());

                OfferTapped = new Command<Offer>(OnItemSelected);

              
            }

            async Task ExecuteLoadItemsCommand()
            {
                IsItBusy = true;

                try
                {
                    Offers.Clear();
                    var offers = await DataOfferStore.GetOfferAsync(true);
                    foreach (var offer in offers)
                    {
                        Offers.Add(offer);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsItBusy = false;
                }
            }

            public void OnAppearing()
            {
                IsItBusy = true;
                SelectedOffer = null;
            }

            public Offer SelectedOffer
            {
                get => _selectedOffer;
                set
                {
                    SetProperty(ref _selectedOffer, value);
                    OnItemSelected(value);
                }
            }

            //private async void OnAddItem(object obj)
            //{
            //    await Shell.Current.GoToAsync(nameof(NewItemPage));
            //}

            async void OnItemSelected(Offer offer)
            {
                if (offer == null)
                    return;

                // This will push the ItemDetailPage onto the navigation stack
             //   await Shell.Current.GoToAsync($"{nameof(OfferDetailPage)}?{nameof(OffersDetailViewModel.OfferId)}={offer.Id}");
            }
        }
    }




