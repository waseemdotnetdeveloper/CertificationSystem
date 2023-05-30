using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CertificationSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["studentno.Text"] = Request.QueryString["Studentno"];
                if (studentno.Text != string.Empty)
                {
                    dvMessage.ShowMessage("Your Register is Successfull and please note down your Registeration Number is " + studentno.Text, Extension.MessageType.Success);
                }
            }


        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string username = usernametxt.Text;
            string password = passwordtxt.Text;
           // var Studentno = 0;
            if (username != string.Empty && password != string.Empty)
            {
                DataSet getstudent = new DataSet();
                getstudent = BAL.Login.GetStudentNumber(username);
                DataTable finalgetstudent = new DataTable();
                finalgetstudent = getstudent.Tables[0];
                foreach (DataRow dr in finalgetstudent.Rows)
                {
                    var StudentNo = dr["StudentNo"].ToString();
                    var FirstName = dr["FirstName"].ToString();
                    var LastName = dr["LastName"].ToString();
                    var DOB = dr["DOB"].ToString();
                    var MartialStatus = dr["MartialStatus"].ToString();
                    var PhoneNumber = dr["PhoneNumber"].ToString();
                    var Education = dr["Education"].ToString();
                    var Country = dr["Country"].ToString();
                    var City = dr["City"].ToString();
                    var Department = dr["Department"].ToString();
                    var SubDepartment = dr["SubDepartment"].ToString();
                    var Course = dr["Course"].ToString() ;
                    var Teacher = dr["Teacher"].ToString();
                    var Username = dr["Username"].ToString().Trim();
                    var LoginUsername = dr["LoginUsername"].ToString().Trim();
                    var Password = dr["Password"].ToString();
                    var LoginPassword = dr["LoginPassword"].ToString();
                    var IsDeletedinStudent = dr["IsDeleted"].ToString();
                    var CreatedByInStudent = dr["CreatedBy"].ToString();
                    var Email = dr["Email"].ToString();
                    var WrongLongAttempt = dr["WrongLoginAttempt"].ToString();
                    var IsDeletedinLogin = dr["IsDeleted1"].ToString();
                    var CreatedByinLogin = dr["CreatedBy1"].ToString();
                    var IsActivated = dr["IsActivate"].ToString();
                    var TodayLoginAttempt = dr["TodayLoginAttempt"].ToString();
                    
                    if(FirstName == "")
                    {
                        dvMessage.ShowMessage("Your First Name is Not Updated, Please contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                       // return true;
                    }
                    if(LastName == "")
                    {
                        dvMessage.ShowMessage("Your Last Name is Not Updated, Please contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        //return true;
                    }
                    if(DOB == "")
                    {
                        dvMessage.ShowMessage("Your Date of Birth is Not Updated", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        //return true;
                    }
                    if(MartialStatus == "--Select your Martial Status--")
                    {
                        dvMessage.ShowMessage("Your Martial Status is not updated, Please contact with Administrator.", Extension.MessageType.Warning);
                    }
                    else
                    {
                        //return true;
                    }
                    if(Country.Trim() == "PAKISTAN")
                    {
                        if(PhoneNumber == "")
                        {
                            dvMessage.ShowMessage("Your Phone Number is not updated, Please Contact with Administrator", Extension.MessageType.Warning);
                            return;
                        }
                        else
                        {
                            //return true;
                        }
                    }
                    else  
                    {

                        if (Country.Trim() == "--Select your Country--")
                        {
                            dvMessage.ShowMessage("Your Country is not Updated, Please contact with Administrator.", Extension.MessageType.Warning);
                            return; 
                        }
                        else
                        {
                            if(City == "--Select your City--")
                            {
                                dvMessage.ShowMessage("Your City is not Updated according to your Country, Please Contact with Administrator", Extension.MessageType.Warning);
                            }
                            else
                            {
                                //Return true;
                            }

                        }
                    }
                    if(Education == "--Select your Education--")
                    {
                        dvMessage.ShowMessage("Your Education is Not Updated, Please Contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        //return true;
                    }
                    if(Department == "--Select Your Department--")
                    {
                        dvMessage.ShowMessage("Your Department is not updated, Please Contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        if(SubDepartment=="--Select your Sub-Department--")
                        {
                            dvMessage.ShowMessage("Your Sub Department is not Updated, Please Contact with Administrator", Extension.MessageType.Warning);
                            return;
                        }
                        else
                        {
                            if(Course=="--Select Your Course--")
                            {
                                dvMessage.ShowMessage("Your Course is not Updated, Please Contact with Administrator", Extension.MessageType.Warning);
                                return;
                            }
                            else
                            {
                                if(Teacher == "--Select your Teacher--")
                                {
                                    dvMessage.ShowMessage("Your Teacher is not Updated, Please Contact with Administrator", Extension.MessageType.Warning);
                                    return;
                                }
                                else
                                {
                                    //return true;
                                }
                            }
                        }
                    }
                    if(Username== "" && LoginUsername== "")
                    {
                        dvMessage.ShowMessage("Your Username is Not Exsits in our Record, Please Contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        if(Username != LoginUsername)
                        {
                            dvMessage.ShowMessage("You Enter Incorrect Username, Please write correct username", Extension.MessageType.Error);
                            return;
                        }
                        else
                        {
                            //return true;
                        }
                    }
                    if(IsDeletedinStudent == "T" && IsDeletedinLogin== "T")
                    {
                        dvMessage.ShowMessage("Your Account is Delete from your record, Please contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        //return true;
                    }
                    if (StudentNo == "" && CreatedByinLogin == "" && CreatedByInStudent== "")
                    {
                        dvMessage.ShowMessage("Your Registration No is updated, Please contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        if (StudentNo != CreatedByinLogin && StudentNo != CreatedByInStudent && CreatedByinLogin != CreatedByInStudent)
                        {
                            dvMessage.ShowMessage("Your Registration Number is not exitis in our Records, Please Contact with Administrator", Extension.MessageType.Warning);
                            return;
                        }
                        else
                        {
                            HttpContext.Current.Session["StudentNo"] = StudentNo;
                            int final = Convert.ToInt32(StudentNo);
                        }
                    }
                    if(IsActivated == "N")
                    {
                        dvMessage.ShowMessage("Your Account is Deactived by Admin, Please Contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                        //return true;
                    }
                    if(Email == "")
                    {
                        dvMessage.ShowMessage("Your Email is Not Updated, Please Contact with Administrator", Extension.MessageType.Warning);
                        return;
                    }
                    else
                    {
                       // return true;
                    }
                    string FinalPassword = LoginPassword.ToString();
                    string Decryption = BAL.Common.Decryption(FinalPassword);

                    if (Decryption != passwordtxt.Text || LoginUsername != usernametxt.Text)
                    {

                        int attempts = BAL.Login.WrongLoginAttempts(Username);
                        if (attempts > 0)
                        {
                            BAL.Login.UpdateWrongLoginAttempts(attempts, Username);
                            Response.Redirect("Login.aspx", false);
                            dvMessage.ShowMessage("Your Enter Credentials was Invalid, Please Try Again Later.", Extension.MessageType.Error);
                            return;
                        }
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                     

                    }
                }
                DataTable dt = new DataTable();

                dt = BAL.Login.CheckLogindetails(username.ToString());

                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    dvMessage.ShowMessage("Please enter your correct credentials", Extension.MessageType.Error);
                }
            }



        }


       
    }
}


 
