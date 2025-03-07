using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.User
{
    public class userValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public userValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
                .EmailAddress()
                .WithMessage(ResourceErrorMessages.EMAIL_INVALID);
            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());

        }
    }
}
