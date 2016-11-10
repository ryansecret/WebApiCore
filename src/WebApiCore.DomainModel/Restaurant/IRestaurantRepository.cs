using System.Collections.Generic;

namespace WebApiCore.DomainModel.Restaurant
{
    public interface IRestaurantRepository: IRepository<Restaurant, int>
    {
        IEnumerable<DomainModel.Restaurant.Restaurant> Select(Query query, out int totalRows);

        IEnumerable<StatisticItem> GetIncreasedTrend(StatisticQurey qurey);

        List<AreaInfos> GetAreaInfos(int id);
        /// <summary>
        /// 查询所有餐在ID
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> SelectAllIds();
    }
}