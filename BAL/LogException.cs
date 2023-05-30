using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class LogException
    {
      
        public static void ExceptionLog(string Message,
                                        string StackTrace,
                                        string FormName,
                                        string MethodName,
                                        string CreatedOn)
           
        {
            object[] ParamterValues =
            {
                Message,
                StackTrace,
                FormName,
                MethodName,
                CreatedOn
            };
            
            
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.Transaction = sqlTransaction;

                    string query;
                    query = @"Insert into ExceptionLog (Message,StackTrace,FormName,
                        MethodName,CreatedOn) Values (' " + Message + " ', ' " + StackTrace + " ', '" + FormName + "'," +
                        "'" + MethodName + "', '" + DateTime.Now.ToString() + "')";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    ex.ExceptionLog("LogException.cs", "Exception", DateTime.Now.ToString());
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                   
                }
            }

        }
    }

