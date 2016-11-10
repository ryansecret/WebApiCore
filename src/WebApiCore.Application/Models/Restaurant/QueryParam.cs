using System;
using System.Collections.Generic;

namespace WebApiCore.Application.Models.Restaurant
{
    /// <summary>
    /// 参数
    /// </summary>
    public class QueryParam:QueryBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? RestaurantId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<int> RestaurantIds { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string RestaurantPhone { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

       
    }
}