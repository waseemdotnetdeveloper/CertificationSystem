using BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;


namespace CertificationSystem
{
    public partial class RegisterationForNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


            if (!Page.IsPostBack)
            {
                try
                {
                    
                    //GetGender
                    DataSet getgender  = new DataSet();
                    getgender = BAL.Registertion.GetGender();
                    ddlgender.DataSource = getgender;
                    ddlgender.DataTextField = "GenderName";
                    ddlgender.DataValueField = "GenderId";
                    ddlgender.DataBind();
                    getgender.Dispose();
                    ddlgender.Items.Insert(0, new ListItem("--Select your Gender--", "-1"));
                    //Get Country
                    DataSet GetCountry = new DataSet();
                    GetCountry = BAL.Registertion.GetCountry();
                    ddlcountry.DataSource = GetCountry;
                    ddlcountry.DataTextField = "CountryName";
                    ddlcountry.DataValueField = "Id";
                    ddlcountry.DataBind();
                    GetCountry.Dispose();
                    ddlcountry.Items.Insert(0, new ListItem("--Select your Country--", "-1"));
                    dllcity.Items.Insert(0, new ListItem("--Select your City--", "-1"));
                    //Get Department
                    DataSet getdepartment = new DataSet();
                    getdepartment = BAL.Registertion.GetDepartment();
                    ddldepartment.DataSource = getdepartment;
                    ddldepartment.DataTextField = "Department";
                    ddldepartment.DataValueField = "DepartmentId";
                    ddldepartment.DataBind();
                    getdepartment.Dispose();
                    ddldepartment.Items.Insert(0, new ListItem("--Select your Department--", "-1"));
                    ddlsubdep.Items.Insert(0, new ListItem("--Select to Your Sub Department--", "-1"));
                    ddlcourse.Items.Insert(0, new ListItem("--Select your Course--", "-1"));
                    ddlteacher.Items.Insert(0, new ListItem("--Select your Teacher", "-1"));
                    //Get Martial Status
                    DataSet getmartialstatus = new DataSet();
                    getmartialstatus = BAL.Registertion.getmartialstatus();
                    ddlmartialstatus.DataSource = getmartialstatus;
                    ddlmartialstatus.DataTextField = "MartialStatus";
                    ddlmartialstatus.DataValueField = "MartialId";
                    ddlmartialstatus.DataBind();
                    getmartialstatus.Dispose();
                    ddlmartialstatus.Items.Insert(0, new ListItem("--Select your Martial Status--", "-1"));

                    ////Set MobileNumber for Pakistan User

                    //string mobileNumber = phonenumber.Text;
                    // if (!(phonenumber.Text.Contains("+92-0")))
                    //    {
                    //        pho
                    //        nenumber.Text = "+92-" + mobileNumber;
                    //    }
                    //Get Education 
                    DataSet getEducation = new DataSet();
                    getEducation = BAL.Registertion.GetEducation();
                    ddleducation.DataSource = getEducation;
                    ddleducation.DataTextField = "Education";
                    ddleducation.DataValueField = "EduId";
                    ddleducation.DataBind();
                    getEducation.Dispose();
                    ddleducation.Items.Insert(0, new ListItem("--Select Your Education--", "-1"));



                }
                catch (Exception ex)
                {
                    dvMessage.ShowMessage("Error Occurred to loading the information", Extension.MessageType.Error);
                    ex.ExceptionLog("RegisterationForNew.aspx", "GetGender", DateTime.Now.ToString());
                }

            }


        }


        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlcountry.SelectedIndex == 0)
                {
                    dvMessage.ShowMessage("Please Select Country First", Extension.MessageType.Error);
                    ddlcountry.Focus();
                }
                else
                {
                    string city = ddlcountry.SelectedItem.Text;
                    DataSet getcities = new DataSet();
                    getcities = BAL.Registertion.GetCity(city);
                    dllcity.DataSource = getcities;
                    dllcity.DataTextField = "CityName";
                    dllcity.DataValueField = "Id";
                    dllcity.DataBind();
                    dllcity.Items.Insert(0, new ListItem("--Select your City--", "-1"));
                    getcities.Dispose();
                }
            }
            catch (Exception ex)
            {
                dvMessage.ShowMessage("Error occured loading the information of Cities", Extension.MessageType.Error);
                ex.ExceptionLog("RegisterationForNew.aspx", "GetCity", DateTime.Now.ToString());
            }
           
        }

        protected void dllcity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddldepartment.SelectedIndex == 0)
                {
                    dvMessage.ShowMessage("Please Select your Depatment First", Extension.MessageType.Error);
                    ddldepartment.Items.Insert(0, new ListItem("--Select your Department--", "-1"));
                    ddldepartment.Focus();
                }
                else
                {
                    //Get Subdepartment with base of Department
                    string subdepartment = ddldepartment.SelectedItem.Text;
                    DataSet getsubdepartment = new DataSet();
                    getsubdepartment = Registertion.GetSubDepartment(subdepartment);
                    ddlsubdep.DataSource = getsubdepartment;
                    ddlsubdep.DataTextField = "SubDepartmentName";
                    ddlsubdep.DataValueField = "DepartmentId";
                    ddlsubdep.DataBind();
                    ddlsubdep.Items.Insert(0, new ListItem("--Select your SubDepartment", "-1"));
                    getsubdepartment.Dispose();
                }
            }
            catch (Exception ex)
            {
                dvMessage.ShowMessage("Error occured loading the information of Sub Departments", Extension.MessageType.Error);
                ex.ExceptionLog("RegisterationForNew.aspx", "GetSubDepartments", DateTime.Now.ToString());
            }
           
        }

        protected void ddlsubdep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlsubdep.SelectedIndex == 0)
                {
                    dvMessage.ShowMessage("Please Select your Depatment First", Extension.MessageType.Error);
                    ddldepartment.Items.Insert(0, new ListItem("--Select your Department--", "-1"));
                    ddldepartment.Focus();
                }
                else
                {
                    string course = ddlsubdep.SelectedItem.Text;
                    DataSet GetCoursebySubDepartment = new DataSet();
                    GetCoursebySubDepartment = BAL.Registertion.GetCoursebySubDepartment(course);
                    ddlcourse.DataSource = GetCoursebySubDepartment;
                    ddlcourse.DataTextField = "Course";
                    ddlcourse.DataValueField = "DepartmentId";
                    ddlcourse.DataBind();
                    ddlcourse.Items.Insert(0, new ListItem("--Select your Course--", "-1"));
                    ddlcourse.Focus();
                    GetCoursebySubDepartment.Dispose();
                }
            }
            catch
            (Exception ex)
            {
                dvMessage.ShowMessage("Error occured loading the information of Courses", Extension.MessageType.Error);
                ex.ExceptionLog("RegisterationForNew.aspx", "GetCourse", DateTime.Now.ToString());
            }
           
        }

        protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(ddlcourse.SelectedIndex == 0)
                {
                    dvMessage.ShowMessage("Please Select your Course First", Extension.MessageType.Error);
                    ddlcourse.Items.Insert(0, new ListItem("--Select your Course--", "-1"));
                    ddlcourse.Focus();
                }
                else
                {
                    string Department = ddldepartment.SelectedItem.Text;
                    string SubDepartment = ddlsubdep.SelectedItem.Text;
                    string course = ddlcourse.SelectedItem.Text;
                    DataSet getteacher = new DataSet();
                    getteacher = BAL.Registertion.GetTeacherbyCourse(Department,SubDepartment,course);
                    ddlteacher.DataSource = getteacher;
                    ddlteacher.DataTextField = "TeacherName";
                    ddlteacher.DataValueField = "DepartmentId";
                    ddlteacher.DataBind();
                    ddlteacher.Items.Insert(0, new ListItem("--Select your Teacher--", "-1"));
                    ddlteacher.Focus();
                    getteacher.Dispose();

                }
            
           }
            catch (Exception ex)
            {
                dvMessage.ShowMessage("Error occured loading the information of Teachers", Extension.MessageType.Error);
                ex.ExceptionLog("RegisterationForNew.aspx", "GetTeacher", DateTime.Now.ToString());
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string firstname = FirstName.Text.Trim();
                string lastname = LastName.Text.Trim();
                string dateofbirth = DOB.Text.Trim();
                DateTime dobtxt;
                bool isvalid = DateTime.TryParse(dateofbirth, out dobtxt);
                //  string FinalDateofBirth = dateofbirth.ToString().Trim();
                string Gender = ddlgender.Text.Trim();
                string email = Cnic.Text.Trim();
                string MartialStatus = ddlmartialstatus.Text.Trim();
                string phonenumber = PhoneNumber.Text.Trim();
                string Education = ddleducation.Text.Trim();
                string Country = ddlcountry.Text.Trim();
                string City = dllcity.Text.Trim();
                string Department = ddldepartment.Text.Trim();
                string SubDepartment = ddlsubdep.Text.Trim();
                string Course = ddlcourse.Text.Trim();
                string Teacher = ddlteacher.Text.Trim();
                string username = Username.Text.Trim();
                string password = Password.Text.Trim();

                if (firstname == string.Empty)
                {
                    dvMessage.ShowMessage("Please Enter your First Name", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    Regex patternforString = new Regex(@"^[A-Za-z]+$");
                    if (patternforString.IsMatch(firstname))
                    {
                        btnRegister.Enabled = true;
                    }
                    else
                    {
                        dvMessage.ShowMessage("Please Enter Correct First Name", Extension.MessageType.Error);
                        btnRegister.Enabled = false;
                        return;
                    }
                }
                if (lastname == string.Empty)
                {
                    dvMessage.ShowMessage("Please Enter your Last Name", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    Regex patternforString = new Regex(@"^[A-Za-z]+$");
                    if (patternforString.IsMatch(lastname))
                    {
                        btnRegister.Enabled = true;
                    }
                    else
                    {
                        dvMessage.ShowMessage("Please Enter Correct Last Name", Extension.MessageType.Error);
                        btnRegister.Enabled = false;
                        return;
                    }
                }
                if (dateofbirth == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Date of Birth.", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    dateofbirth = string.Empty;
                    return;
                }
                else
                {
                    if (isvalid && dobtxt > DateTime.Now)
                    {
                        dvMessage.ShowMessage("Please Enter Correct Date of Birth according to Actual Date", Extension.MessageType.Error);
                        btnRegister.Enabled = false;
                        dateofbirth = string.Empty;
                        return;
                    }
                    else
                    {
                        btnRegister.Enabled = true;
                    }

                }
                if (Gender == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Gender", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (email == string.Empty)
                {
                    dvMessage.ShowMessage("Please Enter your Email", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    Regex patternforemail = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
                    if (patternforemail.IsMatch(email))
                    {
                        btnRegister.Enabled = true;
                    }
                    else
                    {
                        dvMessage.ShowMessage("Please Enter Correct Email", Extension.MessageType.Error);
                        btnRegister.Enabled = false;
                        //return;
                    }
                }
                if (MartialStatus == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Martial Status", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (phonenumber == string.Empty)
                {
                    dvMessage.ShowMessage("Please Enter your Phone if you are Pakistani", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {

                }
                if (Education == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Education", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = false;
                }
                if (Country == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Country", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (City == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your City", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (Department == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Department", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (SubDepartment == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Sub Department.", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = false;
                }
                if (Course == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Course", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (Teacher == string.Empty)
                {
                    dvMessage.ShowMessage("Please Select your Teacher", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    btnRegister.Enabled = true;
                }
                if (username == string.Empty)
                {
                    dvMessage.ShowMessage("Please Enter your Username", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    if (username.Length < 8)
                    {
                        dvMessage.ShowMessage("Please enter Strong and Unique Username", Extension.MessageType.Error);
                        btnRegister.Enabled = false;
                        //return;
                    }
                    else
                    {
                        string patternforUsername = @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
                        bool isValid = Regex.IsMatch(username, patternforUsername);
                        if (isValid)
                        {
                            bool IsValid = BAL.Registertion.IsUsernameUnique(username);
                            if (IsValid)
                            {
                                btnRegister.Enabled = true;
                                Password.Focus();
                            }
                            else
                            {
                                dvMessage.ShowMessage("Username is Already Exists, Please your username must be unique", Extension.MessageType.Warning);
                                btnRegister.Enabled = false;
                                Username.Focus();
                                return;

                            }

                        }
                        else
                        {
                            dvMessage.ShowMessage("Your Username is not be strong", Extension.MessageType.Error);
                            username = string.Empty;
                            btnRegister.Enabled = false;
                            return;
                        }

                    }
                }
                if (password == string.Empty)
                {
                    dvMessage.ShowMessage("Please Enter your Password", Extension.MessageType.Error);
                    btnRegister.Enabled = false;
                    return;
                }
                else
                {
                    Regex PatternforPassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

                    if (PatternforPassword.IsMatch(password))
                    {
                        string encryptedpassword = BAL.Common.Encryption(password);
                        var Studentno = 0;
                        ViewState["RegId"] = BAL.Registertion.getstudentno(Convert.ToInt32(Studentno));
                        // Session["Studentno"] = RegId;
                        //RegId = Convert.ToInt32(Studentno);
                        string FinalGender = ddlgender.SelectedItem.ToString();
                        string FinalMS = ddlmartialstatus.SelectedItem.ToString();
                        string FinalEducation = ddleducation.SelectedItem.ToString();
                        string FinalCity = dllcity.SelectedItem.ToString();
                        string FinalCountry = ddlcountry.SelectedItem.ToString();
                        string FinalDepartment = ddldepartment.SelectedItem.ToString();
                        string FinalSubDepartment = ddlsubdep.SelectedItem.ToString();
                        string FinalCourse = ddlcourse.SelectedItem.ToString();
                        string FinalTeacher = ddlteacher.SelectedItem.ToString();
                        int i = 0;
                            i =BAL.Registertion.insertstudentinfo(firstname, lastname, dateofbirth,
                            FinalGender, email, FinalMS, phonenumber, FinalEducation, FinalCountry, FinalCity,
                            FinalDepartment, FinalSubDepartment, FinalCourse, FinalTeacher, username, encryptedpassword, Convert.ToInt32(ViewState["RegId"]));
                            if (i > 0)
                            {

                                if (firstname == string.Empty)
                                {
                                    dvMessage.ShowMessage("Please must enter your first Name", Extension.MessageType.Error);
                                }
                                else if (lastname == string.Empty)
                                {
                                    dvMessage.ShowMessage("Please must enter your Last Name", Extension.MessageType.Error);
                                }
                                else
                                {
                                    // string[] path1 = new string[] { firstname, lastname, dateofbirth }; 
                                    //string   getpath = BAL.Common.ConvertWebFormToPdf(path1,firstname,lastname);
                                    dvMessage.ShowMessage("Your Register is Successfull and please note down your Registeration Number is " + Convert.ToInt32(ViewState["RegId"]), Extension.MessageType.Success);
                                    // Studentno = Convert.ToInt32(Request.QueryString[Studentno]);
                                    btnCancal.Text = "Back To Login";

                                    BAL.EmailService.SendEmail(email, Convert.ToInt32(ViewState["RegId"]), firstname,
                                        lastname);
                                }


                            }



                        
                    }

                    else
                    {
                        dvMessage.ShowMessage("Your Password is not be strong", Extension.MessageType.Error);
                        Password.Text = string.Empty;
                        btnRegister.Enabled = false;
                        return;
                    }










                }
            }
            catch (Exception ex)
            {
                dvMessage.ShowMessage("Your Registeration is UnSuccessfull, Please try Again Later and Contact with Administrator.", Extension.MessageType.Error);
                ex.ExceptionLog("RegisterationForNew.aspx", "RegisterStudent", DateTime.Now.ToString());
            }

        }

        protected void btnCancal_Click(object sender, EventArgs e)
        {
            if (btnCancal.Text == "Back To Login")
            {
                try
                {
                    int stdno = Convert.ToInt32(ViewState["RegId"]);
                    Response.Redirect("Login.aspx?Studentno=" + stdno, false);
                    //  Response.End();
                }
                catch (ThreadAbortException ex)
                {
                    dvMessage.ShowMessage("" + ex, Extension.MessageType.Error);
                }

            }
          
           

        }
        public void ClearControl()
        {
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            DOB.Text = string.Empty;
            ddlgender.SelectedIndex = 0;
            Cnic.Text = string.Empty;
            ddlmartialstatus.SelectedIndex = 0;
            PhoneNumber.Text = string.Empty;
            ddleducation.SelectedIndex = 0;
            ddlcountry.SelectedIndex = 0;
            dllcity.SelectedIndex = 0;
            ddldepartment.SelectedIndex = 0;
            ddlsubdep.SelectedIndex = 0;
            ddlcourse.SelectedIndex = 0;
            ddlteacher.SelectedIndex = 0;
            Username.Text = string.Empty;
            Password.Text = string.Empty;
        }

        protected void PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (PhoneNumber.Text != string.Empty)
            {
                if(PhoneNumber.Text.Length ==11) 
                {
                    Regex phonenumber = new Regex(@"^\d+$");

                    bool isMatch = phonenumber.IsMatch(PhoneNumber.Text);
                    if (isMatch)
                    {
                        string mobileNumber = PhoneNumber.Text.Trim();
                        if (!(PhoneNumber.Text.Contains("+92-0")))
                        {
                            PhoneNumber.Text = "+92-" + mobileNumber.Substring(0,4) + "-" + mobileNumber.Substring(4,7);

                            // btnRegister.Enabled = true;
                            //var formattedNumber = "+92-" + mobileNumber.substr(0, 4) + "-" + mobileNumber.substr(4, 7);
                        }
                        btnRegister.Enabled = true;
                    }
                    else
                    {
                        btnRegister.Enabled = false;
                        dvMessage.ShowMessage("Please Enter Only Mobile Numbers in Integers", Extension.MessageType.Error);
                        return;
                    }
                }
                else
                {
                    dvMessage.ShowMessage("Please Enter Correct Length in Mobile Number Like this : 99-9999-9999999", Extension.MessageType.Error)
                        ; return;
                }       
            }
        }

       
    }
}
