using System;
using System.Collections.Generic;
using Assignment2.Model;
using Assignment2.Model.Timecard;
using Newtonsoft.Json;
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
            m.weekDB = new System.Collections.ObjectModel.ObservableCollection<WeekModel>();
            m.weekDB = await m.db.createTable();
            m.workDBToWorkWeek();
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
                int index = 0;
                bool newWeek = m.addPunch(date, time, ref index);
                if (newWeek)
                {
                    m.db.addWeek(new WeekModel(new WorkWeek(new PunchTime(date, time))));
                }
                else
                {
                    m.db.updateWeek(m.weekDB[index]);
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
