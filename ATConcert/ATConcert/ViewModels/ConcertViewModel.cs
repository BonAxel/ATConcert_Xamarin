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
using System.Linq;



namespace ATConcert.ViewModels
{
    class ConcertViewModel : BaseViewModel
    {
        private Concert _selectedConcert;
        private string _selectedGenre;

        public ConcertRestApiDataStore _concertRestApiDataStore;
        public ObservableCollection<Concert> Concerts { get; }
        public ObservableCollection<string> FilteredGenre { get; }

        public Command LoadConcertCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Concert> ConcertTapped { get; }
        public Command<string> SearchGenre { get; }


        public ConcertViewModel()
        {
            Title = "Concerts";
            Concerts = new ObservableCollection<Concert>();
            FilteredGenre = new ObservableCollection<string>();
            _concertRestApiDataStore = new ConcertRestApiDataStore();
            LoadConcertCommand = new Command(async () => await ExecuteLoadConcertCommand(null));
            ConcertTapped = new Command<Concert>(OnConcertSelected);
            SearchGenre = new Command<string>(OnGenreSelected);

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


        public string SelectedGenre
        {
            get => _selectedGenre;
            set 
            {
                SetProperty(ref _selectedGenre, value);
                OnGenreSelected(value);
            } 
        }


        async void OnGenreSelected(string genre)
        {
            try
            {
                Concerts.Clear();
                //FilteredGenre.Clear();
                if (genre == null)
                    return;

                var concertList = await _concertRestApiDataStore.GetConcertsAsync();
                List<Concert> concertsToAdd = new List<Concert>();

                foreach (var concert in concertList)
                {
                    if (concert.Genre != null && concert.Genre.Contains(genre))
                    {
                        concertsToAdd.Add(concert);
                    }
                }
                foreach (var concert in concertsToAdd) Concerts.Add(concert);
            }
            catch   (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {

            }
        }


        public async void LoadDataInitialy()
        {
            Concerts.Clear();
            await ExecuteLoadConcertCommand(null);
        }


        public void OnAppearing()
        {
            IsBusy = true;
            SelectedConcert = null;
        }


        async void OnConcertSelected(Concert concert)
        {
            if (concert == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ConcertDetailsPage)}?{nameof(ConcertDetailsViewModel.ConcertId)}={concert.ConcertId}");
        }


        //METHODS
        async Task ExecuteLoadConcertCommand(string genre)
        {
            IsBusy = true;

            try
            {
                FilteredGenre.Clear();
                Concerts.Clear();
                var concertList = await _concertRestApiDataStore.GetConcertsAsync();

                List<string> allGenres = new List<string>();
                foreach (var concert in concertList)
                {
                    Concerts.Add(concert);

                    if (concert.Genre != null && concert.Genre.Length > 0)
                    {
                        allGenres.AddRange(concert.Genre);
                    }
                }
                var GenreQuery = allGenres.Distinct().ToList();
                foreach (var item in GenreQuery) FilteredGenre.Add(item);

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
