using System;
using SQLite;
using Newtonsoft.Json;
using Xamarin.Forms;
using Assignment2.Persistence;
using Assignment2.Model.Timecard;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    //Manager for the SQLite database. Deals with an object that is a collection of serialized week objects
    public class DBManager
    {
        private SQLiteAsyncConnection connection_;
        public DBManager()
        {
            connection_ = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        public async Task<ObservableCollection<WorkWeek>> createTable()
        {
            await connection_.CreateTableAsync<WeekModel>();
            var weeksFromDB = await connection_.Table<WeekModel>().ToListAsync();
            var allWeeks = new ObservableCollection<WeekModel>(weeksFromDB);
            if(allWeeks.Count > 0)
            {
                ObservableCollection<WorkWeek> ww = new ObservableCollection<WorkWeek>();
                for (int i = 0; i <allWeeks.Count; i++)
                {
                    WorkWeek w= JsonConvert.DeserializeObject<WorkWeek>(allWeeks[i].JSON);
                    //JSON not loading object properly, setting the week of year and day string here
                    w.weekOfYear = w.getWeekNum(w.days[0].dailyPunches[0]);
                    for(int j = 0;j < w.days.Count; j++)
                    {
                        w.days[j].formatDay(w.days[0].dailyPunches[0]);
                    }
                    ww.Add(w);
                }
                return ww;
            }
            else
            {
                return new ObservableCollection<WorkWeek>();
            }
        }


        public void addWeek(WeekModel week)
        {
            connection_.InsertAsync(week);
        }

        public void updateWeek(WeekModel week)
        {
            var validWeek = connection_.FindAsync<WeekModel>(u => u.JSON == week.JSON);
            //validWeek.JSON = week.JSON;
            
            connection_.UpdateAsync(week);
        }

        public void deleteWeek(WeekModel week)
        {
            connection_.Table<WeekModel>().DeleteAsync(u => u.JSON == week.JSON);
        }
    }
}
