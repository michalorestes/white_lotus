using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WhiteLotus_mainCW
{
    public partial class ContactUs : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            XDocument doc = XDocument.Load(@"C:\Users\Jeremi\Google Drive\Uni\Application & Web Development\Coursework\WhiteLotus_mainCW\WhiteLotus_mainCW\XMLContact.xml");
            var info = from i in doc.Descendants("contact")
                       select i;
            XElement element = info.ElementAt(0);
            lb_name.Text = element.Element("name").Value;
            lb_phone.Text = element.Element("phone").Value;
            lb_email.Text = element.Element("email").Value;
            TextBox1.Text = element.Element("address").Value;
            string postCode = element.Element("map").Value;




            //adopted from: https://developers.google.com/maps/documentation/embed/start 
            map.InnerHtml = "<iframe width='600' height='450' frameborder='0' style='border: 0' src='https://www.google.com/maps/embed/v1/place?q="+ postCode + "&key=AIzaSyDlLMRWz-l6c1IZZGtXhJZX4_f31_n825M' allowfullscreen></iframe> ";
        }
    }
}
