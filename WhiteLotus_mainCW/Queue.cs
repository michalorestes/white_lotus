using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteLotus_mainCW
{

    public class Queue
    {

        private int sessionID, userID, id;
        private string sessionType, sessionTitle;
        private DateTime date, reservationDate;
        private int waitingNumber; 

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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int WaitingNumber
        {
            get
            {
                return waitingNumber;
            }

            set
            {
                waitingNumber = value;
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

        public Queue(int id, int sessionID, int userID, string sessionType, DateTime date)
        {
            this.id = id;
            this.sessionID = sessionID;
            this.userID = userID;
            this.date = date;
            this.sessionType = sessionType;
        }
    }


}