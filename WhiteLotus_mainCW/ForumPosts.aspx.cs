using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class ForumPosts : System.Web.UI.Page
    {
        int catID;
        protected void Page_Load(object sender, EventArgs e)
        {
            catID = Int32.Parse(Request.QueryString["catID"]);
            displayPosts(DBconnection.getForumPosts(catID));


            //HtmlGenericControl forumLink = new HtmlGenericControl("a");
            //forumLink.Attributes.Add("href", "ForumCategories.aspx");
            //forumLink.InnerText = "Forum > ";
            //forumPath.Controls.Add(forumLink);

            //HtmlGenericControl catLink = new HtmlGenericControl("a");
            
            //forumLink.InnerText = Request.QueryString["catTitle"];
            //forumPath.Controls.Add(forumLink);

        }


        private void displayPosts(List<Forum> p)
        {
            catID = Int32.Parse(Request.QueryString["catID"]);
            for (int i = 0; i < p.Count; i++)
            {

                HtmlTableRow tr = new HtmlTableRow();
                ForumCategoriesTable.Controls.Add(tr);

                HtmlTableCell td_IMG = new HtmlTableCell();
                HtmlGenericControl img = new HtmlGenericControl("img");
                img.Attributes.Add("src", "images/forumPosts.png");
                td_IMG.Controls.Add(img);

                HtmlTableCell td_title = new HtmlTableCell();
                HtmlGenericControl a = new HtmlGenericControl("a");
                a.Attributes.Add("href", "ForumMessages.aspx?catID=" + p[i].CategoryID + "&postID=" + p[i].PostID);
                a.InnerHtml = p[i].Title + " <br />";
                td_title.Controls.Add(a);
                HtmlGenericControl span = new HtmlGenericControl("span");
                span.Attributes.Add("class", "desc");
                User user = DBconnection.getUser(p[i].UserID);
                span.InnerText = user.Name;
                td_title.Controls.Add(span);

                HtmlTableCell td_Messages = new HtmlTableCell();
                td_Messages.InnerHtml =  DBconnection.getNumberOfRecords("PostID_FK", p[i].PostID) + " Messages";

                tr.Controls.Add(td_IMG);
                tr.Controls.Add(td_title);
                tr.Controls.Add(td_Messages);
            }
        }

        protected void btn_newPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForumNewPost.aspx?catID=" + catID);
        }
    }
}