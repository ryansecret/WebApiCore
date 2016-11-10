using System;

namespace WebApiCore.Application.Models.Restaurant
{
    /// <summary>
    /// </summary>
    public class RestaurantModel
    {
        /// <summary>
        ///商户 id
        /// </summary>
        public int RestaurantId { get; set; }
                    
        /// <summary>
        /// 餐厅名称
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// </summary>
        public string RestaurantPhone { get; set; }

        /// <summary>
        /// 开店时间
        /// </summary>
       
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// </summary>
        public string SubName { get; set; }

        /// <summary>
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     //
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// </summary>
        public string RegionName { get; set; }
    }
}