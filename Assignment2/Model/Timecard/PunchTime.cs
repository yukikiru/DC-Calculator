using System;
namespace Assignment2.Model.Timecard
{
    //Class for each punch record
    public class PunchTime
    {
        private DateTime punchRecord_;
        public DateTime punchRecord
        {
            get
            {
                return punchRecord_;
            }
            set
            {
                punchRecord_ = value;
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
