using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assignment2.Model.Timecard;
namespace Assignment2.Model
{
    public class Manager
    {

        public ObservableCollection<string> test = new ObservableCollection<string>();
        public ObservableCollection<PunchTime> punches = new ObservableCollection<PunchTime>();
        public ObservableCollection<WorkWeek> weeks = new ObservableCollection<WorkWeek>();
        public Manager()
        {
        }

        //Checks what week the new punch record belongs to then tries to add record
        public void addPunch(DateTime d, TimeSpan t) {
            DateTime newDate = d;
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = newDate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(newDate));
            
            bool same = false;
            for(int i = 0;i < weeks.Count; i++)
            {
                var d2 = weeks[i].days[0].dailyPunches[0].punchRecord.Date.AddDays(-1 * (int)cal.GetDayOfWeek(weeks[i].days[0].dailyPunches[0].punchRecord));
                if (d1 == d2)
                {
                    //week is same
                    weeks[i].addRecord(new PunchTime(d, t));
                    same = true;
                    break;
                }
            }
            if (!same)
            {
                //creatae new week is not the same as any existing
                weeks.Add(new WorkWeek(new PunchTime(d, t)));
            }
        }

        public void removePunch(PunchTime p, int weekIndex, int dayIndex)
        {
            weeks[weekIndex].days[dayIndex].dailyPunches.Remove(p);
        }
    }
}
