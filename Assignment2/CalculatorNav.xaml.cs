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
    }
}
