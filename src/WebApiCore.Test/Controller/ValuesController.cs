using System.Collections.Generic;
using System.Linq;
using MyTested.AspNetCore.Mvc;
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
            MyMvc.Controller<ValuesController>()
                .Calling(d => d.Get())
                .ShouldReturn()
                .ResultOfType<IEnumerable<string>>()
                .Passing(d=>d.Any());

        }
        [Fact]
        public void Saves()
        {

            MyMvc.Controller<ValuesController>().WithServices()
                .Calling(d => d.Save())
                .ShouldReturn()
                .ResultOfType<bool>()
                .Passing(d => d);
        }
    }
}
