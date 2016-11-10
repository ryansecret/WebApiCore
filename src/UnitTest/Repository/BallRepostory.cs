using FluentAssertions;
using NDaisy.Core.ServiceLocator;
using WebApiCore.DomainModel.WebApiCore;
using Xunit;

namespace UnitTest.Repository
{
    public class BallRepostory:BaseRepository
    {

        [Fact]
        public void InsertTest()
        {
           IBallRepository ballRepository= ServiceLocator.Current.GetInstance<IBallRepository>();
           var ball= new BallEntity("Football", "Blue");
           var id= ballRepository.AddGet(ball);
           ball.SetId(id);
           BallEntity result= ballRepository.FindBy(ball.Id);
           result.ShouldBeEquivalentTo(ball);
           
        }
    }
}