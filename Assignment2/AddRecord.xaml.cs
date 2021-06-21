using System;
using System.Collections.Generic;
using Assignment2.Model;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class AddRecord : ContentPage
    {
        public Manager m;
        public AddRecord(ref Manager man)
        {
            m = man;
            InitializeComponent();
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
