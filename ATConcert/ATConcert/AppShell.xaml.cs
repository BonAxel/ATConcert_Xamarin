using ATConcert.ViewModels;
using ATConcert.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ATConcert
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ConcertDetailsPage), typeof(ConcertDetailsPage));
            Routing.RegisterRoute(nameof(CreateBookingPage), typeof(CreateBookingPage));

            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
