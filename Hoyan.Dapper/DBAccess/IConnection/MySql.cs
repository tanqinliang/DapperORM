using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DBAccess.IConnection
{

    public class MySql : IDatabase
    {
        public IDbConnection CreateConnection(string sConnectString)
        {
            throw new NotImplementedException();
        }

        public IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
