using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class ForumNewPost : System.Web.UI.Page
    {
        User user;
        int catID;
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if user is logged in
            if (Session["loginData"] == null)
            {
                Session["message"] = "You must be logged in, in order to post on forum.";
                Response.Redirect("Message.aspx");
            }

            //load user's data 
            user = (User)Session["loginData"];
            catID = Int32.Parse(Request.QueryString["catID"]);      //get categoryID for the choosen category
           
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //create a new Forum objet, then pass it as a parameter in order to add post title to the database 
            Forum post = new Forum(catID, TextBox1.Text, DateTime.Now, user.Id);
            DBconnection.addForumNewPost(post);

            post.Text = TextBox2.Text;
            post.PostID = DBconnection.lastPK("ID", "ForumPosts");

            //add the message assosiated with this post 
            DBconnection.addForumMessage(post);

            HttpContext.Current.Response.Write("<script>alert('Your post has been added')</script>");

            //redirect the user to his message 
            Response.Redirect("ForumMessages.aspx?catID=" + post.CategoryID + "&postID=" + post.PostID);


            


        }
    }
}