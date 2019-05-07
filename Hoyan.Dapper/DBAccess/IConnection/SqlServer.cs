using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBAccess
{
    public class SqlServer : IDatabase
    {
        public IDbConnection CreateConnection()
        {
            string sConnectString = DBAccess.ConfigTools.GetConnection();
            return CreateConnection(sConnectString);
        }

        public IDbConnection CreateConnection(string sConnectString)
        {
            if (string.IsNullOrEmpty(sConnectString))
            {
                throw new NotImplementedException("数据库地址为空");
            }

            IDbConnection conn = new SqlConnection(sConnectString);
            conn.Open();
            return conn;
        }
    }
}
