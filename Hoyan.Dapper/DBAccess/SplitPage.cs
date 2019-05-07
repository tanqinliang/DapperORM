using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess
{
    /// <summary>
    /// 分页数据类
    /// </summary>
    public class SplitPage<T> where T : class
    {
        private int _curpage = 1;			//当前页
        private int _pagesize = 20;			//每页显示多少记录,默认显示20条记录
        private int _totalpages = 0;		//一共有几页
        private int _totalrecords = 0;		//一共有多少条记录
        private T _curdata;			//返回的数据    

        #region 属性构造器
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page
        {
            get { return _curpage; }
            set { _curpage = value; }
        }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }

        /// <summary>
        /// 当前总的页数(只读)
        /// </summary>
        public int TotalPages
        {
            get { return _totalpages; }
            set { _totalpages = value; }
        }

        /// <summary>
        /// 当前总的记录数
        /// </summary>
        public int TotalRecords
        {
            get { return _totalrecords; }
            set { _totalrecords = value; }
        }

        /// <summary>
        /// 当前页的相关数据
        /// </summary>
        public T PageData
        {
            get { return _curdata; }
            set { _curdata = value; }
        }
        #endregion


        /// <summary>
        /// 构造函数(非精确分页)
        /// </summary>
        public SplitPage(int iPage, int iPageSize, T dtRecords)
        {
            if (iPage < 1) iPage = 1;

            this._curpage = iPage;
            this._curdata = dtRecords;
            this._pagesize = iPageSize;

            this._totalrecords = -1;
            this._totalpages = -1;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SplitPage(int iPage, int iPageSize, int iTotalRow, T dtRecords)
        {
            if (iPage < 1) iPage = 1;

            this._curpage = iPage;
            this._curdata = dtRecords;
            this._pagesize = iPageSize;
            this._totalrecords = iTotalRow;
            if (this._totalrecords % this._pagesize == 0)
            {
                this._totalpages = this._totalrecords / this._pagesize;
            }
            else
            {
                this._totalpages = this._totalrecords / this._pagesize + 1;
            }
        }


        /// <summary>
        /// 返回分页的文本信息(HTML格式)
        /// </summary>
        /// <param name="sParaList">参数列表，例如id=iID&Name=sName</param>
        /// <returns></returns>
        public string ReturnCutPage(string sParaList)
        {
            return ReturnCutPage(sParaList, 10);
        }

        /// <summary>
        /// 返回分页的文本信息(HTML格式)
        /// </summary>
        /// <param name="sParaList">参数列表，例如id=iID&Name=sName</param>
        /// <param name="iNum">当前一共显示多少页项</param>
        /// <param name="bIsSimple">是否是简版的，不需要下拉直接跳转</param>
        /// <returns></returns>
        public string ReturnCutPage(string sParaList, int iNum, bool bIsSimple = true)
        {
            int iPageNo = this._curpage;
            int iPageSize = this._pagesize;
            int iPageCount = this._totalrecords;
            int iCutPageNo = this._totalpages;

            int iMidPage = iNum / 2;//中间项目页
            int icurPageNum = 1;//记录已经生成了几个项目
            string sPageUrl = "?page=[PageNo]";
            if (sParaList != "") sPageUrl += "&" + sParaList;

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"pagination\">");

            //添加首页
            if (iPageNo > 1)
            {
                sb.Append(" <a href=" + sPageUrl.Replace("[PageNo]", "1") + ">首页</a>");
                sb.Append(" <a href=" + sPageUrl.Replace("[PageNo]", Convert.ToString(iPageNo - 1)) + ">« 上一页</a>");
            }
            else
            {
                sb.Append(" <span class=\"disabled\">首页</span>");
                sb.Append(" <span class=\"disabled\">« 上一页</span>");
            }

            //总数据大于3时以及大于需要显示的数据时进行中间页项目换算
            if (iCutPageNo > 3 && iCutPageNo > iNum)
            {
                //显示当前页前面几页
                int ipf = iPageNo - iMidPage;
                //如果过小则等于1
                if (ipf < 1)
                {
                    ipf = 1;
                }

                //计算前面需要补充几个项目页
                if (iCutPageNo - iPageNo < iMidPage)
                {
                    ipf = iPageNo - iNum + (iCutPageNo - iPageNo) + 1;
                }

                //循环显示当前页前面的页面项目
                for (int fp = ipf; fp < iPageNo + 1; fp++)
                {
                    if (fp == iPageNo)
                    {
                        sb.Append("<span class=\"current\">" + iPageNo + "</span>");
                    }
                    else
                    {
                        sb.Append(" <a href='" + sPageUrl.Replace("[PageNo]", fp.ToString()) + "'>" + fp + "</a> ");
                    }

                    icurPageNum++;
                }


                //显示当前页的后几页
                if (iPageNo != iCutPageNo)
                {
                    //当前页后还需要显示几页
                    int iep = iMidPage + iPageNo + 1;
                    //计算是否需要后面补充
                    if (icurPageNum < iMidPage + 2)
                    {
                        iep = iNum + iPageNo;
                    }

                    //循环显示当前页后页面项目
                    for (int bp = iPageNo + 1; bp < iep; bp++)
                    {
                        //当大于需要显示的项目时退出
                        if (icurPageNum > iNum)
                        {
                            break;
                        }
                        //当大于总页数时退出
                        if (bp > iCutPageNo)
                        {
                            break;
                        }
                        else
                        {
                            sb.Append(" <a href='" + sPageUrl.Replace("[PageNo]", bp.ToString()) + "'>" + bp + "</a> ");
                        }

                        icurPageNum++;
                    }
                }
            }
            else
            {
                //普通的添加页项显示
                for (int p = 1; p < iCutPageNo + 1; p++)
                {
                    if (p == iPageNo)
                    {
                        sb.Append("<span class=\"current\">" + p + "</span>");
                    }
                    else
                    {
                        sb.Append(" <a href='" + sPageUrl.Replace("[PageNo]", p.ToString()) + "'>" + p + "</a> ");
                    }
                }
            }

            //添加尾页
            if (iCutPageNo > 1 && iPageNo != iCutPageNo)
            {
                sb.Append(" <a href='" + sPageUrl.Replace("[PageNo]", Convert.ToString(iPageNo + 1)) + "'>下一页 »</a>");
                sb.Append(" <a href='" + sPageUrl.Replace("[PageNo]", iCutPageNo.ToString()) + "'>尾页</a>");
            }
            else
            {
                sb.Append(" <span class=\"disabled\">下一页 »</span>");
                sb.Append(" <span class=\"disabled\">尾页</span>");
            }

            sb.Append("<span style=\"color:black;\" class=\"sumCount\">总记录：" + this._totalrecords + "</span>");
            sb.Append("<span style=\"color:black;\" class=\"pageCount\">总页数：" + this._totalpages + "</span>");


            if (!bIsSimple)
            {
                sb.Append(" 转到：<select name=\"topage\" style=\"font-size: 12px;font-family: Arial,宋体\" onchange=\"javascript:window.location='" + sPageUrl.Replace("[PageNo]", "'+this.value+'") + "'\">");
                for (int i = 1; i < iCutPageNo + 1; i++)
                {
                    if (i == iPageNo)
                    {
                        sb.Append("<option value=" + i + " selected>第" + i + "页</option>");
                    }
                    else
                    {
                        sb.Append("<option value=" + i + ">第" + i + "页</option>");
                    }
                }
                sb.Append("</select>");
            }
            sb.Append("</div>");


            return sb.ToString();
        }

    }
}
