using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DBAccess;
using Hoyan.Dapper.Entity;
using Hoyan.Dapper.IRepository;

namespace Hoyan.Dapper.Repository
{
    public class Admin_GroupClassRepository : DBAccess.RepositoryBase<Entity.Admin_GroupClass>, IRepository.IAdmin_GroupClassRepository
    {
        public int AddRecord(Admin_GroupClass model)
        {
            string sql = "cp_Admin_GroupClass_AddRecord";
            //DynamicParameters dp = new DynamicParameters();
            //dp.Add("@ID", model.ID, DbType.Int32, ParameterDirection.Input);
            //dp.Add("@ParentID", model.ParentID, DbType.Int32, ParameterDirection.Input);
            //dp.Add("@Title", model.ParentID, DbType.Int32, ParameterDirection.Input);
            //dp.Add("@OrderNo", model.ParentID, DbType.Int32, ParameterDirection.Input);
            //dp.Add("@ReturnValue", model.ParentID, DbType.Int32, ParameterDirection.ReturnValue);
            //int iIsu = base.Execute(sql, dp);
            //if (iIsu > 0)
            //    b = dp.Get<int>("ReturnValue");
            //return b;

            int iIsu = base.Execute(sql, model);
            return iIsu;
        }

        public int AddRecord(List<Admin_GroupClass> model)
        {
            string sql = "cp_Admin_GroupClass_AddRecord";

            int iIsu = base.Execute(sql, model);

            return iIsu;
        }

        public bool DeleteRecord(int iID)
        {
            string sql = "cp_Admin_GroupClass_DeleteRecord";
            return base.Execute(sql, new { @ID = @iID }) > 0;
        }

        public bool UpdateRecord(Admin_GroupClass obj)
        {
            string sql = "cp_Admin_GroupClass_UpdateRecord";
            return base.Execute(sql, obj) > 0;
        }


        public Admin_GroupClass GetRecordInfo(int iID)
        {
            string sql = "cp_Admin_GroupClass_GetRecordInfo";
            return base.QueryFirstOrDefault(sql, new { @ID = @iID });
        }


        public IEnumerable<Admin_GroupClass> GetRecordList()
        {
            string sql = "cp_Admin_GroupClass_GetRecordList";
            return base.QueryList(sql, null);
        }

        public DataTable GetRecordTable()
        {
            string sql = "cp_Admin_GroupClass_GetRecordList";
            return base.QueryTable(sql, null);
        }

        public SplitPage<IEnumerable<Admin_GroupClass>> GetRecordList(int iPage, int iPageSize)
        {
            string sql = "cp_Admin_GroupClass_GetPageRecord";
            DynamicParameters dp = new DynamicParameters();
            return base.GetPageList(sql, iPage, iPageSize, dp);
        }
        public SplitPage<DataTable> GetPageTable(int iPage, int iPageSize)
        {
            string sql = "cp_Admin_GroupClass_GetPageRecord";
            DynamicParameters dp = new DynamicParameters();
            return base.GetPageTable(sql, iPage, iPageSize, dp);
        }


    }
}
