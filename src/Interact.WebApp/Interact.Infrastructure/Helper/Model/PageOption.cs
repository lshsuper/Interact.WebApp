﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Interact.Infrastructure.Helper.Model
{
    /// <summary>
    /// 分页参数类
    /// </summary>
    public  abstract class PageOption
    {
        public bool IsDesc { get; set; }
        public string OrderBy { get; set; } = "CreateTime";
        public PageOption()
        {
            DynamicParameters = new DynamicParameters();
            IsDesc = true;
        }
        protected DynamicParameters DynamicParameters { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }=1;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; } =10;
        /// <summary>
        /// 区间起始位置
        /// </summary>
        public int Start
        {
            get
            {
                return PageSize*PageIndex-PageSize+1;
            }
        }
        /// <summary>
        /// 区间末尾位置
        /// </summary>
        public int End
        {
            get
            {
                return PageIndex* PageSize;
            }

        }
        //构建sql条件语句
         public abstract string BuildFilterStr();
        /// <summary>
        /// 构建sql参数
        /// </summary>
        /// <returns></returns>
        public DynamicParameters BuildParams()
        {
            return DynamicParameters;
        }
        /// <summary>
        /// 构建排序条件
        /// </summary>
        /// <param name="tableTag"></param>
        /// <returns></returns>
        public string BuildOrderByStr(string tableTag="")
        {
            return $"order by {(string.IsNullOrEmpty(tableTag) ? OrderBy:tableTag+"."+OrderBy)} {(IsDesc ? "desc":"asc")}";
        }
        /// <summary>
        /// 构建区间条件
        /// </summary>
        /// <param name="numColumnKey"></param>
        /// <param name="tableTag"></param>
        /// <returns></returns>
        public string BuildRangeStr(string numColumnKey,string tableTag="")
        {
            return $"({(string.IsNullOrEmpty(tableTag) ? "" : tableTag + ".")} {numColumnKey} between {Start} and {End})";
        }
     

    }
}
