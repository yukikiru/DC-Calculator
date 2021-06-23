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
            int index = week.days.IndexOf(e.SelectedItem as Day);
            await Navigation.PushAsync(new ViewDay(val, weekIndex_,index, ref m));
            //weekView.SelectedItem = null;
        }

    }
}
