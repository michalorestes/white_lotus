using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class Admin_ForumManagement : System.Web.UI.Page
    {
        List<Forum> data;
        protected void Page_Load(object sender, EventArgs e)
        {
            data = DBconnection.getForumCategories();

            if (!IsPostBack)
            {
                refreshCategoriesList();
            }
            

            //ListBox1.DataSource = data;
            //ListBox1.DataTextField = "Title";
            //ListBox1.DataValueField = "CategoryID";

            
            
            
        }

        protected void btn_addCategory_Click(object sender, EventArgs e)
        {
            DBconnection.addForumCategory(txt_categoryTitle.Text, txt_description.Text);
            Response.Redirect(Request.RawUrl); 
        }

        protected void btn_deleteCategory_Click(object sender, EventArgs e)
        {
            
           
           DBconnection.deleteForumCategory(Int32.Parse(ListBox1.SelectedValue));
            refreshCategoriesList();
            Response.Redirect(Request.RawUrl);
        }


        private void refreshCategoriesList()
        {
            ListBox1.Items.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                ListBox1.Items.Add(new ListItem(data[i].Title, data[i].CategoryID.ToString()));
            }

            
        }
       
    }
}


// http://www.telerik.com/forums/programmatically-selecting-items-by-value-in-listbox