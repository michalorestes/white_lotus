using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteLotus_mainCW
{
    public class Workshop : Session
    {
        

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


        public Workshop(DateTime startDate, TimeSpan time, string style, string level, int instructorID,
                        int duration, int capacity, string title, string description,
                        string room, int reservations) : base(startDate, time, style, level, instructorID, duration,
                                                                capacity, title, description, room, reservations)
        {

        }





    }
    
}