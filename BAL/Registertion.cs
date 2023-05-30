using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BAL
{
    public class Registertion
    {
        // SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        public static DataSet GetGender()
        {
            DataSet getgender = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {

                string query = @"select * From Gender where IsDeleted = 'F'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getgender);
                return getgender;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetGender", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }

        }
        public static DataSet GetCity(string country)
        {
            DataSet getcity = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {

                string query = @"select * From CountryAndCities where IsDeleted= 'F' AND CountryName= '" + country + "'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getcity);
                return getcity;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetCity", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }


        }
        public static DataSet GetCountry()
        {
            DataSet getcity = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {

                string query = @"select c.Id,UPPER(c.CountryName) as CountryName From CountryAndCities c where IsDeleted= 'F'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getcity);
                return getcity;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetCountry", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }


        }
        public static DataSet GetDepartment()
        {
            DataSet getDepartment = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {

                string query = @"select  Min(DepartmentName) as Department , Min(DepartmentId) as DepartmentId from DepartmentandCourseinfo where IsDelete='F'
                               group by DepartmentName";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getDepartment);
                return getDepartment;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetCountry", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }

        }
        public static DataSet GetSubDepartment(string departmentName)
        {
            DataSet getsubdepartment = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {
                string query;
                query = @"SELECT Min(SubDepartmentName) as SubDepartmentName, Min(DepartmentId) as DepartmentId from DepartmentandCourseInfo WHERE IsDelete='F' AND DepartmentName='" + departmentName + "'group by SubDepartmentName";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getsubdepartment);
                return getsubdepartment;

            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetSubDepartment", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;

            }


        }
        public static DataSet GetCoursebySubDepartment(string SubDepartment)
        {
            DataSet getcourse = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {
                string query;
                query = @"SELECT Min(CourseName) as Course, Min(DepartmentId) as DepartmentId from DepartmentandCourseInfo WHERE IsDelete='F' AND SubDepartmentName='" + SubDepartment + "' group by CourseName";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getcourse);
                return getcourse;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetCourse", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }

        }
        public static DataSet getmartialstatus()
        {
            DataSet getmartialstatus = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {
                string query;
                query = @"Select * from MartialStatus where IsDeleted='F'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(getmartialstatus);
                return getmartialstatus;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetMartialStatus", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }
        }
        public static DataSet GetTeacherbyCourse(string DepartmentName, string SubDepartmentName, string CourseName)
        {
            DataSet GetTeacher = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {
                string query;
                query = @"Select * from DepartmentandCourseInfo where DepartmentName ='" + DepartmentName + "'AND SubDepartmentName='" + SubDepartmentName + "' AND CourseName='" + CourseName + "' AND IsDelete='F'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(GetTeacher);
                return GetTeacher;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetTeacher", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }
        }

        public static DataSet GetEducation()
        {
            DataSet geteducation = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {

                string query = @"select * From Education where IsDeleted = 'F'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlConnection.Close();
                cmd.Dispose();
                adapter.Fill(geteducation);
                return geteducation;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetEducation", DateTime.Now.ToString());
                sqlConnection.Close();
                return null;
            }
        }

        public static bool IsUsernameUnique(string username)
        {
            bool isunique = false;
            

            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            SqlConnection sqlConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection1.Open();
            sqlConnection2.Open();
            try
            {

                string query1 = @"select count(LoginUsername) from LoginDetails where IsDeleted='F' AND IsActivate='Y' AND LoginUsername = '" + username + "'";
                string query2 = @"select count(Username) from StudentInfo where IsDeleted='F' and Username='" + username + "'";
                SqlCommand cmd1 = new SqlCommand(query1, sqlConnection1);
                SqlCommand cmd2 = new SqlCommand(query2, sqlConnection2);
                //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                int count1 = (int)cmd1.ExecuteScalar();
                int count2 = (int)cmd2.ExecuteScalar();
                if (count1 == 0)
                {
                    if(count2 == 0) 
                    { 
                        isunique = true;
                        sqlConnection1.Close();
                        sqlConnection2.Close();
                        cmd1.Dispose();
                        cmd2.Dispose();
                        // adapter.Fill(geteducation);
                        return isunique;
                    }
                }
               

               return isunique;
               
                
              
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "UniqueUsername", DateTime.Now.ToString());
                sqlConnection1.Close();
                sqlConnection2.Close();
                return isunique;
            }

        }

        public static int getstudentno(int getstudent)
        {
            // DataSet getstudentno = new DataSet();
           // int getstudent = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {
                var query = @"select max(StudentNo) from StudentInfo where IsDeleted='F'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                getstudent = Convert.ToInt32(cmd.ExecuteScalar());
                getstudent = getstudent + 1;
                sqlConnection.Close();
                cmd.Dispose();
               // int Query = Int32.Parse(query);

                return getstudent;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Registeration.cs", "GetStudentNo", DateTime.Now.ToString());
                return 0;
            }

        }
        public static int insertstudentinfo(string firstname, string lastname, 
                  string dateofbirth,
                string Gender, string email,string MartialStatus, string phonenumber, string Education, string Country, string City,
                string Department, string SubDepartment, string Course, string Teacher, string username, string cipher, int Studentno)
        {
           // int std = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand("InsertStudent", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters and their values
                command.Parameters.AddWithValue("@StudentNo", Studentno);
                command.Parameters.AddWithValue("@FirstName", firstname);
                command.Parameters.AddWithValue("@LastName", lastname);
                command.Parameters.AddWithValue("@DOB", dateofbirth);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@MartialStatus", MartialStatus);
                command.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                command.Parameters.AddWithValue("@Education", Education);
                command.Parameters.AddWithValue("@Country", Country);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@Department", Department);
                command.Parameters.AddWithValue("@SubDepartment", SubDepartment);
                command.Parameters.AddWithValue("@Course", Course);
                command.Parameters.AddWithValue("@Teacher", Teacher);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", cipher);
                command.Parameters.AddWithValue("@IsDeleted", "F");
                command.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@ModifiedOn", " ");
                command.Parameters.AddWithValue("@CreatedBy", Studentno);
              //  command.Parameters.AddWithValue("@Name", firstname);
                command.Parameters.AddWithValue("@FatherName", lastname);
                //command.Parameters.AddWithValue("@LoginUsername", username);
                //command.Parameters.AddWithValue("@LoginPassword", cipher);
                //command.Parameters.AddWithValue("@OldPassword", "IsNew");
                command.Parameters.AddWithValue("@CreateOn", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@IsActivate", "Y");
                //command.Parameters.AddWithValue("@IsDeleted", "F");
                //command.Parameters.AddWithValue("@CreateBy", Studentno);



                // Execute the stored procedure
                command.ExecuteNonQuery();

            }
            return Studentno ;
        }

    }
}
