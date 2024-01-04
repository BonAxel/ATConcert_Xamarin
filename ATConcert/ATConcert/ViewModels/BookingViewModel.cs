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

namespace ATConcert.ViewModels
{
    class BookingViewModel : BaseViewModel
    {
        public ObservableCollection<Booking> Bookings { get; }





        public BookingRestApiDataStore _bookingRestApiDataStore;
        public Booking _Booking { get; }
        public Command SearchForBooking { get; }
        public BookingViewModel()
        {
            Title = "Bookings";
            Bookings = new ObservableCollection<Booking>();
            _bookingRestApiDataStore = new BookingRestApiDataStore();
            SearchForBooking = new Command(async () => await ExecuteLoadBookingCommand());
            LoadDataInitialy();
        }

        public async void LoadDataInitialy()
        {
            await ExecuteLoadBookingCommand();
        }



        //PROPERTY
        async void OnSearchTap(Booking booking)
        {
            if (booking == null)
                return;
            // This will push the ItemDetailPage onto the navigation stack


            //await Shell.Current.GoToAsync($"{nameof(ConcertDetailsPage)}?{nameof(ConcertDetailViewModel.SerializedConcert)}={serializedConcert}");

            //await Shell.Current.GoToAsync($"{nameof(ConcertDetailsPage)}?{nameof(ConcertDetailViewModel.ConcertId)}={concert.ConcertId}");
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

        //METHODS
        async Task ExecuteLoadBookingCommand()
        {

            IsBusy = true;
            Notfound = "";

            try
            {
                Bookings.Clear();
                
                Booking booking = await _bookingRestApiDataStore.GetBookingtAsync(Searchstring);
                if (booking != null)
                {
                    Bookings.Add(booking);
                    Notfound = "Inga bokningar hittades";

                }
                else
                {
                    Notfound= "Inga bokningar hittades";

                }
                //foreach (var booking in bookingList) Bookings.Add(booking);
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