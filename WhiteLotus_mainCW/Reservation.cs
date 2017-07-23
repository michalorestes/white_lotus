using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteLotus_mainCW
{
    public class Reservation
    {

        int sessionID;
        DateTime reservationDate;
        int userID;
        TimeSpan time; 

        DateTime sessionDate;
        string sessionTitle;
        string sessionStatus;
        string sessionType;
        int reservationID; 
   
 

        public DateTime ReservationDate
        {
            get
            {
                return reservationDate;
            }

            set
            {
                reservationDate = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public int SessionID
        {
            get
            {
                return sessionID;
            }

            set
            {
                sessionID = value;
            }
        }

        public DateTime SessionDate
        {
            get
            {
                return sessionDate;
            }

            set
            {
                sessionDate = value;
            }
        }

        public string SessionTitle
        {
            get
            {
                return sessionTitle;
            }

            set
            {
                sessionTitle = value;
            }
        }

        public string SessionStatus
        {
            get
            {
                return sessionStatus;
            }

            set
            {
                sessionStatus = value;
            }
        }

        public string SessionType
        {
            get
            {
                return sessionType;
            }

            set
            {
                sessionType = value;
            }
        }

        public int ReservationID
        {
            get
            {
                return reservationID;
            }

            set
            {
                reservationID = value;
            }
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

        public User Contains
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Session Includes
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }



        //used for creating a new reservation 
        public Reservation(int sessionID, DateTime reservationDate, int userID, string sessionTitle, DateTime sessionDate)
        {
            this.sessionID = sessionID;
            this.reservationDate = reservationDate;
            this.userID = userID;
            this.sessionDate = sessionDate;
            this.SessionTitle = sessionTitle;
        }
        //used for loading only reservation details 
        public Reservation(int reservationID, int sessionID, DateTime reservationDate, int userID, string type)
        {
            this.reservationID = reservationID; 
            this.sessionID = sessionID;
            this.reservationDate = reservationDate;
            this.userID = userID;
            this.sessionType = type;
            
        }


        //constructors used for reading existing reservations that inclused sessions details 
        public Reservation(int reservationID, int sessionID, DateTime sessionDate, DateTime reservationDate, string sessionTitle, string sessionStatus, string sessionType)
        {
            
            this.sessionDate = sessionDate;
            this.sessionTitle = sessionTitle;
            this.sessionStatus = sessionStatus;
            this.sessionType = sessionType;
            this.reservationID = reservationID;
            this.SessionID = sessionID;
            this.reservationDate = reservationDate;

        }
    }
}