﻿using ATConcert.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATConcert.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBookingPage : ContentPage
    {
        public CreateBookingPage()
        {
            InitializeComponent();
            BindingContext = new CreateBookingViewModel();

        }
    }
}