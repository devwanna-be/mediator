using FluentValidation;

namespace Mediator.API.App.UseCase.Sample
{
    public class SampleValidation : AbstractValidator<SampleRequest>
    {
        public SampleValidation()
        {
            RuleFor(x => x.NRP).NotEmpty();
        }
    }
}
