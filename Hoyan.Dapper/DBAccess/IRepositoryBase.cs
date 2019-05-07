using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
         

        int Execute(string query, object param);

        Task<int> ExecuteAsync(string query, object param);

        TEntity QueryFirstOrDefault(string query, object param);

        Task<TEntity> QueryFirstOrDefaultAsync(string query, object param);

        IEnumerable<TEntity> QueryList(string query, object param);

        Task<IEnumerable<TEntity>> QueryListAsync(string query, object param);

        DataTable QueryTable(string query, object param);

        int InsertList(string query, IEnumerable<TEntity> list);

        SplitPage<DataTable> GetPageTable(string query, int iPage, int iPageSize, DynamicParameters dp);

        SplitPage<IEnumerable<TEntity>> GetPageList(string query, int iPage, int iPageSize, DynamicParameters dp);
    }
}
