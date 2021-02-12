using Newtonsoft.Json;
using PillReminder.Models;
using PillReminder.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
    public class RestAnswer
    {
        public string cmd { set; get; }
        public string datetime { set; get; }
        public string error { set; get; }
        public string message { set; get; }
        public int count { set; get; }
      //  public List<Term> items { set; get; } = new List<Term>();
    }

    public delegate void QueryCallback(RestAnswer answerdata);
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static string BaseUri; 
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string info = "";
        public string Info
        {
            get { return info; }
            set { SetProperty(ref info, value); }
        }

        string error = "";
        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region RestQueries

        public async Task<bool> AsyncQuery<T>(string Uri, Dictionary<string, string> queryparams, QueryCallback callback = null) where T : RestAnswer
        {
            try
            {
                var requestUri = new Uri(BaseViewModel.BaseUri);
                var request = (HttpWebRequest)WebRequest.Create(requestUri);
                StreamWriter writer = null;

                request.Timeout = 15000;
                //request.Timeout = 75000;

                T answer = default(T);

                string queryString = String.Empty;
                int index = 0;

                foreach (var postitem in queryparams)
                {
                    queryString += $"{(index > 0 ? "&" : "")}{postitem.Key}={HttpUtility.UrlEncode(postitem.Value)}";
                    index++;
                }

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = queryString.Length;

                var stream = await request.GetRequestStreamAsync();

                writer = new StreamWriter(stream);
                //byte[] paramsbytes = Encoding.ASCII.GetBytes(queryString);

                writer.Write(queryString);
                writer.Close();

                IAsyncResult Result = (IAsyncResult)request.BeginGetResponse(async (IAsyncResult result) =>
                {
                    HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;

                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                    {
                        string JsonData = await reader.ReadToEndAsync();
                        answer = JsonConvert.DeserializeObject<T>(JsonData);
                        callback?.Invoke(answer);
                    }

                    response.Close();

                }, request);

            }
            catch (WebException ex)
            {
                string s = ex.Message;
                return false;
            }


            return true;
        }


        #endregion
    }
}
