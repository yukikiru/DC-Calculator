using System;
using System.Collections.Generic;
using Assignment2.Model;
using Assignment2.Model.Timecard;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class ViewDay : ContentPage
    {
        private int weekIndex_, dayIndex_;
        public Manager m;
        public Day day;
        public ViewDay(Day d, int weekIndex, int dayIndex, ref Manager man)
        {
            InitializeComponent();
            m = man;
            weekIndex_ = weekIndex;
            dayIndex_ = dayIndex;
            day = d;
            dayView.ItemsSource = day.dailyPunches;
            if (day.dailyPunches.Count > 0)
            {
                Title = d.dailyPunches[0].punchRecord.ToString("MMMM dd, yyyy");
            }
            else
            {
                Title = "Daily Punch (Empty)";
            }
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        void deletePunch(System.Object sender, System.EventArgs e)
        {
            var p = (sender as MenuItem).CommandParameter as PunchTime;
            m.removePunch(p, weekIndex_, dayIndex_);
            DisplayAlert("Success", "Punch deleted", "Okay");
        }
    }
}
