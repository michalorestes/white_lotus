using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class UserPanel_CancelReservation : System.Web.UI.Page
    {
        int id;
        string type;
        Reservation reservation;
        
        User user;
        Session session;
        DateTime currentDate;
        DateTime sessionDate;
        TimeSpan dateDifference; 
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["loginData"] == null)
            {
                Response.Redirect("Default.aspx"); 
            }

            
            //store data from sessions and string querries 
            user = (User)Session["loginData"];              //user's details
            id = Int32.Parse(Request.QueryString["id"]);    //reservation ID 
            type = Request.QueryString["type"].ToString();  //type of session needed for writting to the database 

            
            reservation = DBconnection.getReservation(id, type);
            
              
            if (type.Equals("Workshop"))
            {
                session = DBconnection.getWorkshop(reservation.SessionID);
                
            }
            else if (type.Equals("Class"))
            {
                session = DBconnection.getClass(reservation.SessionID);
                
            }


            Label2.Text = session.Title;
            Label3.Text = session.StartDate.ToShortDateString() + " " + session.Time.ToString(); 

           
            currentDate = DateTime.Now;                                     //current date and time              
            sessionDate = session.StartDate.Date.Add(session.Time);         //store session's date and time in one DateTime object 
            dateDifference = sessionDate.Subtract(currentDate);
            TimeSpan hours24 = new TimeSpan(24, 0, 0);                      //create a timespan of 24h
            int compareTime = TimeSpan.Compare(dateDifference, hours24);    //compare both dates




            if (compareTime == -1)
            {
                Label1.Text = "You can cancel a session up to 24h before it is scheduled. We apologise for any inconvience";
                btn_confirm.Visible = false;
            }
            else
            {
                Label1.Text = "Are you sure you want to cancel the folloing session?";
            }


            
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPanel_Reservations.aspx");
        }

        protected void btn_confirm_Click(object sender, EventArgs e)
        {
            //load sessiion queue 
            List<Queue> sessionQueue = DBconnection.viewSessionQueue(session.Id, type);
            if (sessionQueue.Count != 0)      //check if queue contains any members
            {
                //check if reservation is same as capacity 
                if (session.Reservations == session.Capacity)
                {
                    //load the top queue member in to a Reservation object 
                    Reservation nextInQ = new Reservation(sessionQueue[0].SessionID, DateTime.Now, sessionQueue[0].UserID, sessionQueue[0].SessionTitle, sessionQueue[0].ReservationDate);
                    DBconnection.reserveSession(nextInQ, type); //add above reservation to a database 
                    DBconnection.removeQueue(sessionQueue[0].Id, "ID"); //remove queue member that has been added to a reservation 
                   
                }
            }        
            else 
            {
                //if queue does not exists, remove one reservation and update number of session's reservation 
                int reservationsNumber = session.Reservations - 1;
                DBconnection.updateSessionReservation(type, reservationsNumber, reservation);
            }


            DBconnection.deleteRecord("Reservation", reservation.ReservationID, "ID");
            








            Session["message"] = "Your reservation has been cancelled. Thank you";
            Response.Redirect("Message.aspx");
        }
    }
}