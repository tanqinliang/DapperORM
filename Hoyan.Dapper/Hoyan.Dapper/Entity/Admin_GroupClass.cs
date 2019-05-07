using System;
using System.Collections.Generic;
using System.Text;

namespace Hoyan.Dapper.Entity
{
    public class Admin_GroupClass : DBAccess.Entity.ModelBase
    {


        /// <summary>
        /// ParentID
        /// </summary>
        public int ParentID { get; set; }


        /// <summary>
        /// Title
        /// </summary>
        public int Title { get; set; }


        /// <summary>
        /// OrderNo
        /// </summary>
        public int OrderNo { get; set; }



        /// <summary>
        /// 构造函数
        /// </summary>
        public Admin_GroupClass()
        {
            this.ID = 0;
            this.ParentID = 0;
            this.Title = 0;
            this.OrderNo = 0;
        }
    }

}
