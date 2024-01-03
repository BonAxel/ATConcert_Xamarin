using ATConcert.Models;
using ATConcert.Services;
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
    class ConcertDetailsViewModel
    {

        [QueryProperty(nameof(Concert), nameof(Concert))]
        public class ConcertDetailViewModel : BaseViewModel
        {

            public ObservableCollection<Show> ConcertShows { get; }
            private string concertId;
            private string text;
            private string description;
            //private ObservableCollection<Show> concertShows = new ObservableCollection<Show>();
            private string title;
            public int Id { get; set; }

            private string _serializedConcert;

            public ConcertDetailViewModel()
            {
                ConcertShows = new ObservableCollection<Show>();
            }

            public string SerializedConcert
            {
                get => _serializedConcert;
                set
                {
                    SetProperty(ref _serializedConcert, value);
                    Concert = JsonConvert.DeserializeObject<Concert>(value);
                }
            }

            private Concert _concert;

            public Concert Concert
            {
                get => _concert;
                set => SetProperty(ref _concert, value);
            }


            public string Title
            {
                get => title;
                set => SetProperty(ref title, value);
            }

            public string Description
            {
                get => description;
                set => SetProperty(ref description, value);
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


            async Task ExecuteLoadConcertCommand()
            {
                IsBusy = true;

                try
                {
                    ConcertShows.Clear();
                    //Hämtar data? --OBS DENNA SKA REFRESHA HÄMTANDE AV DATA
                    //_restApiDataStore = new RestApiDataStore();
                    //var concertList = await _concertRestApiDataStore.GetConcertsAsync(Concert.ConcertId);
                    foreach (var show in Concert.Show) ConcertShows.Add(show);
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


            public async void LoadItemId(string concertId)
            {
                try
                {
                    var concert = await DataStore.GetItemAsync(concertId);
                    Id = concert.ConcertId;
                    Title = concert.Title;
                    Description = concert.Description;
                }
                catch (Exception)
                {
                    Debug.WriteLine("Failed to Load Item");
                }
            }
        }
    }
}
