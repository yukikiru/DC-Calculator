using System;
using Newtonsoft.Json;
using SQLite;
namespace Assignment2.Model.Timecard
{
    public class WeekModel
    {
        [PrimaryKey, AutoIncrement,Unique]
        public int ID { get; set; }

        //JSON string that holds all the information for each day
        [NotNull]
        public string JSON { get; set; }
        //Create a weekModel from a work week, serializing the subobjects to JSON
        public WeekModel(WorkWeek w)
        {
            JSON = JsonConvert.SerializeObject(w, Formatting.Indented);
        }
        public WeekModel()
        {

        }
    }
}
