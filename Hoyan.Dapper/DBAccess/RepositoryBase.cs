using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DBAccess
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected IDatabase _db = DBAccess.DbFactory.Create(DBAccess.DbFactory.GetDataProvider());


        public int Execute(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                 
                return conn.Execute(query, param, null, null, CommandType.StoredProcedure);
            }
        }

        public Task<int> ExecuteAsync(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                return conn.ExecuteAsync(query, param, null, null, CommandType.StoredProcedure);
            }
        }

        public SplitPage<IEnumerable<TEntity>> GetPageList(string query, int iPage, int iPageSize, DynamicParameters dp)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                dp.Add("RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dp.Add("Page", iPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dp.Add("PageSize", iPageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);

                List<TEntity> list = conn.Query<TEntity>(query, dp, null, true, null, CommandType.StoredProcedure).ToList();
                int iTotalRow = dp.Get<int>("RowCount");
                return new SplitPage<IEnumerable<TEntity>>(iPage, iPageSize, iTotalRow, list);

            }
        }

        public SplitPage<DataTable> GetPageTable(string query, int iPage, int iPageSize, DynamicParameters dp)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                dp.Add("RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dp.Add("Page", iPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                dp.Add("PageSize", iPageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);

                DataTable table = new DataTable("table");
                var reader = conn.ExecuteReader(query, dp, null, null, CommandType.StoredProcedure);
                table.Load(reader);
                int iTotalRow = dp.Get<int>("RowCount");
                return new SplitPage<DataTable>(iPage, iPageSize, iTotalRow, table);
            }
        }

        public int InsertList(string query, IEnumerable<TEntity> list)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                return conn.Execute(query, list, null, null, CommandType.StoredProcedure);
            }
        }

        public TEntity QueryFirstOrDefault(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                return conn.QueryFirstOrDefault<TEntity>(query, param, null, null, CommandType.StoredProcedure);
            }
        }

        public Task<TEntity> QueryFirstOrDefaultAsync(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                return conn.QueryFirstOrDefaultAsync<TEntity>(query, param, null, null, CommandType.StoredProcedure);
            }
        }

        public IEnumerable<TEntity> QueryList(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                return conn.Query<TEntity>(query, param, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }

        public Task<IEnumerable<TEntity>> QueryListAsync(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                return conn.QueryAsync<TEntity>(query, param, null
                    , null, CommandType.StoredProcedure);
            }
        }

        public DataTable QueryTable(string query, object param)
        {
            using (IDbConnection conn = _db.CreateConnection())
            {
                DataTable table = new DataTable("table");
                var reader = conn.ExecuteReader(query, param, null, null, CommandType.StoredProcedure);
                table.Load(reader);
                return table;
            }
        }

    }
}
