using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlOperations
    {
        public static DataSet ExecuteQuery(string query, string conStrName)
        {

            DataSet dsAns = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase(conStrName);
                dsAns = db.ExecuteDataSet(CommandType.Text, query);


            }
            catch (Exception e)
            {
                // Bubbling up the exception... 
                throw e;
            }

            return dsAns;
        }
    }
}
