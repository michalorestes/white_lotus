using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Admin_Instructors : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = DBconnection.getInstructorsDetailsDT();
                string[] dataKey = { "ID" };
                GridView2.DataKeyNames = dataKey;
                GridView2.DataSource = dt;
                GridView2.DataBind();               
            }
        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Label2.Text = GridView2.SelectedValue.ToString();
        }

        protected void btn_addInstructor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_addInstructor.aspx");
        }
    }

        
}