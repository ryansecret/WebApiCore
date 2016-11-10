using FluentValidation;

namespace WebApiCore.DomainModel.WebApiCore
{
    public class BallValidator: AbstractValidator<BallEntity>
    {
        public BallValidator()
        {
            this.RuleFor(d => d.Name).NotEmpty().WithErrorCode("100");
        }
    }
}
