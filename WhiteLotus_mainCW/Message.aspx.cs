using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class LoginErrorMEssage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //source http://stackoverflow.com/questions/21280071/clear-or-remove-query-string-in-asp-net
            //make querry string editable in order to clear their value 
            PropertyInfo isreadonly =
  
                typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                    "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            // make collection editable
            isreadonly.SetValue(this.Request.QueryString, false, null);
            
            

            

            //if a queue has been selected, delete its record from a database 
            

            if ( Request.QueryString["cnlQ"] != null)
            {
                int qID = Int32.Parse(Request.QueryString["cnlQ"]);
                DBconnection.removeQueue(qID, "ID");

                Session["message"] = "Your queue has been cancelled. ";
            }

            Label1.Text = Session["message"].ToString();




            this.Request.QueryString.Remove("id");
                

            
        }

        

        
    }
}