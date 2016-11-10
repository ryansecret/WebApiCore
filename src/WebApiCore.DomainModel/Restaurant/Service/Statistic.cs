using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiCore.DomainModel.Restaurant.Service
{
    public class Statistic
    {
        public static IList<StatisticItem> GetStatistic(StatisticQurey query, IList<StatisticItem> list)
        {
            var step = 1;
            var days = (query.EndTime - query.StartTime).Days;

            var stepCount = days / step;
            List<StatisticItem> statisticItems = new List<StatisticItem>();

            for (int i = 0; i < stepCount; i++)
            {
                var start = query.StartTime.AddDays(step * i);
                var end = query.StartTime.AddDays(step * (i + 1));

                var data = list.Where(d => DateTime.Parse(d.Lable)>= start && DateTime.Parse(d.Lable)< end).ToList();

                statisticItems.Add(new StatisticItem() { Lable = start.ToString("MM-dd"), Value = data.Sum(d => d.Value) });
            }
            return statisticItems;
        }
    }
}