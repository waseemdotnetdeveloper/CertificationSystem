using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Login
    {
        public static DataTable CheckLogindetails(string username)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
                sqlConnection.Open();
                string query = @"select * from Logindetails ld where ld.IsDeleted = 'F' AND ld.IsActivate = 'Y' AND ld.Loginusername='" + username.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                sqlConnection.Close();
                return dt;

            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Login.cs", "LoginTry", DateTime.Now.ToString());
                return null;


            }
        }

        public static DataSet GetStudentNumber(string Username)
        {
            DataSet studentno = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {

                using (SqlCommand command = new SqlCommand("sp_getstudentnumber", sqlConnection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", Username);
                   // command.Parameters.AddWithValue("Password", Password);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);


                    // Fill the dataset with the query results
                    dataAdapter.Fill(studentno);

                    // Access the result from the dataset
                   // DataTable dt = new DataTable();
                   // dt = studentno.Tables[0];
                   //foreach(DataRow dr in dt.Rows )
                   // {
                   //     var col1 = dr["StudentNo"];


                        
                   // }
                   // DataRow sr = dt.Rows[0];
                   // var col2 = sr["StudentNo"];

                   // var selectedRows = dt.AsEnumerable()
                   //        .Where(row => row.Field<string>("StudentNo") == "CreatedBy" )
                   //        .ToList();

                    return studentno;

                }


            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Login.cs", "GetStudentNumberforLogin", DateTime.Now.ToString());
                return studentno;
            }


           
        }

        public static int WrongLoginAttempts(string Username)
        {
           // Object dbvalue = 0;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            try
            {
                DataTable getwrongloginattempts = new DataTable();
                string query = @"SELECT MAX(WrongLoginAttempt) FROM LoginDetails WHERE IsDeleted='F' AND IsActivate='Y' AND LoginUsername=@Username";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@Username", Username);

                object dbvalue = cmd.ExecuteScalar();
                int attempts = 0;

                if (dbvalue != DBNull.Value)
                {
                    attempts = Convert.ToInt32(dbvalue);
                }

                attempts += 1;

                return attempts;
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("WrongLoginAttemps", "GetLoginAttemps.cs", DateTime.Now.ToString());
                return 0;
            }
            
        }

        public static void UpdateWrongLoginAttempts(int Attempts, string Username)
        {
            
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;

                string query;

                query = @"Update LoginDetails set WrongLoginAttempt= " + Attempts + " ModifiedOn ='" + DateTime.Now.ToString() + "' Where LoginUsername='"+Username+"'";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                // int lastInsert = Convert.ToInt32(cmd.ExecuteScalar());
               // lastid = Convert.ToInt32(cmd.ExecuteScalar());
                sqlTransaction.Commit();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                ex.ExceptionLog("UpdateWrongLoginAttempt", "WrongLogin", DateTime.Now.ToString());
                sqlTransaction.Rollback();
                sqlConnection.Close();
               

            }
        }
    }
}
