using System;
using System.Collections.ObjectModel;
namespace Assignment2.Model.Timecard
{
    //Contains collection of punch records for a given day
    public class Day
    {
        private string day_;
        public int count = 0;
        public string day
        {
            get { return day_; }
        }
        private ObservableCollection<PunchTime> dailyPunches_ = null;
        public ObservableCollection<PunchTime> dailyPunches
        {
            get { return dailyPunches_; }
        }
        public Day()
        {
            dailyPunches_ = new ObservableCollection<PunchTime>();
            day_ = "N/A";
        }
        public Day(PunchTime p)
        {
            dailyPunches_ = new ObservableCollection<PunchTime>();
            addPunch(p);
            day_ = p.punchRecord.DayOfWeek + ", " + p.punchRecord.Day + " " + p.punchRecord.ToString("MMMM") + " " + p.punchRecord.Year;
        }

        public void addPunch(PunchTime p)
        {
            foreach(PunchTime pt in dailyPunches_)
            {
                if(pt.punchRecord == p.punchRecord)
                {
                    throw new Exception("Can't have two punch records for the same time on same date" + pt.punchRecord +":"+p.punchRecord);
                }
            }
            dailyPunches_.Add(p);
        }
        //public void removePunch(PunchTime p)
        //{
        //    dailyPunches_.Remove(p);
        //}
    }
}
