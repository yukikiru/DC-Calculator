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

        async void navToLoading(System.Object sedner, System.EventArgs e)
        {
            await Navigation.PushAsync(new Loading(ref m));
        }

        async void navToPD(System.Object sedner, System.EventArgs e)
        {
            await Navigation.PushAsync(new PreDispatch(ref m));
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }


    }
}
