
using CashFlow.Communication.Enum;
using CashFlow.Communication.Reponse;
using CashFlow.Communication.Request;

namespace CashFlow.Application.UseCases.CashFlow.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisteredExpenseJson
        {
            Title = request.Title
        };
    }
    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ArgumentException(string.Join(", ", errorMessages));
        }
    }
}
