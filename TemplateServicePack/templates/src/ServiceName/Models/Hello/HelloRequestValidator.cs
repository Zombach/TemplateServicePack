using FluentValidation;

namespace ServiceName.Models.Hello;

public class HelloRequestValidator : AbstractValidator<HelloRequest>
{
    public HelloRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("The name must be specified");
    }
}
