using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment2.Model;

namespace Assignment2
{
    public partial class MainPage : ContentPage
    {
        Manager m;
        public MainPage(ref Manager man)
        {
            InitializeComponent();
            m = man;
        }

        async public void navToCalculator(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalculatorNav(ref m));
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Button", "I'm a filler button", "Okay!");
        }
    }
}
