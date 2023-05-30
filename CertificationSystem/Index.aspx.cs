using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using BAL;
using DAL;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CertificationSystem
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //{
            //    int studentNo = 0;
            //    if (HttpContext.Current.Session["StudentNo"] != null)
            //    {
            //        // Retrieve the session value as an object
            //        object sessionValue = HttpContext.Current.Session["StudentNo"];
            //        int FinalValue = Convert.ToInt32(sessionValue);
            //        // Attempt to cast the session value to an integer
            //        if (FinalValue != 0)
            //        {
            //            studentNo = (int)FinalValue;
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("Login.aspx");
            //    }



            //}
        }

    }
}