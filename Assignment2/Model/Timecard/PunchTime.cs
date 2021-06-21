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
        public PunchTime()
        {
        }
    }
}
