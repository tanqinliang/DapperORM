using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBAccess
{
    public interface IDatabase 
    {
        IDbConnection CreateConnection();

        IDbConnection CreateConnection(string sConnectString);


        //DataTable ExecuteTable(string query, DynamicParameters dp);

        //int ExecuteNonQuery(string query, DynamicParameters dp);

        //List<T> QueryList(string query, DynamicParameters dp);

        //T QueryInfo(string query, DynamicParameters dp);


    }






}
