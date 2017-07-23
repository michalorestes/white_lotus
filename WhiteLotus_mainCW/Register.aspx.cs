using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Reegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          //register a new user 
            if (chb_terms.Checked == true)
            {
                string name = txt_name.Text;
                string dob = txt_dobDay.Text + "/" + txt_dobMonth.Text + "/" + txt_dobYear.Text;
                string experience = ddl_yogaExperience.SelectedValue;
                string health = txt_healthIssues.Text;
                string email = txt_email.Text;
                string password = txt_password.Text;
                string passwordConfirm = txt_passwordConfirm.Text;
                long tel = long.Parse(txt_telNo.Text);

                if (password.Equals(passwordConfirm))
                {
                    User u = new User(name, dob, experience, health, email, tel, password, "Client");
                    DBconnection.addUser(u);
                    System.Web.HttpContext.Current.Response.Write("<script>alert('Thank you for your registration! You can now login.')</script>");
                    clearFields();
                    Response.AddHeader("REFRESH", "1;URL=Default.aspx");
                }
                else
                {
                    Label2.Text = "Passwords do not match!";
                }              
            }
            else
            {
                Label2.Text = "You must accept terms and conditions in order to register. :P ";
            }            
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }



        private void clearFields()
        {
            txt_name.Text = "";
            txt_dobDay.Text = "";
            txt_dobMonth.Text = "";
            txt_dobYear.Text = "";
            txt_healthIssues.Text = "";
            txt_email.Text = "";
            txt_password.Text = "";
            txt_passwordConfirm.Text = "";
            txt_telNo.Text = "";
            ddl_yogaExperience.SelectedIndex = 0;
        }
    }
}