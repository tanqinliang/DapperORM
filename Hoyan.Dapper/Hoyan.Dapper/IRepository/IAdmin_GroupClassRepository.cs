using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DBAccess;

namespace Hoyan.Dapper.IRepository
{
    public interface IAdmin_GroupClassRepository
    {
        /// <summary>
        /// 添加记录信息
        /// </summary>
        /// <returns></returns>
        int AddRecord(Entity.Admin_GroupClass obj);

        /// <summary>
        /// 添加记录信息
        /// </summary>
        /// <returns></returns>
        int AddRecord(List<Entity.Admin_GroupClass> list);



        /// <summary>
        /// 修改记录信息
        /// </summary>
        /// <returns></returns>
        bool UpdateRecord(Entity.Admin_GroupClass obj);

        /// <summary>
        /// 删除记录信息
        /// </summary>
        /// <returns></returns>
        bool DeleteRecord(int iID);

        /// <summary>
        /// 得到记录信息
        /// </summary>
        /// <returns></returns>
        Entity.Admin_GroupClass GetRecordInfo(int iID);

        /// <summary>
        /// 得到记录信息
        /// </summary>
        /// <returns></returns>
        DataTable GetRecordTable();

        /// <summary>
        /// 得到记录信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Entity.Admin_GroupClass> GetRecordList();

        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <returns></returns>
        DBAccess.SplitPage<IEnumerable<Entity.Admin_GroupClass>> GetRecordList(int iPage, int iPageSize);
        DBAccess.SplitPage<DataTable> GetPageTable(int iPage, int iPageSize);
         
    }
}
