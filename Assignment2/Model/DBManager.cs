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

        public async Task<ObservableCollection<WeekModel>> createTable()
        {
            await connection_.CreateTableAsync<WeekModel>();
            var weeksFromDB = await connection_.Table<WeekModel>().ToListAsync();
            var allWeeks = new ObservableCollection<WeekModel>(weeksFromDB);
            return allWeeks;
        }


        public void addWeek(WeekModel week)
        {
            connection_.InsertAsync(week);
        }

        public void updateWeek(WeekModel week)
        {
            connection_.UpdateAsync(week);
        }

        public void deleteWeek(WeekModel week)
        {
            connection_.DeleteAsync(week);
        }
    }
}
