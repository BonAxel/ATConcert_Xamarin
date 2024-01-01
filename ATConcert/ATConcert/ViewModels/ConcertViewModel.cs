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

namespace ATConcert.ViewModels
{
    class ConcertViewModel : BaseViewModel
    {
        private Concert _selectedConcert;

        public RestApiDataStore _restApiDataStore;
        public ObservableCollection<Concert> Concerts { get; }
        public Command LoadConcertCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Concert> ConcertTapped { get; }

        public ConcertViewModel()
        {
            Title = "Concerts";
            Concerts = new ObservableCollection<Concert>();
            _restApiDataStore = new RestApiDataStore();
            LoadConcertCommand = new Command(async () => await ExecuteLoadConcertCommand());
            ConcertTapped = new Command<Concert>(OnConcertSelected);
            //Concerts.Add(new Concert
            //{
            //    ConcertId = 1,
            //    Title = "Slipknot",
            //    Price = 130,
            //    Length = 180,
            //    Description = "Slipknot finaly arrives to Sweden, get your tickets now",
            //    ConcertGenres = new List<ConcertGenres>()
            //    {
            //        new ConcertGenres { Genre = new Genre { Name = "Rock" } }
            //    }
            //});
        }

        //PROPERTY
        public Concert SelectedConcert
        {
            get => _selectedConcert;
            set
            {
                SetProperty(ref _selectedConcert, value);
                OnConcertSelected(value);
            }
        }

        async void OnConcertSelected(Concert concert)
        {
            if (concert == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ConcertDetailsPage)}?{nameof(ConcertDetailViewModel.ConcertId)}={concert.ConcertId}");
        }


        //METHODS
        async Task ExecuteLoadConcertCommand()
        {
            IsBusy = true;

            try
            {
                Concerts.Clear();
                //Hämtar data? --OBS DENNA SKA REFRESHA HÄMTANDE AV DATA
                _restApiDataStore = new RestApiDataStore();
                var concertList = await _restApiDataStore.GetConcertsAsync();
                foreach (var concert in concertList) Concerts.Add(concert);
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
