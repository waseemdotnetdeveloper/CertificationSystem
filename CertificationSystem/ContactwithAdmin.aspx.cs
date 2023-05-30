using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BAL;
using DAL;

namespace CertificationSystem.Contact
{
    public partial class ContactwithAdmin : System.Web.UI.Page
    {
        string ex;

        protected void Page_Load(object sender, EventArgs e)
        {
         if(!Page.IsPostBack)
            {
              //  clearcontrol();
              if(Nametxtbox.Text!=null || emailtxtbox!=null || subjecttxtbox.Text!=null || messageBox.Text!=null)
                {
                    Nametxtbox.Text = string.Empty;
                    emailtxtbox.Text = string.Empty;
                    subjecttxtbox.Text = string.Empty;
                    messageBox.Text = string.Empty; 
                }
            }
        }
        public bool paramter()
        {

            Regex patternforString = new Regex(@"^[A-Za-z]+$"); ;
            Regex patternforemail = new Regex (@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            // bool isValidEmail = Regex.IsMatch(email, pattern);
            try
            {
                //string result;
                //result = Nametxtbox.Text + " " + emailtxtbox.Text + " " + subjecttxtbox.Text;
                if (Nametxtbox.Text != null && emailtxtbox.Text != null && subjecttxtbox.Text != null)
                {
                    if (patternforString.IsMatch(Nametxtbox.Text) && patternforemail.IsMatch(emailtxtbox.Text) && patternforString.IsMatch(subjecttxtbox.Text))
                    {
                       
                       // return emailtxtbox.Text.Trim().Length > 0;
                      return true;
                    }
                    else
                    {
                        dvMessage.ShowMessage("Dear User, Please Enter your Valid Details ", Extension.MessageType.Error);
                        // ex.ExceptionLog("ContactwithAdmin.aspx", "ValidateName", DateTime.Now.ToString());
                        return false;
                    }
                }
                else
                {
                    dvMessage.ShowMessage("Dear User, Please didn't Enter empty details.", Extension.MessageType.Error);
                    return false;
                }
              
            }
            catch (Exception ex)
            {
                dvMessage.ShowMessage("You Must Enter a Valid Information", Extension.MessageType.Error);
                ex.ExceptionLog("ContactwithAdmin.aspx", "Parameter", DateTime.Now.ToString());
                return false;
            }
        }

        protected void contactbutton_Click(object sender, EventArgs e)
        {

           
            try
            {
                if (Nametxtbox.Text == "" || emailtxtbox.Text == "" || subjecttxtbox.Text == "" ||
       messageBox.Text == "")
                {
                    dvMessage.ShowMessage("Please Enter all Fields", Extension.MessageType.Error);
                    

                }
                else
                {
                    string yourame = Nametxtbox.Text;
                    string youremail = emailtxtbox.Text;
                    string subject = subjecttxtbox.Text;
                    string message = messageBox.Text;
                    bool result = paramter();
                   if(result)
                    {
                        
                   int ticketid =Contactus.insertcontactdetails(yourame, youremail, subject, message);
                        
                      //  Ticketid = BAL.Contactus.GetTickedId();
                        clearcontrol();
                        dvMessage.ShowMessage("Your Response is Submit to Administrator and your response Id is : " + ticketid , Extension.MessageType.Success);

                    }


                }



            }
            catch (Exception ex) 
            {
                dvMessage.ShowDefaultErrorMessage(ex);
                ex.ExceptionLog("ContactwithAdmin.aspx", "Save", DateTime.Now.ToString());
            }
        }

        public void clearcontrol()
        {
            Nametxtbox.Text = "";
            emailtxtbox.Text = "";
            subjecttxtbox.Text = "";
            messageBox.Text = "";

        }
    }
}