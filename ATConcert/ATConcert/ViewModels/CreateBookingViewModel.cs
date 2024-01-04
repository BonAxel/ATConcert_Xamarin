using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ATConcert.Models;
using ATConcert.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using ATConcert.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ATConcert.ViewModels
{
    [QueryProperty(nameof(ShowId), nameof(ShowId))]
    public class CreateBookingViewModel : BaseViewModel
    {
        public BookingRestApiDataStore _bookingRestApiDataStore;
        public ShowRestApiDataStore _showRestApiDataStore;
        public ConcertRestApiDataStore _concertRestApiDataStore;

        public Command CompleteBookingCommand { get; }
        public ObservableCollection<Show> Show { get; }
   
        public CreateBookingViewModel()
        {
            Show = new ObservableCollection<Show>();
            _bookingRestApiDataStore = new BookingRestApiDataStore();
            _showRestApiDataStore = new ShowRestApiDataStore();
            _concertRestApiDataStore = new ConcertRestApiDataStore();
            CompleteBookingCommand = new Command(async () => await CompleteBooking());

        }

        public async void LoadShowInitialy()
        {          
            LoadSelectedShow();
        }

        public async void LoadSelectedShow()
        {
            if (Show == null) return;
            Show.Clear();

            var show = await _showRestApiDataStore.GetShowAsync(ShowId);
            if (show == null) return;
            Show.Add(show);

        }

        async Task CompleteBooking()
        {
            Booking newBooking = new Booking() {
                CustomerEmail = CustomerMail,
                CustomerName = CustomerName,
                Show = BookedShow
            };
          var concertList = await _bookingRestApiDataStore.AddBookingAsync(newBooking);
        }


        private string customerMail;

        public string CustomerMail
        {
            get => customerMail;
            set => SetProperty(ref customerMail, value);
        }

        private string customerName;

        public string CustomerName
        {
            get => customerName;
            set => SetProperty(ref customerName, value);
        }

        private string showId;

        public string ShowId
        {
            get
            {
                return showId;
            }
            set
            {
                showId = value;
                LoadShowId(value);
            }
        }

        private Show bookedShow;

        public Show BookedShow
        {
            get
            {
                return bookedShow;
            }
            set
            {
                bookedShow = value;
            }
        }

        public async void LoadShowId(string showId)
        {
            try
            {
                Show.Clear();
                var show = await _showRestApiDataStore.GetShowAsync(showId);
                if (show == null) return;
                BookedShow = show;
                Show.Add(show);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
