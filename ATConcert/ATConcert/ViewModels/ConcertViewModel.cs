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
using ATConcert.Services;
using Newtonsoft.Json;



namespace ATConcert.ViewModels
{
    class ConcertViewModel : BaseViewModel
    {
        private Concert _selectedConcert;

        public ConcertRestApiDataStore _concertRestApiDataStore;
        public ObservableCollection<Concert> Concerts { get; }
        public Command LoadConcertCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Concert> ConcertTapped { get; }

        public ConcertViewModel()
        {
            Title = "Concerts";
            Concerts = new ObservableCollection<Concert>();

            _concertRestApiDataStore = new ConcertRestApiDataStore();
            LoadConcertCommand = new Command(async () => await ExecuteLoadConcertCommand());
            ConcertTapped = new Command<Concert>(OnConcertSelected);
            LoadDataInitialy();
        }

        public async void LoadDataInitialy()
        {
            await ExecuteLoadConcertCommand();
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

            string serializedConcert = JsonConvert.SerializeObject(concert);

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ConcertDetailsPage)}?{nameof(ConcertDetailViewModel.SerializedConcert)}={serializedConcert}");

            await Shell.Current.GoToAsync($"{nameof(ConcertDetailsPage)}?{nameof(ConcertDetailsViewModel.ConcertId)}={concert.ConcertId}");
        }


        //METHODS
        async Task ExecuteLoadConcertCommand()
        {
            IsBusy = true;

            try
            {
                Concerts.Clear();
                //Hämtar data? --OBS DENNA SKA REFRESHA HÄMTANDE AV DATA
                //_restApiDataStore = new RestApiDataStore();
                var concertList = await _concertRestApiDataStore.GetConcertsAsync();
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
