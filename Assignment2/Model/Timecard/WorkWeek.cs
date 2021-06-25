using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using Newtonsoft.Json;

namespace Assignment2.Model.Timecard
{
    public class WorkWeek : INotifyPropertyChanged
    {
        //interger value that contains the current week of the year (i.e Jan 1 is week 1)
        private int weekOfYear_;
        public int weekOfYear
        {
            get { return weekOfYear_; }
            set { weekOfYear_ = value; }
        }
        private ObservableCollection<Day> days_;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Day> days {
            get { return days_; }
        }
            
        public WorkWeek()
        {
            days_ = new ObservableCollection<Day>();
            weekOfYear_ = 0;
        }
        //Creates work week from punch time
        public WorkWeek(PunchTime p)
        {
            days_ = new ObservableCollection<Day>();
            addRecord(p);
            weekOfYear_ = getWeekNum(p);
        }

        //Gets the number of the current week relative to the beginning of the week (i.e. January 1 is week 1, December 31 is week 52)
        public int getWeekNum(PunchTime p)
        {
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myCal.GetWeekOfYear(p.punchRecord, myCWR, myFirstDOW);
        }

        //Adds a punch record. 
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
                    }
                }
                if (!exists)
                {
                    days_.Add(new Day(p));
                    weekOfYear_ = getWeekNum(p);
                }
            }
            //Will create a new day if no day already exists
            else
            {
                days_.Add(new Day(p));
                weekOfYear_ = getWeekNum(p);
            }
        }
        //Removes a punch record, if the day is empty will remove
        public void removeRecord(int index, int punchIndex)
        {
            days_[index].removePunch(punchIndex);
            if(days_[index].dailyPunches.Count == 0)
            {
                days_.RemoveAt(index);
            }
        }
    }
}
