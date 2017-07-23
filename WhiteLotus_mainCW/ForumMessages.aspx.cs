using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WhiteLotus_mainCW
{
    public partial class ForumMessages : System.Web.UI.Page
    {
        User user;
        int postID;
        int catID; 
        protected void Page_Load(object sender, EventArgs e)
        {
            postID = Int32.Parse(Request.QueryString["postID"]);
            catID = Int32.Parse(Request.QueryString["catID"]);
            displayMessages(DBconnection.getForumMessages(postID));
        }



        private void displayMessages(List<Forum> m)
        {
            for (int i = 0; i < m.Count; i++)
            {
                HtmlTableRow tr = new HtmlTableRow();
                ForumTableMessages.Controls.Add(tr);

                HtmlTableCell td_UserInfo = new HtmlTableCell();
                tr.Controls.Add(td_UserInfo);
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                td_UserInfo.Controls.Add(ul);
                HtmlGenericControl li1 = new HtmlGenericControl("li");
                user = DBconnection.getUser(m[i].UserID);
                li1.InnerText = user.Name;
                ul.Controls.Add(li1);

                HtmlGenericControl li2 = new HtmlGenericControl("li");
                li2.InnerText = user.Experience;
                ul.Controls.Add(li2);

                HtmlTableCell td_Message = new HtmlTableCell();
                tr.Controls.Add(td_Message);

                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerHtml = m[i].Text;
                td_Message.Controls.Add(p);

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = m[i].Date.ToString();
                td_Message.Controls.Add(div);
            }
            



        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }

        protected void btn_reply_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text.Equals(""))
            {
                HttpContext.Current.Response.Write("<script>alert('Your message can not be empty')</script>");

            }
            else
            {
                if (Session["loginData"] != null)
                {
                    user = (User)Session["loginData"];

                    Forum f = new Forum();
                    f.CategoryID = catID;
                    f.PostID = postID;
                    f.Text = TextBox1.Text;
                    f.UserID = user.Id;
                    f.Date = DateTime.Now;

                    DBconnection.addForumMessage(f);

                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('You must be logged in, in order to post messages on forum.')</script>");
                }
            }

            
            

        }
    }
}