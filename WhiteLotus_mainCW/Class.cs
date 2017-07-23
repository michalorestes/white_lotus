using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteLotus_mainCW
{
    public class Class : Session
    {

        private int repeateWks;
        List<DateTime> schedules;

        public int RepeateWks
        {
            get
            {
                return repeateWks;
            }

            set
            {
                repeateWks = value;
            }
        }

        public override DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public List<DateTime> Schedules
        {
            get
            {
                return schedules;
            }

            set
            {
                schedules = value;
            }
        }

        public Class(DateTime startDate, TimeSpan time, string style, string level,
                     int instructorID, int duration, int capacity, string title,
                     string description, string room, int reservations, int repeateWks) : base(startDate, time, style, level, instructorID, duration, capacity,
                                                                                title, description, room, reservations)
        {
            this.repeateWks = repeateWks;
            schedules = new List<DateTime>();
        }

        public void schedulesClass()
        {
            DateTime date = StartDate;
            string dateString;
            dateString = date.ToShortDateString();
            schedules.Add(DateTime.Parse(dateString).Date);

            for (int i = 0; i <= RepeateWks; i++)
            {
                dateString = date.AddDays(7).ToShortDateString();
                date = DateTime.Parse(dateString);
                schedules.Add(date);
            }
        }

    }
}