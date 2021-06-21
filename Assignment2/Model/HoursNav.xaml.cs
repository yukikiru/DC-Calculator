using System;
using System.Collections.Generic;
using Assignment2.Model;

using Xamarin.Forms;

namespace Assignment2.Model
{
    public partial class HoursNav : ContentPage
    {
        public Manager m;
        public HoursNav(ref Manager man)
        {
            m = man;
            InitializeComponent();
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void navToAddRecord(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddRecord(ref m));
        }

        async void navToRecordView(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new viewRecords(ref m));
        }
    }
}
