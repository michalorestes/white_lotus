using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls; 


namespace WhiteLotus_mainCW
{
    public partial class UerPanel_Reservations : System.Web.UI.Page
    {
        
        User userData;
        List<Reservation> reservationsList; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginData"] != null)
            {
                userData = (User)Session["loginData"];
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            
            
            reservationsList = DBconnection.getClassReservations(userData.Id, "Class");

            displayReservations(reservationsList);

            reservationsList = DBconnection.getClassReservations(userData.Id, "Workshop");
            displayReservations(reservationsList);

            displayWaitingLists(DBconnection.viewUserQueues(userData.Id));

        }


        private void displayReservations(List<Reservation> r)
        {
            for (int i = 0; i < r.Count ; i++)
            {
                HtmlTableRow tr = new HtmlTableRow();
                userReservationTable.Controls.Add(tr);

                HtmlTableCell tdReservationDate = new HtmlTableCell();
                tdReservationDate.InnerText = r[i].ReservationDate.ToString();
                tr.Controls.Add(tdReservationDate);

                HtmlTableCell tdType = new HtmlTableCell();
                tdType.InnerText = r[i].SessionType;
                tr.Controls.Add(tdType);

                HtmlTableCell tdTitle = new HtmlTableCell();
                tdTitle.InnerText = r[i].SessionTitle;
                tr.Controls.Add(tdTitle);

                HtmlTableCell tdSessionDate = new HtmlTableCell();
                tdSessionDate.InnerText = r[i].SessionDate.ToShortDateString() + " "+ r[i].Time;
                tr.Controls.Add(tdSessionDate);

                HtmlTableCell tdStatus = new HtmlTableCell();
                tdStatus.InnerText = r[i].SessionStatus;
                tr.Controls.Add(tdStatus);

                HtmlTableCell tdAction = new HtmlTableCell();
                int datesCompare = DateTime.Compare(r[i].SessionDate.Date, DateTime.Now.Date);
                string aHref = "";
                if (r[i].SessionStatus.Equals("Cancelled"))
                {
                    aHref = "Session Cancelled";
                }
                else if(datesCompare < 0)
                {
                    aHref = "Session passed";
                }
                else
                {
                    aHref = "<a href='UserPanel_CancelReservation.aspx?id=" + r[i].ReservationID + "&type=" + r[i].SessionType +"'>Cancel reservation</a>";
                }


                tdAction.InnerHtml = aHref;
                tr.Controls.Add(tdAction);
            }
            
        }

        private void displayWaitingLists(List<Queue> queues)
        {
           

            for (int i = 0; i < queues.Count; i++)
            {
                Session session;
                if (queues[i].SessionType.Equals("Workshop"))
                {
                    session = DBconnection.getWorkshop(queues[i].SessionID);
                }
                else
                {
                    session = DBconnection.getClass(queues[i].SessionID);
                }

                //container div holding each item
                HtmlGenericControl div = new HtmlGenericControl("div");
                listOfreservations.Controls.Add(div);
                
                //unordered list
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                div.Controls.Add(ul);
                
                //list item displaying session title and cancel button 
                HtmlGenericControl li1 = new HtmlGenericControl("li");
                li1.InnerHtml = "<a href='Message.aspx?cnlQ="+ queues[i].Id + "' onclick=\"return confirm('Are you sure you want to delete?')\" ><img src='/images/cancel_btn.png' /></a> <span>" + session.Title +"</span> ";
                
                HtmlGenericControl li2 = new HtmlGenericControl("li");
                li2.InnerText = "On: " + session.StartDate.Add(session.Time);

                List<Queue> temp = DBconnection.viewSessionQueue(queues[i].SessionID, queues[i].SessionType);
                int waitingNo = 0;

                for (int j = 0; j < temp.Count; j++)
                {
                    temp[j].WaitingNumber = j+1;

                    if (temp[j].UserID == userData.Id)
                    {
                        queues[i].WaitingNumber = temp[j].WaitingNumber;
                    }

                }






                HtmlGenericControl li3 = new HtmlGenericControl("li");
                li3.InnerText = queues[i].WaitingNumber + " on waiting list";
                
                ul.Controls.Add(li1);
                ul.Controls.Add(li2);
                ul.Controls.Add(li3);
            }
            





        }


    }
}