using PillReminder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
    public class OffersList : RestAnswer
    {
        public List<Offer> actions { get; set; }
    }
    class OfferViewModel : BaseViewModel
    {
        private bool offerTapped;
        bool _IsOffersBusy;
        private int totalOffers = 0;

        public int TotalOffers
        {
            get { return totalOffers; }
            set { SetProperty(ref totalOffers, value); }
        }
        public bool OfferTapped
        {
            get { return offerTapped; }
            set { SetProperty(ref offerTapped, value); }
        }
        public bool IsOffersBusy
        {
            get { return _IsOffersBusy; }
            set { SetProperty(ref _IsOffersBusy, value); }
        }

        public ObservableCollection<Offer> Offers { set; get; }
        private Offer ofer;
        public Command LoadOffersCommand { get; }
        public Command LoadOfferCommand { get; }

        public Offer Ofr
        {
            get
            {
                return ofer;
            }
            set
            {
                SetProperty(ref ofer, value);
                //    PutData(value);
            }
        }

        public ref int offerscount => throw new NotImplementedException();

        public OfferViewModel(Offer offr = null)
        {
            IsOffersBusy = false;
            Ofr = new Offer();
            Title = offr?.TITLE;
            Offers = new ObservableCollection<Offer>();
            LoadOffersCommand = new Command(async () => await ExecuteLoadOffersCommand());
            //   LoadTermCommand = new Command(async () => await ExecuteLoadTermCommand(term.ID));
            //  Term.Title = "check";
            
        }

        private async Task ExecuteLoadOffersCommand()
        {
            try
            {
                Offers.Clear();
                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "actions"},
                   // { "id", Ofr.ID.ToString()},
                };

                await AsyncQuery<OffersList>("", queryparams, (RestAnswer answer) =>
                {
                    var ans = (answer as OffersList);

                    if (ans != null & ans.actions != null)
                    {
                        foreach (var item in (answer as OffersList).actions)
                        {
                            Offers.Add(item);
                        }
                    }

                    TotalOffers = Offers.Count;
                });

            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsOffersBusy = false;
            }
        }
        }
    }
