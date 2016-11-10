using System.Collections.Generic;

namespace WebApiCore.Application.Models
{
    /// <summary>
    /// 分页集合封装
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalRows
        {
            get;
            set;
        }
        /// <summary>
        /// 集合列表
        /// </summary>
        public List<T> Collections
        {
            get;
            set;
        }
    }
}
