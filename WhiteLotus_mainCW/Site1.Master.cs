using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        User u;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (Session["loginData"] != null)
            {
                u = (User)Session["loginData"];
                loggedIn.Visible = true;
                loginPanel.Visible = false;

                Label1.Text = u.Name;


                if (u.Admin.Equals("admin") || u.Admin.Equals("Instructor"))
                {
                    loggedIn_adminPanel.Visible = true;
                }
                else
                {
                    loggedIn_adminPanel.Visible = false;
                }

            }
            else
            {
                loggedIn.Visible = false;
                loginPanel.Visible = true;
            }



        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
           
            string loginEmail = txt_email.Text;
            string loginPassword = txt_password.Text;

            string confirmPassword = DBconnection.getPassword(loginEmail);

            if (loginPassword.Equals(confirmPassword))
            {
                
                Session["loginData"] = DBconnection.getUser(loginEmail);
                Response.Write("<script>alert('You are logged in')</script>");
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Response.Write("<script>alert('Details do not match.')</script>");
            }
 
        }

      

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('You are loggedout. Have a nice day.')</script>");
            Session.RemoveAll();
            
            Response.Redirect("Default.aspx");
            
        }




    }
}