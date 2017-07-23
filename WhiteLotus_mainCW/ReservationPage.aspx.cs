using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class ReservationPage : System.Web.UI.Page
    {
        int id;
        string type;
        
        
        User user;
        Reservation reservation;
        Session s;
        bool queue; 
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //check if the user has logged in before booking a class
            //if false, redirect the user to a error message page 
            if (Session["loginData"] == null)
            {
                Session["message"] = "You must be logged in before booking a session. You will be redirected to home page in 10 seconds.";
                Response.Redirect("Message.aspx");

            }
            //check if the user has selected a session to book
            //if false, redirect the user to Classes.aspx
            else if(Request.QueryString["id"] == null || Request.QueryString["type2"] == null)
            {
                Response.Redirect("Classes.aspx");
            }
             
            //store user's details in user object 
            user = (User)Session["loginData"];
            
            //store querry string parameters (passed with the url) in two variables 
            id = Int32.Parse(Request.QueryString["id"]);
            type = Request.QueryString["type2"].ToString();



            
            if (type.Equals("Workshop"))
            {
                s = DBconnection.getWorkshop(id);
                
            }
            else if(type.Equals("Class"))
            {
                s = DBconnection.getClass(id);
                
            }

            
            //check if selected session has any free spaces 
            if (s.Capacity == s.Reservations)
            {
                //if true, ask the user if he wants to be added to thr waiting list
                btn_confirmBooking.Text = "Add to queue";
                BookingMessage.InnerText = "This session is full. Would you like to be added to a waiting list?";
                queue = true;
            }
            else
            {
                queue = false; 
                BookingMessage.InnerText = "Booking confirmation:";
            }


            reservation = new Reservation(id, DateTime.Now, user.Id, s.Title, s.StartDate);

            
            
            
            //set labels 
            Label1.Text = reservation.SessionTitle;
            Label3.Text = reservation.SessionDate.ToShortDateString();
            Label4.Text = reservation.SessionTitle; 
            
            
        }

        protected void btn_confirmBooking_Click(object sender, EventArgs e)
        {

            
            if (queue)
            {
                //add reservation to queue 
                DBconnection.addToQueue(user.Id, s.Id, type);
                Session["message"] = "Thank you. Your reservation will be booked as soon as a space becomes available. ";
            }
            //store details necessary for compling a reservation in r object (Reservation class)
            else if(!queue)
            {
                //add reservation to database 
                DBconnection.reserveSession(reservation, type);


                //increment the number of reservations for particular session
                int updatedReservation = s.Reservations + 1;

                //update number of reservations for particular session
                DBconnection.updateSessionReservation(type, updatedReservation, reservation);

                Session["message"] = "Thank you for booking a session. You can check your booking details in your profile. We are looking forward to see you";
            }
            
            Response.Redirect("Message.aspx");
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Classes.aspx"); 
        }
    }
}