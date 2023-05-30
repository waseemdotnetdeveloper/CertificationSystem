using System;
using System.Text.RegularExpressions;
using System.Web;


namespace CertificationSystem.App_Code
{
    public static class Extension
    {
        public static void ShowMessage(this System.Web.UI.HtmlControls.HtmlGenericControl control, string message, MessageType messageType, bool includeHeader = true)
        {
            // Int64 UserID;

            control.Attributes.Remove("class");
            control.Visible = true;
            control.InnerHtml = " <button class=\"close\" aria-hidden=\"true\" type=\"button\" data-dismiss=\"alert\">×</button> ";

            switch (messageType)
            {
                case MessageType.Error:
                    control.Attributes.Add("class", "alert bg-danger alert-danger alert-dismissible");
                    control.InnerHtml += (includeHeader ? "<h4><i class=\"icon fa fa-ban\" ></i> Alert!</h4>" : String.Empty) + message;
                    break;
                case MessageType.Information:
                    control.Attributes.Add("class", "alert bg-info alert-info alert-dismissible");
                    control.InnerHtml += (includeHeader ? "<h4><i class=\"icon fa fa-info\" ></i> Alert!</h4>" : String.Empty) + message;
                    break;
                case MessageType.Success:
                    control.Attributes.Add("class", "alert bg-success alert-success alert-dismissible");
                    control.InnerHtml += (includeHeader ? "<h4><i class=\"icon fa fa-check\" ></i> Success</h4>" : String.Empty) + message;
                    break;
                case MessageType.Warning:
                    control.Attributes.Add("class", "alert bg-warning alert-warning alert-dismissible");
                    control.InnerHtml += (includeHeader ? "<h4><i class=\"icon fa fa-warning\" ></i> Alert!</h4>" : String.Empty) + message;
                    break;
                default:
                    throw new NotSupportedException("Message type '" + messageType.ToString() + "' is not supported.");
            }
        }
        public static void ShowDefaultErrorMessage(this System.Web.UI.HtmlControls.HtmlGenericControl control, Exception exceptioin)
        {
            if (exceptioin == null)
                throw new ArgumentNullException("exception");

#if (DEBUG)
        control.ShowMessage("<h4>" + HttpUtility.HtmlEncode(exceptioin.Message) + "</h4><samp>" + HttpUtility.HtmlEncode(exceptioin.StackTrace) + "</samp>", MessageType.Error, false);
#else
            control.ShowMessage("An error has occurred. Please contact system administrator.", MessageType.Error);
#endif
        }
        public enum MessageType
        {
            Error,
            Information,
            Success,
            Warning
        }
    }
}


