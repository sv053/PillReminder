using PillReminder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
    [QueryProperty(nameof(Text), nameof(Text))]
    class NewsDetailViewModel : BaseViewModel
    {
        private string newsId;
        private string text;
        private string description;
        private News news;
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

        public string NewsId
        {
            get
            {
                return newsId;
            }
            set
            {
                newsId = value;
                
            }
        }
        public News News
        {
            get
            {
                return news;
            }
            set
            {
                news = value;
                LoadItem(value);
            }
        }

        public async void LoadItem(News newss)
        {
            try
            {

            //    var item = await DataStore.GetItemAsync(itemId);
                Id = newss.ID;
                Text = newss.TITLE;
                Description = newss.DESCRIPTION;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
