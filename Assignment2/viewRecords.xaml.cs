using System;
using System.Collections.Generic;
using Assignment2.Model;
using Assignment2.Model.Timecard;
using System.Collections.ObjectModel;

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
            WorkWeeks.ItemsSource = m.weeks;
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }


        async void WorkWeeks_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var val = (e.SelectedItem as WorkWeek);
            int index = m.weeks.IndexOf(e.SelectedItem as WorkWeek);
            await Navigation.PushAsync(new viewWeek(val, index, ref m));
        }

        //void clearSelection(System.Object sender, System.EventArgs e)
        //{
        //    if(WorkWeeks.SelectedItem != null)
        //    {
        //        WorkWeeks.SelectedItem = null;
        //    }
        //}

    }
}
