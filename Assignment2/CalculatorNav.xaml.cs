using System;
using System.Collections.Generic;
using Assignment2.Model;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class CalculatorNav : ContentPage
    {
        Manager m;
        public CalculatorNav(ref Manager man)
        {
            m = man;
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Guten Morgen!", "Du hast den " + (sender as Button).Text + " Knopf gedrükt!", "Okay");
        }

        async void navToLoading(System.Object sedner, System.EventArgs e)
        {
            await Navigation.PushAsync(new Loading(ref m));
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
