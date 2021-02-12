using System;
using System.Collections.Generic;
using System.Text;
using PillReminder.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using PillReminder.Views;
using System.Linq;

namespace PillReminder.ViewModels
{
   
    public class NewsList : RestAnswer
    {
        public List<News> news { get; set; }
    }
    [QueryProperty(nameof(SelectedItemId), nameof(SelectedItemId))]
    class NewsViewModel : BaseViewModel
    {
        public ObservableCollection<News> News { get; }
        public Command  LoadNewsCommand{ get; }
        public Command LoadNewsTappedCommand { get; }
        private News _selectedItem;
        private string selectedItemId;
        private bool newsTapped;
        bool _IsNewsBusy;
        private int totalNews = 0;
        private News news;
        private int newscount = 0;
        

        public string SelectedItemId
        {
            get { return selectedItemId; }
            set { 
                SetProperty(ref selectedItemId, value);
                aNews = News.Where(c => c.ID == value).First();
            }
        }
        public int TotalNews
        {
            get { return totalNews; }
            set { SetProperty(ref totalNews, value); }
        }
        public bool NewsTapped
        {
            get { return newsTapped; }
            set { SetProperty(ref newsTapped, value); }
        }
        public bool IsNewsBusy
        {
            get { return _IsNewsBusy; }
            set { SetProperty(ref _IsNewsBusy, value); }
        }

        public News aNews
        {
            get
            {
                return news;
            }
            set
            {
                SetProperty(ref news, value);
                //    PutData(value);
                //  LoadNewsTappedCommand.Execute(value);
                OnItemSelected(value);
            }
        }
       
        public Command<News> ItemTapped { get; }
        public NewsViewModel()
        {
            News = new ObservableCollection<News>();
            IsNewsBusy = false;
            LoadNewsCommand = new Command(async () => await ExecuteLoadNewsCommand());
            LoadNewsTappedCommand = new Command(async () => await ExecuteLoadNewsTappedCommand());
        }

        public NewsViewModel(News anews)
        {
            aNews = anews;
            IsNewsBusy = false;
         }
        //public News SelectedItem
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        SetProperty(ref _selectedItem, value);
        //        OnItemSelected(value);
        //    }
        //}
        async void OnItemSelected(News news)
        {
            if (news == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsDetailViewModel.News)}={news}");
        }
        async Task ExecuteLoadNewsCommand()
        {
            try
            {
                News.Clear();
                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "news"},
                   // { "id", Ofr.ID.ToString()},
                };

                await AsyncQuery<NewsList>("", queryparams, (RestAnswer answer) =>
                {
                    var ans = (answer as NewsList);

                    if (ans != null && ans.news != null)
                    {
                        foreach (var item in ans.news) News.Add(item);
                    }
                    
                    TotalNews = News.Count;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsNewsBusy = false;
                LoadNewsTappedCommand.Execute(null);
            }
        }
        
            async Task ExecuteLoadNewsTappedCommand()
            {
            //   await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsDetailViewModel.News)}={news}");
            try
            {

                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "news"},
                    { "id", news.ID.ToString()},
                };

                await AsyncQuery<News>("", queryparams, (RestAnswer answer) =>
                {
                    var ans = (answer as News);

                    if (ans != null)
                    {
                        aNews = ans;
                    }

                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                // IsNewsBusy = false;
            }
        }
    }
}
