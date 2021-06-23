using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Assignment2.Model.Timecard
{
    public class WorkWeek
    {
        private int weekOfYear_;
        public int weekOfYear
        {
            get { return weekOfYear_; }
        }
        private ObservableCollection<Day> days_;
        public ObservableCollection<Day> days {
            get { return days_; }
        }
            
        public WorkWeek()
        {
            days_ = new ObservableCollection<Day>();
            weekOfYear_ = 0;
        }
        public WorkWeek(PunchTime p)
        {
            days_ = new ObservableCollection<Day>();
            addRecord(p);
            weekOfYear_ = getWeekNum(p);
        }

        private int getWeekNum(PunchTime p)
        {
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myCal.GetWeekOfYear(p.punchRecord, myCWR, myFirstDOW);
        }

        public void addRecord(PunchTime p)
        {
            //Adds a day if a day already exists
            bool exists = false;
            if(days_.Count > 0)
            {
                foreach(Day d in days_)
                {
                    if(d.dailyPunches[0].punchRecord.Date == p.punchRecord.Date)
                    {
                        d.addPunch(p);
                        exists = true;
                        //break;
                    }
                }
                if (!exists)
                {
                    days_.Add(new Day(p));
                    weekOfYear_ = getWeekNum(p);
                }
            }
            else
            {
                days_.Add(new Day(p));
                weekOfYear_ = getWeekNum(p);
            }
        }
    }
}
