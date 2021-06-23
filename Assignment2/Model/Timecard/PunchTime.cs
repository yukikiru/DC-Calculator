using System;
using System.ComponentModel;
namespace Assignment2.Model.Timecard
{
    //Class for each punch record
    public class PunchTime : INotifyPropertyChanged
    {
        private DateTime punchRecord_;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime punchRecord
        {
            get
            {
                return punchRecord_;
            }
            set
            {
                if(value == punchRecord_)
                {
                    return;
                }
                punchRecord_ = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(punchRecord)));
                }
            }
        }
        public PunchTime(DateTime date, TimeSpan time)
        {
            punchRecord_ = date.Date + time;
        }
        //Overrides ToString for user friendly presentation
        public override string ToString() {
            return "Punch at: "+punchRecord_.ToString("HH:mm");
        }
    }
}
