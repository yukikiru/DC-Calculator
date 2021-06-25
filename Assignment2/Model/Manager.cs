using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assignment2.Model.Timecard;
using Newtonsoft.Json;
namespace Assignment2.Model
{
    public class Manager
    {

        public ObservableCollection<WorkWeek> weeks = new ObservableCollection<WorkWeek>();
        public DBManager db = new DBManager();
        public ObservableCollection<WeekModel> weekDB = new ObservableCollection<WeekModel>();
        public Manager()
        {
        }

        //Checks what week the new punch record belongs to then tries to add record. Returns true if week exists, false if its new
        public bool addPunch(DateTime d, TimeSpan t, ref int index) {
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
                    weekDB[i].JSON = JsonConvert.SerializeObject(weeks[i], Formatting.Indented);
                    index = i;
                    same = true;
                    break;
                }
            }
            if (!same)
            {
                WorkWeek w = new WorkWeek(new PunchTime(d, t));
                weeks.Add(w);
                weekDB.Add(new WeekModel(w));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updatePunch(PunchTime p, int weekIndex, int dayIndex, int punchIndex)
        {
            weeks[weekIndex].days[dayIndex].dailyPunches[punchIndex] = p;
            weekDB[weekIndex].JSON = JsonConvert.SerializeObject(weeks[weekIndex], Formatting.Indented);
        }

        //Returns true if the week will be removed so it can be removed from the DB
        public bool removePunch(int weekIndex, int dayIndex, int punchIndex)
        {
            weeks[weekIndex].removeRecord(dayIndex,punchIndex);
            if(weeks[weekIndex].days.Count == 0)
            {
                weeks.RemoveAt(weekIndex);  
                return true;
            }
            else
            {
                weekDB[weekIndex].JSON = JsonConvert.SerializeObject(weeks[weekIndex], Formatting.Indented);
                return false;
            }
        }

        //Convert WeekModel to WorkWeek object
        public void workDBToWorkWeek()
        {
            weeks = new ObservableCollection<WorkWeek>();
            if (weekDB.Count > 0)
            {
                for(int i = 0; i < weekDB.Count; i++)
                {
                    WorkWeek w = JsonConvert.DeserializeObject<WorkWeek>(weekDB[i].JSON);
                    w.weekOfYear = w.getWeekNum(w.days[0].dailyPunches[0]);
                    for (int j = 0; j < w.days.Count; j++)
                    {
                        w.days[j].formatDay(w.days[0].dailyPunches[0]);
                    }
                    weeks.Add(w);
                }
            }
        }
    }
}
