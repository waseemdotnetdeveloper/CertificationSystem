using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CertificationSystem
{
    public partial class CertificationSystem : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            if(btnLogOut.Text == "LogOut")
            {
                Session.Abandon(); // Terminate the current session
                Response.Redirect("Login.aspx");
            }
        }
    }
}