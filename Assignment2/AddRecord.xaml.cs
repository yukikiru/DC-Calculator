using System;
using System.Collections.Generic;
using Assignment2.Model;
using Assignment2.Model.Timecard;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class AddRecord : ContentPage
    {
        DateTime date = new DateTime();
        TimeSpan time = new TimeSpan();
        public Manager m;
        public AddRecord(ref Manager man)
        {
            InitializeComponent();
            m = man;
            timeCell.timeValue = DateTime.Now.TimeOfDay; //Initialize timepicker to current time
            BindingContext = this;
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

        public void addRecord(System.Object sender, System.EventArgs e)
        {
            try
            {
                time = timeCell.timeValue;
                date = punchCell.date;
                bool newWeek = m.addPunch(date, time);
                if (newWeek)
                {
                    m.db.addWeek(new WeekModel(new WorkWeek(new PunchTime(date, time))));
                }
                else
                {
                    m.db.updateWeek(new WeekModel(new WorkWeek(new PunchTime(date, time))));
                }
                DisplayAlert("Time", "Time Added: " + date.ToString("MMMM dd, yyyy") + " at " + time.ToString("hh\\:mm"), "okay");
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }
        }

    }
}
