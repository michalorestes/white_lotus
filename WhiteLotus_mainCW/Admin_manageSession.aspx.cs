using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Admin_manageSession : System.Web.UI.Page
    {
        
        //declare a datatable instance variable 
        DataTable dt;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //read data from the database and bind it to a grid view
            //when the page is loaded for the first time 
            if (!this.IsPostBack)
            {
                dt = DBconnection.getSessionsAdmin("Class");            //get a list of all sessions from the database 
                string[] dataKey = { "SessionID" };                     //string array containing data key column names 
                GridView1.DataKeyNames = dataKey;                       //set SessionID column as a data key for the gridview 
                GridView1.DataSource = dt;                              //set a DataTable returned by DBConnection class as a data source for grid view 
                GridView1.DataBind();                                   //match columns from the DataTable to grid view columns (declared in source view)
            }
        }

        //choose to display either workshops or classes
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when the index of the drop down list change, update gridview accordingly to chosen value 
            dt = DBconnection.getSessionsAdmin(DropDownList1.SelectedValue);
            string[] dataKey = { "SessionID" };
            GridView1.DataKeyNames = dataKey;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

       
        //refresh the grid view 
        private void refreshTable()
        {
            
            dt = DBconnection.getSessionsAdmin(DropDownList1.SelectedValue);
            string[] dataKey = { "SessionID" };
            GridView1.DataKeyNames = dataKey;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

       
        //store selected value (SessionID data key for session in selected row)
        //each time the even changes
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Session["selectedRow"] = GridView1.SelectedValue.ToString();
            
        }

        protected void btn_deleteRecord_Click(object sender, EventArgs e)
        {
            //check if a session has been selected before proceeding 
            if (Session["selectedRow"] == null)
            {
                HttpContext.Current.Response.Write("<script>alert('Please select a session to be deleted first!')</script>");
            }
            else
            {
                //delete a record from a database based on the session type (class, workshop") and sessionID 
                DBconnection.deleteRecord(DropDownList1.SelectedValue, Int32.Parse(Session["selectedRow"].ToString()), "ID");
                //remove all queues assosiated with this session
                DBconnection.removeQueue(Int32.Parse(Session["selectedRow"].ToString()), "SessionID");
                //delete all reservations assosiated with this session 
                DBconnection.deleteRecord("Reservation", Int32.Parse(Session["selectedRow"].ToString()), DropDownList1.SelectedValue+"ID");    
                GridView1.SelectedIndex = -1;       //clear grid view selection
                Session["selectedRow"] = null;      // clear selectedRow session's data
                refreshTable();
                
                HttpContext.Current.Response.Write("<script>alert('Session has been deleted.')</script>");  //show javascript confirmation window
            }
            
            
        }

        protected void btn_addSession_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_AddSession.aspx");
        }

        //change session's status 
        protected void btn_status_Click(object sender, EventArgs e)
        {
            //check if a session has been selected before proceeding 
            if (Session["selectedRow"] == null)
            {
                HttpContext.Current.Response.Write("<script>alert('Please select a session to be modyfied first!')</script>");  //error message 
            }
            else
            {
                //get the current status of a selected session from the database 
                string currentStatus = DBconnection.getStatus(Session["selectedRow"].ToString(), DropDownList1.SelectedValue);
                string updatedStatus = "something went wrong";  

                //set status to the opposite [Active = Cancelled/Cancelled = Active]
                if (currentStatus.Equals("Active"))
                {
                    updatedStatus = "Cancelled"; 
                }
                else if (currentStatus.Equals("Cancelled"))
                {
                    updatedStatus = "Active";
                }
                else
                {
                    return;
                }
                //update status in the database 
                DBconnection.changeStatus(DropDownList1.SelectedValue, updatedStatus, Session["selectedRow"].ToString()); 

                //clear gridview selection and reset data
                GridView1.SelectedIndex = -1;
                Session["selectedRow"] = null;
                refreshTable();
                HttpContext.Current.Response.Write("<script>alert('Session has been set to " + updatedStatus + ".')</script>"); //conrimation message 
            }
        }
    }
}