using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        User u;
        protected void Page_Load(object sender, EventArgs e)
        {

            //POSSIBLE CLEAN UP - CREATE A NEW CLASS WITH THE FOLLOWING METHOD 
            if (Session["loginData"] != null)
            {
                u = (User)Session["loginData"];

                if (u.Admin.Equals("admin") == false && u.Admin.Equals("Instructor") == false)
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            
        }
    }
}