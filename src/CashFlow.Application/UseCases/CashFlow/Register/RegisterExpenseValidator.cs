
using CashFlow.Communication.Request;
using FluentValidation;

namespace CashFlow.Application.UseCases.CashFlow.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date must be less than or equal to the current date");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("PaymentType is invalid");
    }
}
