using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTested.AspNetCore.Mvc;
using WebApiCore.Application.Models;
using WebApiCore.Application.Models.Ball;
using WebApiCore.Controllers;
using Xunit;

namespace WebApiCore.Test.Controller
{
    public class ValuesControllerTest
    {
        public ValuesControllerTest()
        {
            
        }
        [Fact]
        public void GetValues()
        {
            MyMvc.Controller<ShowController>()
                .Calling(d => d.HelloAsync())
                .ShouldReturn()
                .ResultOfType<OutputWithData<string>>().Passing(d=>d.ResultStatus==1);


        }
        [Fact]
        public void Saves()
        {

            MyMvc.Controller<ShowController>().WithServices()
                .Calling(d => d.SaveBall(new Ball()))
                .ShouldReturn()
                .ResultOfType<OutputWithData<bool>>().Passing(d=>!d.DataBody);

        }
    }
}
