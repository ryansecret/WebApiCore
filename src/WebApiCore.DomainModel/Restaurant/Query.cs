using System;
using System.Collections.Generic;

namespace WebApiCore.DomainModel.Restaurant
{
    public class Query:QueryBase
    {
        public IEnumerable<int> RestaurantIds { get; set; }

        public int? RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantPhone { get; set; }
        public string ProvinceName { get; set; }

        public string CityName { get; set; }

        public string RegionName { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}