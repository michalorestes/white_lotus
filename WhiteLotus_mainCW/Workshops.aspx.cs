using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Workshops : System.Web.UI.Page
    {
        
        List<Workshop> sessions;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //if the page is loaded for the first time, read all sessions from the database and display them
            if (!Page.IsPostBack)
            {
                sessions = DBconnection.getWorkshops(true, DateTime.Now.Date);
                displaySessions(sessions);
            }
            //clear the delected date every time the page loads 
            Calendar1.SelectedDates.Clear();
        }



        private void displaySessions(List<Workshop> s)
        {
            Random random = new Random();

            //if there are no classes in the database show error message               
            if (s.Count == 0)
            {
                //create a generic html control (paragraph <p>)
                HtmlGenericControl error = new HtmlGenericControl("p");
                //insert the content of a paragraph (<p>CONTENT</p>)
                error.InnerHtml = "<h2>Unfortunately, we do not  have any sessions on selected day";
                //add the html control to a div container with an ID of "extraThing" :) 
                extraThing.Controls.Add(error);
            }
            else
            {
                for (int i = 0; i < s.Count; i++)
                {
                    //create a HTML table row using HTML controlls and add it to 
                    //the table with ID of "sessionTable"
                    HtmlTableRow tr = new HtmlTableRow();
                    sessionsTable.Controls.Add(tr);

                    //create a table cell/column
                    HtmlTableCell td1 = new HtmlTableCell();
                    //add this table cell to a table row 
                    tr.Controls.Add(td1);
                    //create a generic <img> html tag 
                    HtmlGenericControl img = new HtmlGenericControl("img");
                    //give src attribute to the img tag and assign a path to it
                    //this path contains a random number that randomly chooses image for each session
                    img.Attributes.Add("src", "images/" + random.Next(1, 6) + ".jpg");
                    //add image to the table cell
                    td1.Controls.Add(img);

                    //tile & description column 
                    HtmlTableCell td2 = new HtmlTableCell();
                    tr.Controls.Add(td2);
                    HtmlGenericControl title = new HtmlGenericControl("a");
                    title.InnerHtml = "<h2>" + s[i].Title + "</h2>";
                    //pass the session type and session ID to querry string
                    //querry string with these information will be used on ReservationPage.aspx page 
                    title.Attributes.Add("href", "ReservationPage.aspx?id=" + s[i].Id + "&type2=Workshop");
                    td2.Controls.Add(title);
                    HtmlGenericControl description = new HtmlGenericControl("p");
                    description.InnerText = s[i].Description;
                    td2.Controls.Add(description);

                    //Additional information column
                    HtmlTableCell td3 = new HtmlTableCell();
                    tr.Controls.Add(td3);
                    //create a html unordered list and populate it with list elements 
                    HtmlGenericControl ul = new HtmlGenericControl("ul");
                    td3.Controls.Add(ul);
                    HtmlGenericControl li1 = new HtmlGenericControl("li");                                  //date and time 
                    ul.Controls.Add(li1);
                    li1.InnerText = s[i].StartDate.ToShortDateString() + " at " + s[i].Time.ToString(@"hh\:mm");
                    HtmlGenericControl li2 = new HtmlGenericControl("li");                                  //level 
                    ul.Controls.Add(li2);
                    li2.InnerText = s[i].Level;
                    HtmlGenericControl li3 = new HtmlGenericControl("li");                                  //duration
                    ul.Controls.Add(li3);
                    li3.InnerText = "Duration: " + s[i].Duration.ToString() + " min";
                    HtmlGenericControl li4 = new HtmlGenericControl("li");                                  //available spaces
                    ul.Controls.Add(li4);
                    li4.InnerText = "Available: " + (s[i].Capacity - s[i].Reservations).ToString();
                    HtmlGenericControl li5 = new HtmlGenericControl("li");                                  //sessions status
                    ul.Controls.Add(li5);
                    li5.InnerText = s[i].Status;

                    HtmlGenericControl li6 = new HtmlGenericControl("li");
                    ul.Controls.Add(li6);
                    li6.InnerText = "With " + DBconnection.getUser(s[i].InstructorID).Name;


                    //book column
                    //contains a link to ReservationPage with parameters for querry string 
                    HtmlTableCell book = new HtmlTableCell();
                    tr.Controls.Add(book);
                    HtmlGenericControl link = new HtmlGenericControl("a");

                    if (s[i].Status.Equals("Cancelled"))
                    {
                        book.Controls.Add(link);
                        link.Attributes.Add("class", "bookLink");
                        link.Attributes.Add("href", "#");
                        link.InnerText = "Session cancelled";
                    }
                    else
                    {
                        book.Controls.Add(link);
                        link.Attributes.Add("class", "bookLink");
                        link.Attributes.Add("href", "ReservationPage.aspx?id=" + s[i].Id + "&type2=Workshop");
                        link.InnerText = "Book";
                    }
                }
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //passing selected date to the getClassess functions
            //more information in DBConnection class
            sessions = DBconnection.getWorkshops(false, Calendar1.SelectedDate.Date);
            displaySessions(sessions);
        }

        protected void btn_showAll_Click(object sender, EventArgs e)
        {
            //get new data from the database and display it to the user 
            //more information about the function used below in DBConnection class
            sessions = DBconnection.getWorkshops(true, DateTime.Now.Date);
            //display sessions 
            displaySessions(sessions);
        }
    }
}