using AutoMapper;
using NDaisy.Core;
using WebApiCore.Application.Models.Restaurant;
using WebApiCore.DomainModel.Restaurant;
using WebApiCore.DomainModel.WebApiCore;

namespace WebApiCore.Application.Models.Converter
{
    public class AutoMapperStartupTask: IStartupTask
    {
        public void Execute()
        {
             Mapper.Initialize(cg =>
             {
                 cg.ShouldMapField = d => true;
                 cg.ShouldMapProperty = p => true;

                 
                 cg.CreateMap<Restaurant.RestaurantModel, WebApiCore.DomainModel.Restaurant.Restaurant>();
                 cg.CreateMap<WebApiCore.DomainModel.Restaurant.Restaurant, RestaurantModel>();

                 cg.CreateMap<Ball.Ball, BallEntity>();
                 cg.CreateMap<BallEntity, Ball.Ball>();
             });
        }

        public int Order { get; } = 1;
    }
}
