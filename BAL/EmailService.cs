using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mail;
using MailMessage = System.Net.Mail.MailMessage;

namespace BAL
{
    public class EmailService
    {
        public static void  Email(string useremail) 
        {
            try
            {
                string smtphost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "waseemhaider095@gmail.com";
                string smtpPassword = "OutLook89#";

                // Set up the email message
                MailMessage message = new MailMessage();
                message.From = new MailAddress(smtpUsername);
                message.To.Add(useremail);
                message.Subject = "Registration Successful";
                message.Body = "Dear User,\n\nYour registration was successful. Thank you for joining our platform.";

                // Set up the SMTP client
                SmtpClient smtpClient = new SmtpClient(smtphost, smtpPort);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = new NetworkCredential("Waseemhaider095@gmail.com", "your_email");

                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword, smtphost);
                smtpClient.Send(message);
            }
            catch (Exception ex) 
            {
                 ex.ExceptionLog("Email is not with the reasone of " + ex.Message, "EmailService", DateTime.Now.ToString());
            } 
            

        }


        public static void SendEmail( string address, int StudentNo, string firstname, string lastname)
        {
            try
            {
              //  string address = "to-mail@gmail.com";
              //  string subject = "Registeration";
              //  string message = "Hi its Worked";
                string email = "waseemhaider095@gmail.com";
                string username = "waseemhaider095@gmail.com";
                string password = "icsmgwwadunkabuw";
                string smtp = "smtp.gmail.com";
                int port = 587;
                var loginInfo = new NetworkCredential(username, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient(smtp, port);

                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(address));
                msg.Subject = "Registration Successful";
                msg.Body = "<html><head>\r\n    <meta charset=\"utf-8\">\r\n    <title>\r\n        CertificationSystem\r\n    </title>\r\n    <style>\r\n        .messageBody {\r\n            font: normal 11pt Arial;\r\n            text-align: justify;\r\n        }\r\n\r\n        .Regards {\r\n            font: bold 11pt Arial;\r\n        }\r\n\r\n        .NameRegards {\r\n            font: normal 11pt Arial;\r\n        }\r\n\r\n        .messageHeader {\r\n            font: bold 12pt Arial;\r\n        }\r\n\r\n        .imgHeader {\r\n            min-height: 207px;\r\n            max-height: 207px;\r\n        }\r\n\r\n        .tdbody {\r\n            min-height: 200px;\r\n            max-height: 600px;\r\n        }\r\n\r\n        .imgFooter {\r\n            min-height: 221px;\r\n            max-height: 221px;\r\n        }\r\n\r\n        .tbl {\r\n            max-width: 766px;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <table class=\"tbl\" >\r\n        <thead>\r\n            <tr>\r\n                <td class=\"imgHeader\">\r\n                    <img src=\"https://ems.wateen.com/images/HeaderMail2.png\">\r\n                </td>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr>\r\n                <td>\r\n                    <div class=\"tdbody\">\r\n                        <table>\r\n                            <tbody><tr>\r\n                                <td class=\"messageHeader\">\r\n                                    Dear " + firstname + " " + lastname + ",\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>&nbsp;</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>\r\n                                    <p class=\"messageBody\">\r\n                                      Certification System Administration Register your Profile against your Student No " + StudentNo + "  <br/>\r\n                                        </p><div class=\"messageBody\">\r\n                                     \r\n                                        \r\n                                              Please login to view your Profile in Certification System.\r\n         <a href=\"https://localhost:44387/Login.aspx\">View</a>\r\n                                        </div>\r\n                                    <p></p>\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>\r\n                                    &nbsp;\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>\r\n                                    &nbsp;\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td class=\"Regards\">\r\n                                    Thank You!\r\n                                </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td class=\"NameRegards\">\r\n                                    Certification System Administration. Note: This message is sent to you automatically by $CertificationSystem$. Please do not reply to this Email\r\n                                </td>\r\n                            </tr>\r\n                        </tbody></table>\r\n                    </div>\r\n                </td></tr></tbody><tfoot><tr><td class=\"imgFooter\"><img src=\"https://ems.wateen.com/images/FooterMail.png\"></td></tr>\r\n        </tfoot>\r\n    </table>\r\n\r\n</body></html>";
                //msg.Body = "Dear " + firstname + ' ' + lastname + ", " +
                //                                               " Your registration was successful. Thank you for joining our platform and your" +
                //    "Registeration Id is :" + StudentNo + " Please note down this Number.";
                msg.IsBodyHtml = true;
               // string serverPath = HttpContext.Current.Server.MapPath(path);
                string attachmentFilePath = HostingEnvironment.MapPath("~/PDFs/"+firstname+lastname+".pdf");
                if(attachmentFilePath == string.Empty)
                {
                    //Attachment attachment = new Attachment(attachmentFilePath);
                    //msg.Attachments.Add(attachment);

                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = loginInfo;
                    smtpClient.Send(msg);
                }
                else
                {
                    Attachment attachment = new Attachment(attachmentFilePath);
                    msg.Attachments.Add(attachment);

                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = loginInfo;
                    smtpClient.Send(msg);

                }
                
              
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("EmailService", "StudentRegisteration", DateTime.Now.ToString());
            }
           
            
        }
        
    }
}
