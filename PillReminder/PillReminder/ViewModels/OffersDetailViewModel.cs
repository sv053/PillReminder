using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using PillReminder.Models;

namespace PillReminder.ViewModels
{
    [QueryProperty(nameof(OfferId), nameof(OfferId))]
    class OffersDetailViewModel : BaseViewModel
    {
        private string offerId;
        private string text;
        private string description;
        private Offer offer;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string OfferId
        {
            get
            {
                return offerId;
            }
            set
            {
                offerId = value;
                LoadItemId(value);
            }
        }
        public Offer Offer
        {
            get
            {
                return offer;
            }
            set
            {
                offer = value;
                
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
