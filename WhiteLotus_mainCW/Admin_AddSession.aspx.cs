using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace WhiteLotus_mainCW
{
    
    public partial class Admin_AddSession : System.Web.UI.Page
    {
         
        List<User> instructors;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //populate ddl_repeatForWks
                for (int i = 0; i <= 20; i++)
                {
                    ddl_repeatWks.Items.Add(i.ToString());
                }

                //populate ddl_timeH
                int h = 00;
                for (int i = 0; i < 24; i++)
                {
                    ddl_timeH.Items.Add(h.ToString("D2"));
                    h++;
                }

                //populate ddl_timeM
                int m = 00;
                for (int i = 0; i <= 59; i++)
                {
                    ddl_timeM.Items.Add(m.ToString("D2"));
                    m++;
                }

                //populate ddl_capacity 
                for (int i = 6; i <= 20; i++)
                {
                    ddl_capacity.Items.Add(i.ToString());
                }

                //populate duration [session]
                for (int i = 60; i <= 90; i= i+10)
                {
                    ddl_duration.Items.Add(i.ToString());
                }
            }
            //get list of instructors to be displayed in ddl_instructors 
            instructors = DBconnection.getInstructorsList();
        }

        protected void ddl_instructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_instructor.Items.Clear();           
            if (ddl_style.SelectedValue.Equals("Anusara"))
            {
                //if user chooses the above style, loop through all instructors
                //and check if they are able to teach this style 

                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i].Anusara == true)
                    {
                        //if instructor is able to teach this style, add to 
                        // the drop down list
                        ddl_instructor.Items.Add(instructors[i].Name);                                               
                    }
                }
            }

            if (ddl_style.SelectedValue.Equals("Bikram"))
            {
                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i].Bikram == true)
                    {
                        ddl_instructor.Items.Add(instructors[i].Name);
                    }
                }
            }


            if (ddl_style.SelectedValue.Equals("Hatha"))
            {
                for (int i = 0; i < instructors.Count; i++)
                {
                    if (instructors[i].Hatha == true)
                    {
                        ddl_instructor.Items.Add(instructors[i].Name);
                    }
                }
            }

            if (ddl_style.SelectedValue.Equals("Select"))
            {
                ddl_instructor.Items.Clear();
                ddl_instructor.Items.Add("Select instructor first");
            }
        }

        protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxCapacity = 0;
            //hide/show controls based on selected session type
            ddl_duration.Items.Clear();
            if (ddl_type.SelectedValue.Equals("Workshop"))
            {
                classSession.Visible = false;
                maxCapacity = 60;
                //populate duration
                for (int i = 120; i <= 240; i = i + 10)
                {
                    ddl_duration.Items.Add(i.ToString());
                }
            }
            else
            {
                classSession.Visible = true;
                maxCapacity = 20;
                //populate duration
                for (int i = 60; i <= 90; i = i + 10)
                {
                    ddl_duration.Items.Add(i.ToString());
                }
            }


            //populate ddl_capacity  each changes session type
            ddl_capacity.Items.Clear();
            
            for (int i = 6; i <= maxCapacity; i++)
            {
                ddl_capacity.Items.Add(i.ToString());
            }
        }
        
        protected void addSession(object sender, EventArgs e)
        {
            string type = ddl_type.SelectedValue;
            string title = txt_title.Text;
            string description = txt_description.Text;
            string style = ddl_style.SelectedValue;
            string level = rdb_level.SelectedValue;
            int capacity = Int32.Parse(ddl_capacity.SelectedValue);
            string room = txt_room.Text;
            DateTime date = myCalendar.SelectedDate;
            
            int repeatWks = Int32.Parse(ddl_repeatWks.SelectedValue);
            TimeSpan time = new TimeSpan( Int32.Parse(ddl_timeH.SelectedValue), Int32.Parse(ddl_timeM.SelectedValue),00);
            
            int duration = Int32.Parse(ddl_duration.SelectedValue);
            int count = 0;
            int instructorID = 0;
            
            //Check if the choosen date is in the future 
            int oldDateCheck = DateTime.Compare(date.Date.Add(time), DateTime.Now);

            if (oldDateCheck <= 0 )
            {
                Response.Write("<script>alert('Choose a date in the future.')</script>");
            }
            else
            {
                try
                {
                    //find the instructor's ID number by looping through instructors name's. 
                    //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                    while (!ddl_instructor.SelectedValue.Equals(instructors[count].Name))
                    {
                        count++;
                    }

                    instructorID = instructors[count].Id;
                }
                catch (ArgumentOutOfRangeException ex)
                {

                    lb_exceptionCatch.Text = "You need to choose default value for all drop down lists.";
                }


                if (ddl_type.SelectedValue.Equals("Class"))
                {
                    Class session = new Class(date, time, style, level, instructorID, duration, capacity, title, description, room, 0, repeatWks);
                    session.schedulesClass();

                    DBconnection.addClass(session);
                }
                else
                {
                    Workshop session = new Workshop(date, time, style, level, instructorID, duration, capacity, title, description, room, 0);

                    DBconnection.addWorkshop(session);
                }

                clearControls();
                Response.Write("<script>alert('Your session has been added to the database.')</script>");
            }
            
            
        }//end of add session

       
        
        private void clearControls()
        {
            ddl_type.SelectedIndex = 0;
            txt_title.Text = "";
            txt_description.Text = "";
            ddl_style.SelectedIndex = 0;
            rdb_level.SelectedIndex = 0;
            ddl_instructor.SelectedIndex = 0;
            ddl_capacity.SelectedIndex = 0;
            txt_room.Text = "";
            myCalendar.SelectedDate = DateTime.Now;
            ddl_repeatWks.SelectedIndex = 0;
            ddl_timeH.SelectedIndex = 0;
            ddl_timeM.SelectedIndex = 0;
            ddl_duration.SelectedIndex = 0; 

        }

    }
}