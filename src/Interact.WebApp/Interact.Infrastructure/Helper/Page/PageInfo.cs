using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper.Model
{
    public class PageInfo<T>
    {
        #region Compute Attr
        /// <summary>
        /// 当前页码
        /// </summary>

        public int PageIndex
        {
            get; set;
        }
        public int PageCount
        {
            get
            {
                if (DataCount <= 0)
                {
                    return 0;
                }
               
                int pageCount = Convert.ToInt32(Math.Ceiling((double)DataCount / pageSize));
                return pageCount;
            }
        }
        /// <summary>
        /// 每页条数
        /// </summary>
        private int pageSize;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (pageSize <= 0)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = value;
                }
            }
        }

        #endregion
       
        public T DataSource { get; set; }
        public int DataCount { get; set; } = 0;
    }
}
