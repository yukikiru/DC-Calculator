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

        protected async override void OnAppearing()
        {
            m.weeks = await m.db.createTable();
            base.OnAppearing();
        }

            async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }


        async void WorkWeeks_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var val = (e.SelectedItem as WorkWeek);
            //int index = m.weeks.IndexOf(e.SelectedItem as WorkWeek);
            int index = 0;
            for(int i = 0; i < m.weeks.Count; i++)
            {
                if(m.weeks[i].weekOfYear == val.weekOfYear)
                {
                    index = i;
                    break;
                }
            }
            await Navigation.PushAsync(new viewWeek(val, index, ref m));
        }

    }
}
