using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PillReminder.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using PillReminder.Views;

namespace PillReminder.ViewModels
{
   
    public class TermsList : RestAnswer
    {
        public List<Term> items { get; set; } 
    }
   public class GlossariyDetailViewModel : BaseViewModel
    {
        private int termscount = 0;
        bool _IsTermsBusy ;
        public bool IsTermsBusy
        {
            get { return _IsTermsBusy; }
            set { SetProperty(ref _IsTermsBusy, value); }
        }

        public int TotalTerms
        {
            get
            {
                return Terms.Count;
            }
        }

        public ObservableCollection<Term> Terms { set; get; }
        private Term term; 
        public Command LoadTermsCommand { get; }
        public Command LoadTermCommand { get; }
        public Term Ter
        {
            get
            {
                return term;
            }
            set
            {
                SetProperty(ref term, value);
                //    PutData(value);
            }
        }
        public GlossariyDetailViewModel(Term term = null)
        {
            IsTermsBusy = false;
            Ter = null;
            Title = term?.TITLE;
            
            LoadTermsCommand = new Command(async () => await ExecuteLoadTermsCommand());
            LoadTermCommand = new Command(async (cmdparam) => await ExecuteLoadTermCommand(cmdparam));
            //  Term.Title = "check";
            Terms = new ObservableCollection<Term>();

             //Terms.Add(new Term() { Title = "Заболевание", Name = "сокращение", Description = "подробное описание", Text = "определение термина", Id = "шг" });
            //Terms.Add(new Term() { Title = "Заболевание", Name = "сокращение", Description = "подробное описание", Text = "определение термина", Id = "шг" });
            //Terms.Add(new Term() { Title = "Заболевание", Name = "сокращение", Description = "подробное описание", Text = "определение термина", Id = "шг" });
        }
     //   public GlossariyDetailViewModel()
     //   {
     //       IsTermsBusy = false;
     //       Term =new Term();
     //       Title = term?.TITLE;

     //       LoadTermsCommand = new Command(async () => await ExecuteLoadTermsCommand());
     //     //  LoadTermCommand = new Command(async () => await ExecuteLoadTermCommand());
     //       //  Term.Title = "check";
     //       Terms = new ObservableCollection<Term>();
     //}

        async Task ExecuteLoadTermsCommand()
        {
            try
            {

                Terms.Clear();

                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "glossary"},
                   // { "id", Term.ID.ToString()},
                };

                //cmd=restaurants&pagenumber=2&itemsonpage=5

                await AsyncQuery<TermsList>("", queryparams, (RestAnswer answer) =>
                {
                    foreach (var item in (answer as TermsList).items)
                    {
                        Terms.Add(item);
                        //RestForLoading.Add(item);
                    }

                    //var ans = answer as TermsList;

                    //for(int i=0; i<ans.items.Count; i++)
                    //{
                    //    Terms.Add(ans.items[i]);
                    //    //RestForLoading.Add(item);
                    //}

                  //  SetProperty<int>(ref termscount, Terms.Count, "TotalTerms");
                });

        }
            catch (Exception ex)
            {

            }
            finally
            {
                IsTermsBusy = false;
            }
           
        }

        //  public async Task ExecuteLoadTermCommand(out Term trm)
        public async Task ExecuteLoadTermCommand (object cmdparam)
        {
            try
            {

                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "glossary"},
                    { "id",(cmdparam).ToString()},
                };

                //cmd=restaurants&pagenumber=2&itemsonpage=5
                //Term newTerm = new Term();
                await AsyncQuery<Term>("", queryparams, (RestAnswer answer) =>
                 {
                     var newTerm = answer as Term;

                     Device.BeginInvokeOnMainThread(() =>
                     {
                         Ter = newTerm;
                     });
                 });

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //   IsTermsBusy = false;
            }

            //     await Shell.Current.GoToAsync($"{nameof(TermDetailPage)}?{nameof(TermDetailViewModel.Ter)}={Ter}");
            //   await Shell.Current.GoToAsync($"{nameof(TermDetailPage)}");
        }

        async Task ExecuteLoadItemCommand()
        {
            IsBusy = true;

            try
            {
                Terms.Clear();
             //   var items = await DataStore.GetItemsAsync(true);
                foreach (var item in Terms)
                {
                    Terms.Add(item);
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
    }
}
