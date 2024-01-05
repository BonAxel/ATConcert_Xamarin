using ATConcert.Models;
using ATConcert.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ATConcert.Models.Junctions;
using static ATConcert.ViewModels.ConcertDetailsViewModel;
using ATConcert.Services;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Linq;
using ATConcert.Services.Interfaces;
using System.Xml.Schema;

namespace ATConcert.ViewModels
{
    class BookingViewModel : BaseViewModel
    {
        public ObservableCollection<Booking> Bookings { get; }
        public BookingRestApiDataStore _bookingRestApiDataStore;
        public Booking _Booking { get; }
        public Command SearchForBooking { get; }
        public Command CancelBooking { get; }
        public BookingViewModel()
        {
            Notfound = string.Empty;
            Title = "Bookings";
            Bookings = new ObservableCollection<Booking>();
            _bookingRestApiDataStore = new BookingRestApiDataStore();
            SearchForBooking = new Command(async () => await OnSearchTap());
            CancelBooking = new Command(async () => await CancelSearchedBooking());
        }

        private int amountBookedShow;

        public int AmountBookedShow
        {
            get => amountBookedShow;
            set
            {
                SetProperty(ref amountBookedShow, value);
            }
        }



        private Booking selectedBooking;

        public Booking SelectedBooking
        {
            get => selectedBooking;
            set
            {
                SetProperty(ref selectedBooking, value);
                AmountBooked(value);
            }
        }


        //PROPERTY
        async Task CancelSearchedBooking()
        {
            var response = await _bookingRestApiDataStore.DeleteBookingAsync(SelectedBooking.BookingId);
            if (response == null)
            {
                Notfound = "Failed deleting booking";
            }
            else
            {
                Searchstring = "";
                Bookings.Remove(SelectedBooking);
            }

        }


        public async void AmountBooked(Booking selectedBooking)
        {
            try
            {
                var response = await _bookingRestApiDataStore.GetBookingsAsync();

                if (response != null)
                {
                    var bookings = response.Where(item => item.ShowId == selectedBooking.ShowId).ToList();
                    AmountBookedShow = bookings.Count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        async Task OnSearchTap()
        {
            IsBusy = true;
            Notfound = "";
            Bookings.Clear();
            var response = await _bookingRestApiDataStore.GetBookingtAsync(Searchstring);
            if (response != null)
            {
                Bookings.Add(response);
            }
            else
            {
                Notfound = "No Bookings found";
                return;
            }
        }

        public string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public string searchstring;
        public string Searchstring
        {
            get => searchstring;
            set => SetProperty(ref searchstring, value);
        }

        public string notfound;
        public string Notfound
        {
            get => notfound;
            set => SetProperty(ref notfound, value);
        }
    }
}