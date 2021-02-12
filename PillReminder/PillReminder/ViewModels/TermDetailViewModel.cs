using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PillReminder.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PillReminder.ViewModels
{
   [QueryProperty(nameof(Ter), nameof(Ter))]
   public class TermDetailViewModel : BaseViewModel
    {
        Term term;
        bool _IsTermsBusy;
        private string description ;
      //  private string title ;
        private string id ;
        public bool IsTermsBusy
        {
            get { return _IsTermsBusy; }
            set { SetProperty(ref _IsTermsBusy, value); }
        }
         
      //  public ObservableCollection<Term> Terms { set; get; }
    //    public Command LoadTermsCommand { get; }
        public string Id 
        { 
            get => id;
            set
            {
               // id = value;
                SetProperty(ref id, value);
            //    LoadItemId(value);
            }
        }
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

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        //public string Title 
        //{
        //    get => title;
        //    set => SetProperty(ref title, value);
        //}
        //public void PutData(Term term)
        //{
        //    Title = term.TITLE;
        //    Description = term.DESCRIPTION;
        //}

        public TermDetailViewModel()
        {
             IsTermsBusy = false;
            //Term = new Term() 
            //{
            //    ID = "some id",
            //    TITLE = "some title",
            //    DESCRIPTION = "some desc"
            //};
        //    Term = new Term();
       //     LoadItemId(Id);
            //   Title = term?.Title;
      //      LoadTermsCommand = new Command(async () => await ExecuteLoadTermsCommand());
            //  Term.Title = "check";
            }

        public async void LoadItemId(string termId)
        {
            try
            {
              //  Term = new Term();
                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "glossary"},
                    { "id", termId},
                };
                await AsyncQuery<Term>("", queryparams, (RestAnswer answer) =>
                {
                    Ter = answer as Term;
                  
                });
                
                if(Ter.TITLE != "")
                {}
                    Title = Ter.TITLE;
                    Description = Ter.DESCRIPTION;
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item "+ ex.Message);
            }
            finally
            {
                IsTermsBusy = false;
            }
        }
        //async Task ExecuteLoadTermsCommand()
        //{
        //    try
        //    {
              
        //        await AsyncQuery<Term>("", queryparams, (RestAnswer answer) =>
        //        {
        //            foreach (var item in (answer as TermsList).items)
        //            {
        //                Terms.Add(item);
        //                //RestForLoading.Add(item);
        //            }

        //            var ans = answer as Term;

        //            Term = ans;

        //         //   SetProperty<int>(ref termscount, Terms.Count, "TotalTerms");
        //        });

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        IsTermsBusy = false;
        //    }
       // }

    }
}
