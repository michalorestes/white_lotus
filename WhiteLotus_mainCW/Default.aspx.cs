/*

LIST OF USED SESSION IN THE APPLICATION 

"loginData" = User class 

*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhiteLotus_mainCW
{
    public partial class WebForm1 : System.Web.UI.Page
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

            Request.QueryString["cnlQ"] = "0";
        }
    }
}