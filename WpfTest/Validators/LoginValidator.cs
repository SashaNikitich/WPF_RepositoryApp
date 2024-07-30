using FluentValidation;
using WpfTest.Model;

namespace WpfTest.Validators;

public class LoginValidator : AbstractValidator<LoginModel>
{
    public LoginValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Input your username");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Input your password");
    }
}