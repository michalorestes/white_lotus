using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace WhiteLotus_mainCW
{
    public partial class ForumCategories : System.Web.UI.Page
    {
        List<Forum> categories;
        protected void Page_Load(object sender, EventArgs e)
        {
            categories = DBconnection.getForumCategories();

            
            displayCategories(categories);

        }

        private void displayCategories(List<Forum> c)
        {
            for (int i = 0; i < c.Count; i++)
            {
                HtmlTableRow tr = new HtmlTableRow();

                HtmlTableCell td_IMG = new HtmlTableCell();
                HtmlGenericControl img = new HtmlGenericControl("img");
                img.Attributes.Add("src", "images/forumCategories.png");
                td_IMG.Controls.Add(img);

                HtmlTableCell td_title = new HtmlTableCell();
                HtmlGenericControl a = new HtmlGenericControl("a");
                a.Attributes.Add("href", "ForumPosts.aspx?catID=" +c[i].CategoryID + "&catTitle=" + c[i].Title);
                a.InnerHtml = c[i].Title + " <br />";
                td_title.Controls.Add(a);
                HtmlGenericControl span = new HtmlGenericControl("span");
                span.Attributes.Add("class", "desc");
                span.InnerText = c[i].Text;
                td_title.Controls.Add(span);

                HtmlTableCell td_posts = new HtmlTableCell();
                td_posts.InnerHtml = DBconnection.getNumberOfRecords("ForumPosts", "CategoryID_FK", c[i].CategoryID) +" Posts";

                HtmlTableCell td_Messages = new HtmlTableCell();
                td_Messages.InnerHtml = DBconnection.getNumberOfRecords("CategoryID_FK", c[i].CategoryID) + " Messages";

                tr.Controls.Add(td_IMG);
                tr.Controls.Add(td_title);
                tr.Controls.Add(td_posts);
                tr.Controls.Add(td_Messages);
                
                
                
                ForumCategoriesTable.Controls.Add(tr); 
            }

        }




    }
}