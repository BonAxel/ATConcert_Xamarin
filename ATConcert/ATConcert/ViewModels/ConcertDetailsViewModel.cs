using ATConcert.Models;
using ATConcert.Services;
using ATConcert.Services.Interfaces;
using ATConcert.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ATConcert.ViewModels
{
    [QueryProperty(nameof(ConcertId), nameof(ConcertId))]
    public class ConcertDetailsViewModel : BaseViewModel
    {
        public ShowRestApiDataStore _showRestApiDataStore;
        public ConcertRestApiDataStore _concertRestApiDataStore;

        public Command<Show> ShowTapped { get; }

        public ObservableCollection<Show> ConcertShows { get; }
        private string concertId;
        private string text;
        private string description;
        private string title;
        public int Id { get; set; }


        public ConcertDetailsViewModel()
        {
            ConcertShows = new ObservableCollection<Show>();
            _concertRestApiDataStore = new ConcertRestApiDataStore();
            _showRestApiDataStore = new ShowRestApiDataStore();
            ShowTapped = new Command<Show>(OnShowSelected);
        }



        public string ConcertId
        {
            get
            {
                return concertId;
            }
            set
            {
                concertId = value;
                LoadItemId(value);
            }
        }

        private Concert _concert;

        public Concert Concert
        {
            get => _concert;
            set => SetProperty(ref _concert, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        async void OnShowSelected(Show show)
        {
            if (show == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(CreateBookingPage)}?{nameof(CreateBookingViewModel.ShowId)}={show.ShowId}");
        }

        public async void LoadItemId(string concertId)
        {
            try
            {
                ConcertShows.Clear();
                var concert = await _concertRestApiDataStore.GetConcertAsync(concertId);
                foreach (var show in concert.Show)
                {
                    ConcertShows.Add(show);
                }
                Title = concert.Title;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
