using System.ComponentModel;
using FluentValidation;

namespace WebApiCore.DomainModel.WebApiCore
{
    public class BallEntity:BaseEntity<int>
    {
        public BallEntity()
        {
            
        }
         
        public BallEntity(string name,string color)
        {
            this.Name = name;
            this.Color = color;
        }

      

        [DisplayName("姓名")]
        public string Name { get; private set; }

        public string Color { get; private set; }


        protected override IValidator GetValidator()
        {
             return new BallValidator();
        }
    }
}
