namespace WpfTest.View;
using FluentValidation;

public class LoginValidator : AbstractValidator<LoginViewModel>
{
    public LoginValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Input your username");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Input your password")
            .MinimumLength(5).WithMessage("Min 5 symbols")
            .MaximumLength(20).WithMessage("Max 20 symbols");
    }
}