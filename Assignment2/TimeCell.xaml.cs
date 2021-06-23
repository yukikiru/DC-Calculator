using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Assignment2
{
    //Custom Time cell
    public partial class TimeCell : ViewCell, INotifyPropertyChanged
    {

        private TimeSpan time_
        {
            get
            {
                return (TimeSpan)GetValue(timePickerProperty);
            }
            set
            {
                SetValue(timePickerProperty, value);
            }
        }
        public static readonly BindableProperty timePickerProperty = BindableProperty.Create("timeValue", typeof(TimeSpan), typeof(TimeCell));
        public TimeSpan timeValue
        {
            get { return time_; }
            set { time_ = value; }
        }
        private string timeCellLabel_
        {
            get
            {
                return (string)GetValue(timeCellLabelProperty);
            }
            set
            {
                SetValue(timeCellLabelProperty, value);
            }
        }
        public static readonly BindableProperty timeCellLabelProperty = BindableProperty.Create("timeCellLabel", typeof(string), typeof(TimeCell));
        public string timeCellLabel
        {
            get { return timeCellLabel_; }
            set { timeCellLabel_ = value; }
        }

        public TimeCell()
        {
            InitializeComponent();
            BindingContext = this;
            time_ = DateTime.Now.TimeOfDay;
        }
    }
}
