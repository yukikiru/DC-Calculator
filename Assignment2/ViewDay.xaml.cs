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
        TimeSpan time = new TimeSpan();
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
            BindingContext = this;
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

        void dayView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            PunchTime selected = e.SelectedItem as PunchTime;
            punchTime.IsEnabled = true;
            punchTime.timeValue = selected.punchRecord.TimeOfDay;
        }

        void updateRecord(System.Object sender, System.EventArgs e)
        {
            try
            {
                time = punchTime.timeValue;
                if (dayView.SelectedItem != null)
                {
                    int index = day.dailyPunches.IndexOf(dayView.SelectedItem as PunchTime);
                    m.updatePunch(new PunchTime(day.dailyPunches[index].punchRecord.Date, time), weekIndex_, dayIndex_, index);
                    DisplayAlert("Time", "Time Updated: " + time.ToString("hh\\:mm"), "okay");
                }
                else
                {
                    throw new Exception("A punch record must be selected in order to update");
                }   
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }
}
