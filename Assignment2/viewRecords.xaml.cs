using System;
using System.Collections.Generic;
using Assignment2.Model;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class viewRecords : ContentPage
    {
        public Manager m;
        public viewRecords(ref Manager man)
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
