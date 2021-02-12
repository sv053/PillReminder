using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PillReminder.Models;
using System.Linq;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    class PillsDetailViewModel : PillBaseViewModel
    {
        public PillsDetailViewModel()
        {
                
        }

        public PillsDetailViewModel(Pill pill)
        {
            Pill = pill;
        }
     //   private string pillId;
        private string text;
        private string name;
        private string id;
        private Pill pill;

        public Pill Pill
        {
            get
            {
                return pill;
            }
            set
            {
                
                 pill = value;
            //    pill = new Pill() { Name = "test5", Text = "sometext5", Id = 5 };
                 SetProperty(ref pill, value);
               //     LoadPillId(value);
            }
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                LoadPillId(value);
            }
        }

        public async void LoadPillId(string pilid)
        {
            try
            {
               // var pill = await DataStore.GetItemAsync(pillId);
                   var pill = new PillsList().Pills.Where(p => p.Id.ToString() == pilid).FirstOrDefault();
                Pill = pill;
           //     Id = pill.Id.ToString();
                Name = pill.Name;
                Text = pill.EndDate.Date.ToString();
    
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Pill");
            }
        }
    }
}
