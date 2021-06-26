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

        //Gets a day object from the viewWeek page, the week's index, day index and a reference to the manager
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
        protected async override void OnAppearing()
        {
            m.weekDB = await m.db.createTable();
            base.OnAppearing();
        }

        //Deletes punch time. If the day becomes empty the day is deleted and the user is taken back to home page.
        async void deletePunch(System.Object sender, System.EventArgs e)
        {
            var p = (sender as MenuItem).CommandParameter as PunchTime;
            int punchIndex = 0;
            for(int i = 0; i < day.dailyPunches.Count; i++)
            {
                if(p.punchRecord.Date == day.dailyPunches[i].punchRecord.Date)
                {
                    punchIndex = i;
                    break;
                }
            }
            int dayCount = m.weeks[weekIndex_].days.Count;
            int weekCount = m.weeks.Count;
            bool weekRemoved = m.removePunch(weekIndex_, dayIndex_,punchIndex);
            if (weekRemoved)
            {
                m.db.deleteWeek(m.weekDB[weekIndex_]);
            }
            else
            {
                m.db.updateWeek(m.weekDB[weekIndex_]);
            }

            if(m.weeks.Count < weekCount)
            {
                await DisplayAlert("Success", "Punch deleted, returning home", "Okay");
                await Navigation.PopToRootAsync();
            }
            else if(m.weeks[weekIndex_].days.Count < dayCount)
            {
                await DisplayAlert("Success", "Punch deleted, returning home", "Okay");
                await Navigation.PopToRootAsync();
            }
            else
            {
                await DisplayAlert("Success", "Punch deleted", "Okay");
            }
        }

        void dayView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            PunchTime selected = e.SelectedItem as PunchTime;
            punchTime.IsEnabled = true;
            punchTime.timeValue = selected.punchRecord.TimeOfDay;
        }

        //Update selected punch time
        public async void updateRecord(System.Object sender, System.EventArgs e)
        {
            try
            {
                time = punchTime.timeValue;
                if (dayView.SelectedItem != null)
                {
                    int index = day.dailyPunches.IndexOf(dayView.SelectedItem as PunchTime);
                    m.updatePunch(new PunchTime(day.dailyPunches[index].punchRecord.Date, time), weekIndex_, dayIndex_, index);
                    m.db.updateWeek(m.weekDB[weekIndex_]);
                    await DisplayAlert("Time", "Time Updated: " + time.ToString("hh\\:mm"), "okay");
                }
                else
                {
                    throw new Exception("A punch record must be selected in order to update");
                }   
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }
}
