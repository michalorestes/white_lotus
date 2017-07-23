using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WhiteLotus_mainCW
{
    public partial class Contact : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //load a xml document 
            XDocument doc = XDocument.Load(@"C:\Users\Jeremi\Google Drive\Uni\Application & Web Development\Coursework\WhiteLotus_mainCW\WhiteLotus_mainCW\XMLContact.xml");
            //querry the xml document using Linkq. The following querry selects all elements that belong to node "contact" and returns its IEnumerator to info variable 
            //each contact node would be placed in different index 
            var info = from i in doc.Descendants("contact")
                       select i;

            

            //load contact with the index of 0 
           XElement element = info.ElementAt(0);
           // element.SetElementValue("name", "saras");
          //  doc.Save(@"C:\Users\Jeremi\Google Drive\Uni\Application & Web Development\Coursework\WhiteLotus_mainCW\WhiteLotus_mainCW\XMLContact.xml");

            //display each contact's element on a label 
            lb_name.Text = element.Element("name").Value;
            lb_phone.Text = element.Element("phone").Value;
            lb_email.Text = element.Element("email").Value;
            TextBox1.Text = element.Element("address").Value;
            Label2.Text = element.Element("map").Value;     
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(@"C:\Users\Jeremi\Google Drive\Uni\Application & Web Development\Coursework\WhiteLotus_mainCW\WhiteLotus_mainCW\XMLContact.xml");
            var info = from i in doc.Descendants("contact")
                       select i;

            XElement element = info.ElementAt(0);

            //the following code checks if the textboxes are empty
            //if true, update specyfic element inside a xml document, if false skip
            
            if (!txt_name.Text.Equals(""))
            {
                element.Element("name").Value = txt_name.Text;
            }

            if (!txt_phone.Text.Equals(""))
            {
                element.Element("phone").Value = txt_phone.Text;
            }

            if (!txt_email.Text.Equals(""))
            {
                element.Element("email").Value = txt_email.Text;
            }

            if (!txt_address.Text.Equals(""))
            {
                element.Element("address").Value = txt_address.Text;
            }

            //check if there are any spaces in postcode field 
            if (!TextBox2.Text.Contains(" "))
            {
                if (!TextBox2.Text.Equals(""))
                {
                    element.Element("map").Value = TextBox2.Text;
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('No spaces allowed for the postcode field')</script>");

            }




            //save changes made to the xml document 
            doc.Save(@"C:\Users\Jeremi\Google Drive\Uni\Application & Web Development\Coursework\WhiteLotus_mainCW\WhiteLotus_mainCW\XMLContact.xml");

            Response.AddHeader("REFRESH", "1;URL=Admin_Contact.aspx");
        }
    }
}