using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Validators;

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
        [MaxLength(50)]
        public string Country { get; private set; }
        protected override IValidator GetValidator()
        {
             return new BallValidator();
        }
    }
}
