using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteLotus_mainCW
{
    public abstract class Session
    {
        private int id;
        protected DateTime startDate;
        private TimeSpan time;
        private string style;
        private string level;
        private int instructorID;
        private int duration;
        private int capacity;
        private int reservations;
        private string title;
        private string description;
        private string room;
        private string status;
        
        

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public abstract DateTime StartDate
        {
            get;
            
            set;
        }

        public TimeSpan Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }

        public string Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public int InstructorID
        {
            get
            {
                return instructorID;
            }

            set
            {
                instructorID = value;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Room
        {
            get
            {
                return room;
            }

            set
            {
                room = value;
            }
        }

        public int Reservations
        {
            get
            {
                return reservations;
            }

            set
            {
                reservations = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Session(DateTime startDate, TimeSpan time, string style, string level, int instructorID, int duration, int capacity, string title, string description, string room, int reservations)
        {

            this.startDate = startDate;
            this.time = time;
            this.style = style;
            this.level = level;
            this.instructorID = instructorID;
            this.duration = duration;
            this.capacity = capacity;
            this.title = title;
            this.description = description;
            this.room = room;
            this.reservations = reservations;
        }

        
    }











}