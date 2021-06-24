using System;
using System.Collections.Generic;
using Assignment2.Model;
using Assignment2.Model.Timecard;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class viewWeek : ContentPage
    {
        private int weekIndex_;
        public int weekNum;
        public Manager m;
        public WorkWeek week;
        public viewWeek(WorkWeek w, int weekIndex, ref Manager man)
        {

            InitializeComponent();
            m = man;
            weekIndex_ = weekIndex;
            week = w;
            weekNum = week.weekOfYear;
            weekView.ItemsSource = week.days;
        }


        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void weekView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var val = (e.SelectedItem as Day);
            int index = 0;
            for(int i = 0; i < week.days.Count; i++)
            {
                if (week.days[i].day.Equals(val.day))
                {
                    index = i;
                    break;
                }
            }
            await Navigation.PushAsync(new ViewDay(val, weekIndex_,index, ref m));
            //weekView.SelectedItem = null;
        }

    }
}
