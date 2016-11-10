using System;
using FluentValidation;
using WebApiCore.DomainModel;

namespace WebApiCore.DomainModel.Restaurant
{
    public class Restaurant:BaseEntity<int>
    {
        public Restaurant()
        {

        }
        public Restaurant( int restaurantid, string restaurantname, string restaurantphone, DateTime? createdate, string subname, string address, string provincename, string cityname, string regionname)
        {
            
            this.RestaurantId = restaurantid;
            this.RestaurantName = restaurantname;
            this.RestaurantPhone = restaurantphone;
            this.CreateDate = createdate;
            this.SubName = subname;
            this.Address = address;
            this.ProvinceName = provincename;
            this.CityName = cityname;
            this.RegionName = regionname;
        }
          
 
        public int RestaurantId { get; private set; }

        public string RestaurantName { get; private set; }

        public string RestaurantPhone { get; private set; }

        public DateTime? CreateDate { get; private set; }

        public string SubName { get; private set; }

        public string Address { get; private set; }

        public string ProvinceName { get; private set; }

        public string CityName { get; private set; }

        public string RegionName { get; private set; }

        protected override IValidator GetValidator()
        {
            return new RestaurantVa();
        }
    }

    public class RestaurantVa : AbstractValidator<Restaurant>
    {
        public RestaurantVa()
        {

        }
    }
}