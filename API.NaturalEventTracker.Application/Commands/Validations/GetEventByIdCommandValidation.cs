using FluentValidation;

namespace API.NaturalEventTracker.Application.Commands.Validations
{
    public class GetEventByIdCommandValidation : AbstractValidator<GetEventByIdCommand>
    {
        public GetEventByIdCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Event Id is Required.");

        }
    }
}
