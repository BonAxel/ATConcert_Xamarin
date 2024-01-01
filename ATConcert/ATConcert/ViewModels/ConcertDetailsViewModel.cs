using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ATConcert.ViewModels
{
    class ConcertDetailsViewModel
    {

        [QueryProperty(nameof(ConcertId), nameof(ConcertId))]
        public class ConcertDetailViewModel : BaseViewModel
        {
            private string concertId;
            private string text;
            private string description;
            public int Id { get; set; }

            public string Title
            {
                get => text;
                set => SetProperty(ref text, value);
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
