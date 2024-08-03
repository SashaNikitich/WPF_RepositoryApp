using FluentValidation;
using WpfTest.Model;

namespace WpfTest.Validators;

public class RegisterValidator : AbstractValidator<RegisterModel>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Input your username")
            .MaximumLength(30).WithMessage("Max 30 symbols for username")
            .MinimumLength(3).WithMessage("Min 3 symbols for username");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Input your password")
            .MinimumLength(5).WithMessage("Min 5 symbols for password")
            .MaximumLength(20).WithMessage("Max 20 symbols for password");
    }
}