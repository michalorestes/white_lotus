using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Admin_addInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btn_register_Click(object sender, EventArgs e)
        {
            
            string name = txt_name.Text;
            string dob = txt_dobDay.Text + "/" + txt_dobMonth.Text + "/" + txt_dobYear.Text;
            string health = txt_healthIssues.Text;
            string email = txt_email.Text;
            string password = txt_password.Text;
            bool anusara = chb_Anusara.Checked;
            bool bikram = chb_Bikram.Checked;
            bool hatha = chb_Hatha.Checked;            
            string passwordConfirm = txt_passwordConfirm.Text;
            long tel = long.Parse(txt_telNo.Text);

            if (password.Equals(passwordConfirm))
            {
                User u = new User(name, dob, "Instructor", health, anusara, bikram, hatha, email, tel, password, "Instructor");
                DBconnection.addUser(u);
                clearFields();
                HttpContext.Current.Response.Write("<script>alert('Instructor " + u.Name +  " has been added. ')</script>");
            }
            else
            {
                Label2.Text = "Passwords do not match!";
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
            chb_Anusara.Checked = false;
            chb_Bikram.Checked = false;
            chb_Hatha.Checked = false;
        }
    }
}