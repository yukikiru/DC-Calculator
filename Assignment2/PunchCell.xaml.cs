using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class PunchCell : ViewCell
    {
        public DateTime date
        {
            get { return date_; }
            set { date_ = value; }
        }
        public static readonly BindableProperty datePickerProperty = BindableProperty.Create("date", typeof(DateTime), typeof(PunchCell));
        private DateTime date_
        {
            get
            {
                return (DateTime)GetValue(datePickerProperty);
            }
            set
            {
                SetValue(datePickerProperty, value);
            }
        }

        private string dateCellLabel_;
        public static readonly BindableProperty dateCellLabelProperty = BindableProperty.Create("dateCellLabel", typeof(string), typeof(PunchCell));
        public string dateCellLabel
        {
            get
            {
                return (string)GetValue(dateCellLabelProperty);
            }
            set
            {
                SetValue(dateCellLabelProperty, value);
            }
        }

        public PunchCell()
        {
            InitializeComponent();
            BindingContext = this;
            date_ = DateTime.Now;
        }
    }
}
