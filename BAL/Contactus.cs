using EnterpriseLibrary = Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using DAL.DLL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Runtime.CompilerServices;

namespace BAL
{
    public class Contactus
    {
      //  private static Database database = DatabaseFactory.CreateDatabase(DAL.DLL.DatabaseConstant.connectionstring);

        public static int insertcontactdetails(string yourname, string youremail, string yoursubject, string Message)
        {
          //  insertcontactdetails result = new insertcontactdetails();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            int lastid = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.Transaction = sqlTransaction;

                string query;
               
                query = @"Insert into Contactus (YourName, YourEmail, Subject, Message)
             VALUES ('" + yourname + "', '" + youremail + "', '" + yoursubject + "', '" + Message + "');SELECT SCOPE_IDENTITY();";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                // int lastInsert = Convert.ToInt32(cmd.ExecuteScalar());
                lastid = Convert.ToInt32(cmd.ExecuteScalar());
                sqlTransaction.Commit();
                sqlConnection.Close();

                return lastid;

                
                

            }
            catch (Exception ex)
            {
                ex.ExceptionLog("Contactus.cs", "Save", DateTime.Now.ToString());
                sqlTransaction.Rollback();
                sqlConnection.Close();
                return lastid;

            }
           

          //  SqlConnection con = new SqlConnection(query);

        }

        public static DataTable GetTickedId()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
            sqlConnection.Open();
            string query = @"select Scope_Identity() from contactus";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;


        }

    }
    
}
