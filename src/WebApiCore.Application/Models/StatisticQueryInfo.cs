using System;

namespace WebApiCore.Application.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class StatisticQueryInfo
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime;
        /// <summary>
        /// 省
        /// </summary>
        public string ProvinceName;
        /// <summary>
        /// 市
        /// </summary>
        public string CityName;
        /// <summary>
        /// 区
        /// </summary>
        public string AreaName;
    }
}